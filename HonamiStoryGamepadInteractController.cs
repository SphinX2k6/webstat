using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.HonamiStory;

// Token: 0x02001EF9 RID: 7929
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryGamepadInteractController
{
	// Token: 0x0600EC45 RID: 60485 RVA: 0x00404337 File Offset: 0x00402537
	public void RegisterPanel(HonamiStoryBackpackPanelBase panel)
	{
		this.PanelBaseList.Add(panel);
	}

	// Token: 0x0600EC46 RID: 60486 RVA: 0x00404345 File Offset: 0x00402545
	public void ClearPanel()
	{
		this.PanelBaseList.Clear();
	}

	// Token: 0x17001222 RID: 4642
	// (get) Token: 0x0600EC47 RID: 60487 RVA: 0x00404352 File Offset: 0x00402552
	[Nullable(2)]
	private HonamiStoryGamepadLogicController Logic
	{
		[NullableContext(2)]
		get
		{
			return ModelBase<HonamiStoryModel>.Instance.GetGamepadLogic();
		}
	}

	// Token: 0x0600EC48 RID: 60488 RVA: 0x00404360 File Offset: 0x00402560
	public bool CheckOverflowByLeftOrRight(int position, HonamiStoryGridItemBase item, int backpackWidth, int offset)
	{
		int num = position % backpackWidth;
		int num2 = 0;
		HonamiStoryItemDataBase data = item.GetData();
		if (data != null)
		{
			num2 = data.GetGridWidth();
		}
		bool flag = num + (num2 - 1) + offset > backpackWidth;
		return num + offset < 0 || flag;
	}

	// Token: 0x0600EC49 RID: 60489 RVA: 0x00404397 File Offset: 0x00402597
	public bool HasFallingPile()
	{
		return this.PanelBaseList.Count > 2;
	}

	// Token: 0x0600EC4A RID: 60490 RVA: 0x004043A8 File Offset: 0x004025A8
	[NullableContext(2)]
	private HonamiStoryBackpackData GetBackpackData(int backpackType)
	{
		EHonamiStoryBackpack backpackId;
		if (Singleton<HonamiStoryDefine>.Instance.HonamiBackpackTypeMap.TryGetValue((EHonamiStoryBackpackType)backpackType, out backpackId))
		{
			return ModelBase<HonamiStoryModel>.Instance.GetBackPackData((int)backpackId, false);
		}
		return null;
	}

	// Token: 0x0600EC4B RID: 60491 RVA: 0x004043D8 File Offset: 0x004025D8
	public int GetBackpackCapacity(int backpackType)
	{
		int result = 0;
		HonamiStoryBackpackData backpackData = this.GetBackpackData(backpackType);
		if (backpackData != null)
		{
			result = backpackData.GetCapacity();
		}
		return result;
	}

	// Token: 0x0600EC4C RID: 60492 RVA: 0x004043FC File Offset: 0x004025FC
	public int GetBackpackWidth(int backpackType)
	{
		int result = 0;
		HonamiStoryBackpackData backpackData = this.GetBackpackData(backpackType);
		if (backpackData != null)
		{
			result = backpackData.GetWidthCount();
		}
		return result;
	}

	// Token: 0x0600EC4D RID: 60493 RVA: 0x0040441E File Offset: 0x0040261E
	private int GetColumn(int startPosition, int backpackWidth)
	{
		return startPosition / backpackWidth;
	}

	// Token: 0x0600EC4E RID: 60494 RVA: 0x00404423 File Offset: 0x00402623
	private int GetRow(int startPosition, int backpackWidth)
	{
		return startPosition % backpackWidth;
	}

	// Token: 0x0600EC4F RID: 60495 RVA: 0x00404428 File Offset: 0x00402628
	private int GetGridCenterPositionByParam(int startPosition, int itemWidth, int itemHeight, int backpackWidth)
	{
		int row = this.GetRow(startPosition, backpackWidth);
		int column = this.GetColumn(startPosition, backpackWidth);
		int num;
		int num2;
		if (itemWidth == 1 && itemHeight == 1)
		{
			num = row;
			num2 = column;
		}
		else if (itemWidth % 2 == 1 && itemHeight % 2 == 1)
		{
			int num3 = itemHeight / 2;
			int num4 = itemWidth / 2;
			num = row + num3;
			num2 = column + num4;
		}
		else if (itemWidth % 2 == 0 && itemHeight % 2 == 0)
		{
			num = row + itemHeight - 1;
			num2 = column + itemWidth - 1;
		}
		else if (itemWidth % 2 == 1 && itemHeight % 2 == 0)
		{
			int num5 = itemWidth / 2;
			num = row + itemHeight - 1;
			num2 = column + num5;
		}
		else if (itemWidth % 2 == 0 && itemHeight % 2 == 1)
		{
			int num6 = itemHeight / 2;
			num = row + num6;
			num2 = column + itemWidth - 1;
		}
		else
		{
			num = row;
			num2 = column;
		}
		return num2 * backpackWidth + num;
	}

	// Token: 0x0600EC50 RID: 60496 RVA: 0x004044DC File Offset: 0x004026DC
	private int GetGridCenterPosition(HonamiStoryGridItemBase item, int backpackWidth)
	{
		int startPosition = 0;
		int itemWidth = 0;
		int itemHeight = 0;
		HonamiStoryItemDataBase data = item.GetData();
		if (data != null)
		{
			startPosition = data.GetPosition();
			itemWidth = data.GetGridWidth();
			itemHeight = data.GetGridHeight();
		}
		return this.GetGridCenterPositionByParam(startPosition, itemWidth, itemHeight, backpackWidth);
	}

	// Token: 0x0600EC51 RID: 60497 RVA: 0x00404518 File Offset: 0x00402718
	public List<HonamiStoryGridItemBase> GetGridItemListByBackpackType(int backpackType)
	{
		List<HonamiStoryGridItemBase> result = new List<HonamiStoryGridItemBase>();
		foreach (HonamiStoryBackpackPanelBase honamiStoryBackpackPanelBase in this.PanelBaseList)
		{
			if (honamiStoryBackpackPanelBase.GetBackpackType() == backpackType)
			{
				result = honamiStoryBackpackPanelBase.GetCurrentGridListGamepad();
				break;
			}
		}
		return result;
	}

	// Token: 0x0600EC52 RID: 60498 RVA: 0x00404580 File Offset: 0x00402780
	[NullableContext(2)]
	public HonamiStoryGridItemBase GetGridItemByPosition(int position, int backpackType)
	{
		foreach (HonamiStoryGridItemBase honamiStoryGridItemBase in this.GetGridItemListByBackpackType(backpackType))
		{
			HonamiStoryItemDataBase data = honamiStoryGridItemBase.GetData();
			if (data != null)
			{
				if (data.GetPosition() == position || data.GetGridFillPositionList().Contains(position))
				{
					return honamiStoryGridItemBase;
				}
			}
			else if (honamiStoryGridItemBase.GetEmptyPosition() == position)
			{
				return honamiStoryGridItemBase;
			}
		}
		return null;
	}

	// Token: 0x0600EC53 RID: 60499 RVA: 0x00404604 File Offset: 0x00402804
	[NullableContext(2)]
	public HonamiStoryBackpackPanelBase GetPanelByBackpackType(int backpackType)
	{
		HonamiStoryBackpackPanelBase result = null;
		foreach (HonamiStoryBackpackPanelBase honamiStoryBackpackPanelBase in this.PanelBaseList)
		{
			if (honamiStoryBackpackPanelBase.GetBackpackType() == backpackType)
			{
				result = honamiStoryBackpackPanelBase;
				break;
			}
		}
		return result;
	}

	// Token: 0x0600EC54 RID: 60500 RVA: 0x00404660 File Offset: 0x00402860
	[return: Nullable(2)]
	public HonamiStoryBackpackPanelBase GetPanelByGridItem(HonamiStoryGridItemBase gridItem)
	{
		HonamiStoryBackpackPanelBase result = null;
		foreach (HonamiStoryBackpackPanelBase honamiStoryBackpackPanelBase in this.PanelBaseList)
		{
			using (List<HonamiStoryGridItemBase>.Enumerator enumerator2 = honamiStoryBackpackPanelBase.GetCurrentGridListGamepad().GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current == gridItem)
					{
						result = honamiStoryBackpackPanelBase;
						break;
					}
				}
			}
		}
		return result;
	}

	// Token: 0x0600EC55 RID: 60501 RVA: 0x004046F0 File Offset: 0x004028F0
	public int GetPanelIndexByGridItem(HonamiStoryGridItemBase gridItem)
	{
		int result = 0;
		HonamiStoryBackpackPanelBase panelByGridItem = this.GetPanelByGridItem(gridItem);
		if (panelByGridItem != null)
		{
			switch (panelByGridItem.GetBackpackType())
			{
			case 0:
			case 1:
				result = 2;
				break;
			case 2:
				result = 3;
				break;
			case 3:
				result = 1;
				break;
			}
		}
		return result;
	}

	// Token: 0x0600EC56 RID: 60502 RVA: 0x00404734 File Offset: 0x00402934
	public int GetEquipIndexByGridItem(HonamiStoryGridItemBase gridItem)
	{
		HonamiStoryBackpackPanelBase honamiStoryBackpackPanelBase = null;
		foreach (HonamiStoryBackpackPanelBase honamiStoryBackpackPanelBase2 in this.PanelBaseList)
		{
			if (honamiStoryBackpackPanelBase2.GetBackpackType() == 3)
			{
				honamiStoryBackpackPanelBase = honamiStoryBackpackPanelBase2;
				break;
			}
		}
		int num = 0;
		if (honamiStoryBackpackPanelBase != null)
		{
			using (List<HonamiStoryGridItemBase>.Enumerator enumerator2 = honamiStoryBackpackPanelBase.GetCurrentGridListGamepad().GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current == gridItem)
					{
						break;
					}
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x0600EC57 RID: 60503 RVA: 0x004047DC File Offset: 0x004029DC
	public void OnPickUp(HonamiStoryGridItemBase item)
	{
		HonamiStoryBackpackPanelBase panelByGridItem = this.GetPanelByGridItem(item);
		if (panelByGridItem != null)
		{
			int backpackType = panelByGridItem.GetBackpackType();
			if (backpackType == 0 || backpackType == 2 || backpackType == 1)
			{
				this.CacheBackpackWidth = this.GetBackpackWidth(panelByGridItem.GetBackpackType());
				this.CacheDragItemPosition = this.GetGridCenterPosition(item, this.CacheBackpackWidth);
			}
		}
		this.OperateAgent.Clear();
		this.OperateAgent.BaseWidth = 0f;
		this.OperateAgent.BaseHeight = 0f;
		this.OperateAgent.StartOperateBackpack = panelByGridItem;
		this.OperateAgent.OperateData = item.GetData();
		this.OnMove(item);
	}

	// Token: 0x0600EC58 RID: 60504 RVA: 0x00404880 File Offset: 0x00402A80
	public void OnMove(HonamiStoryGridItemBase item)
	{
		HonamiStoryBackpackPanelBase panelByGridItem = this.GetPanelByGridItem(item);
		if (panelByGridItem == null)
		{
			HonamiStoryBackpackPanelBase targetOperateBackpack = this.OperateAgent.TargetOperateBackpack;
			if (targetOperateBackpack != null)
			{
				targetOperateBackpack.OnHoverEnd();
			}
			this.OperateAgent.TargetOperateBackpack = null;
			this.OperateAgent.TargetPosition = -1;
			return;
		}
		if (this.OperateAgent.TargetOperateBackpack == panelByGridItem)
		{
			this.OperateAgent.TargetOperateBackpack.OnHoverGamepad(item, this.CacheDragItemPosition, this.OperateAgent);
			return;
		}
		HonamiStoryBackpackPanelBase targetOperateBackpack2 = this.OperateAgent.TargetOperateBackpack;
		if (targetOperateBackpack2 != null)
		{
			targetOperateBackpack2.OnHoverEnd();
		}
		this.OperateAgent.TargetOperateBackpack = panelByGridItem;
		HonamiStoryBackpackPanelBase targetOperateBackpack3 = this.OperateAgent.TargetOperateBackpack;
		if (targetOperateBackpack3 == null)
		{
			return;
		}
		targetOperateBackpack3.OnHoverGamepad(item, this.CacheDragItemPosition, this.OperateAgent);
	}

	// Token: 0x0600EC59 RID: 60505 RVA: 0x00404937 File Offset: 0x00402B37
	public void OnPutDown(HonamiStoryGridItemBase item)
	{
		this.ExecuteOperate(item);
		if (this.OperateAgent.TargetOperateBackpack != null)
		{
			this.OperateAgent.TargetOperateBackpack.OnHoverEnd();
		}
	}

	// Token: 0x0600EC5A RID: 60506 RVA: 0x00404960 File Offset: 0x00402B60
	private void ExecuteOperate(HonamiStoryGridItemBase item)
	{
		if (this.OperateAgent.TargetOperateBackpack == null || this.OperateAgent.StartOperateBackpack == null)
		{
			return;
		}
		List<HonamiStoryBagUpdateContext> list = new List<HonamiStoryBagUpdateContext>();
		if (this.OperateAgent.TargetOperateBackpack == this.OperateAgent.StartOperateBackpack)
		{
			HonamiStoryBagUpdateContext updateInfoInSameBackpackGamepad = this.OperateAgent.TargetOperateBackpack.GetUpdateInfoInSameBackpackGamepad(item, this.OperateAgent.OperateData);
			if (updateInfoInSameBackpackGamepad == null)
			{
				this.Logic.Reset();
				return;
			}
			list.Add(updateInfoInSameBackpackGamepad);
		}
		else
		{
			HashSet<HonamiStoryItemDataBase> exchangeItemSetGamepad = this.OperateAgent.TargetOperateBackpack.GetExchangeItemSetGamepad(item, this.OperateAgent.OperateData);
			if (exchangeItemSetGamepad == null)
			{
				this.Logic.Reset();
				return;
			}
			HonamiStoryBagUpdateContext updateInfoInReceiveBackpackGamepad = this.OperateAgent.TargetOperateBackpack.GetUpdateInfoInReceiveBackpackGamepad(item, this.OperateAgent.OperateData, exchangeItemSetGamepad);
			if (updateInfoInReceiveBackpackGamepad == null)
			{
				this.Logic.Reset();
				return;
			}
			list.Add(updateInfoInReceiveBackpackGamepad);
			HonamiStoryBagUpdateContext updateInfoInSendBackpackGamepad = this.OperateAgent.StartOperateBackpack.GetUpdateInfoInSendBackpackGamepad(item, this.OperateAgent.OperateData, exchangeItemSetGamepad);
			if (updateInfoInSendBackpackGamepad == null)
			{
				this.Logic.Reset();
				return;
			}
			list.Add(updateInfoInSendBackpackGamepad);
		}
		ControllerBase<HonamiStoryController>.Instance.SendHonamiStoryBagOperateRequest(list);
	}

	// Token: 0x0600EC5B RID: 60507 RVA: 0x00404A84 File Offset: 0x00402C84
	public void Reset()
	{
		this.CacheBackpackWidth = -1;
		this.CacheDragItemPosition = -1;
		foreach (HonamiStoryBackpackPanelBase honamiStoryBackpackPanelBase in this.PanelBaseList)
		{
			honamiStoryBackpackPanelBase.OnHoverEnd();
		}
	}

	// Token: 0x0400718F RID: 29071
	public List<HonamiStoryBackpackPanelBase> PanelBaseList = new List<HonamiStoryBackpackPanelBase>();

	// Token: 0x04007190 RID: 29072
	private readonly HonamiStoryInteractOperateAgent OperateAgent = new HonamiStoryInteractOperateAgent();

	// Token: 0x04007191 RID: 29073
	private int CacheBackpackWidth = -1;

	// Token: 0x04007192 RID: 29074
	private int CacheDragItemPosition = -1;
}
