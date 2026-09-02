using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029A9 RID: 10665
[NullableContext(1)]
[Nullable(0)]
public class ShipTowerBuffView : UiViewBase
{
	// Token: 0x06015433 RID: 87091 RVA: 0x005E47FA File Offset: 0x005E29FA
	public ShipTowerBuffView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015434 RID: 87092 RVA: 0x005E4804 File Offset: 0x005E2A04
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06015435 RID: 87093 RVA: 0x005E48B0 File Offset: 0x005E2AB0
	private void InitDataParam()
	{
		ShipTowerBuffViewParams shipTowerBuffViewParams = this.OpenParam as ShipTowerBuffViewParams;
		int? num = (shipTowerBuffViewParams != null) ? shipTowerBuffViewParams.BuffId : null;
		if (num != null && num.GetValueOrDefault() != 0)
		{
			ShipTowerBuffData buffDataByBuffId = ModelBase<ShipTowerModel>.Instance.GetBuffDataByBuffId(num.Value);
			if (buffDataByBuffId != null)
			{
				buffDataByBuffId.SetSelected(true);
				return;
			}
		}
		else
		{
			int? stageId = (shipTowerBuffViewParams != null) ? shipTowerBuffViewParams.StageId : null;
			ModelBase<ShipTowerModel>.Instance.SelectDefaultBuff(stageId);
		}
	}

	// Token: 0x06015436 RID: 87094 RVA: 0x005E492F File Offset: 0x005E2B2F
	private static void InvokeOnUseBuff(object openParam, ShipTowerBuffData buffData, [Nullable(2)] object teamData)
	{
		if (openParam == null)
		{
			return;
		}
		Action<ShipTowerBuffData, ShipTowerTeamData> onUseBuff = (openParam as ShipTowerBuffViewParams).OnUseBuff;
		if (onUseBuff == null)
		{
			return;
		}
		onUseBuff(buffData, teamData as ShipTowerTeamData);
	}

	// Token: 0x06015437 RID: 87095 RVA: 0x005E4954 File Offset: 0x005E2B54
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerBuffView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerBuffView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015438 RID: 87096 RVA: 0x005E4997 File Offset: 0x005E2B97
	protected override void OnBeforeDestroy()
	{
		this.FinishLoadedBuffPromise();
		ItemTipsWithButtonComponent itemTipsComponent = this.ItemTipsComponent;
		if (itemTipsComponent != null)
		{
			itemTipsComponent.Destroy(null);
		}
		this.ItemTipsComponent = null;
		this.PopupCaption = null;
	}

	// Token: 0x06015439 RID: 87097 RVA: 0x005E49BF File Offset: 0x005E2BBF
	private void TimerFinishLoadedBuffPromise(float _)
	{
		this.FinishLoadedBuffPromise();
	}

	// Token: 0x0601543A RID: 87098 RVA: 0x005E49C7 File Offset: 0x005E2BC7
	private void FinishLoadedBuffPromise()
	{
		if (this.LoadedBuffPromise != null && !this.LoadedBuffPromise.IsFulfilled)
		{
			this.LoadedBuffPromise.SetResult(true);
		}
	}

	// Token: 0x0601543B RID: 87099 RVA: 0x005E49EC File Offset: 0x005E2BEC
	private void OnClickBtnSelect(int _)
	{
		object openParam = this.OpenParam;
		ShipTowerTeamData teamData = (openParam as ShipTowerBuffViewParams).TeamData;
		ShipTowerBuffView.InvokeOnUseBuff(openParam, this.SelectedData, teamData);
	}

	// Token: 0x0601543C RID: 87100 RVA: 0x005E4A17 File Offset: 0x005E2C17
	private ShipTowerBuffListItem CreateBuffListItem()
	{
		return new ShipTowerBuffListItem
		{
			OnItemClickCallback = new Action<ShipTowerBuffData>(this.OnItemClickCallback),
			GetStageIdCallback = new Func<int?>(this.GetStageIdCallback),
			BuffComponentLoadedCallback = new Action(this.BuffComponentLoadedCallback)
		};
	}

	// Token: 0x0601543D RID: 87101 RVA: 0x005E4A54 File Offset: 0x005E2C54
	private void BuffComponentLoadedCallback()
	{
		this.LoadedBuffNum++;
		if (this.LoadedBuffNum < this.LoadedBuffSumNum)
		{
			return;
		}
		this.FinishLoadedBuffPromise();
	}

	// Token: 0x0601543E RID: 87102 RVA: 0x005E4A7C File Offset: 0x005E2C7C
	private int? GetStageIdCallback()
	{
		ShipTowerBuffViewParams shipTowerBuffViewParams = this.OpenParam as ShipTowerBuffViewParams;
		if (shipTowerBuffViewParams == null)
		{
			return null;
		}
		ShipTowerTeamData teamData = shipTowerBuffViewParams.TeamData;
		if (teamData == null)
		{
			return null;
		}
		return new int?(teamData.StageId);
	}

	// Token: 0x0601543F RID: 87103 RVA: 0x005E4AC0 File Offset: 0x005E2CC0
	private void OnItemClickCallback(ShipTowerBuffData data)
	{
		this.SelectedData = data;
		this.UpdateButton();
		ItemTipsData tipsDataById = ItemTipsComponentUtilTool.GetTipsDataById(this.SelectedData.ItemId, null, null);
		int? stageId = (this.OpenParam as ShipTowerBuffViewParams).StageId;
		tipsDataById.UpdateShowNumCallback = (() => data.CanUseCount);
		tipsDataById.IsShowNumTextCallback = (() => data.IsShowNumTextCallback(stageId));
		this.ItemTipsComponent.RefreshTips(tipsDataById);
		this.ItemTipsComponent.SetVisible(true);
		bool flag = data.AddToGetState();
		GenericScrollViewNew<ShipTowerBuffListItem, ShipTowerBuffQuality> scrollView = this.ScrollView;
		List<ShipTowerBuffListItem> list = (scrollView != null) ? scrollView.GetScrollItemList() : null;
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				ShipTowerBuffListItem shipTowerBuffListItem = list[i];
				if (flag)
				{
					shipTowerBuffListItem.UpdateBuffInfo();
				}
				shipTowerBuffListItem.UpdateBuffSelected();
			}
		}
	}

	// Token: 0x06015440 RID: 87104 RVA: 0x005E4BAC File Offset: 0x005E2DAC
	private void UpdateButton()
	{
		this.ItemTipsComponent.ClearButtonList();
		this.ItemTipsComponent.SetLockStateVisible(false);
		object openParam = this.OpenParam;
		EShipTowerBuffOperationType? operationType = (openParam as ShipTowerBuffViewParams).OperationType;
		if (operationType.GetValueOrDefault() != EShipTowerBuffOperationType.Use)
		{
			return;
		}
		ShipTowerBuffData selectedData = this.SelectedData;
		if (selectedData == null || !selectedData.IsUnlock)
		{
			this.ItemTipsComponent.SetLockStateData(new ItemTipsLockStateData
			{
				TipsTextKey = "GhostShipItemLock_Text"
			});
			return;
		}
		int? stageId = (openParam as ShipTowerBuffViewParams).StageId;
		if (this.SelectedData != null && !this.SelectedData.IsCanUse(stageId))
		{
			this.ItemTipsComponent.SetLockStateData(new ItemTipsLockStateData
			{
				TipsTextKey = "GhostShipItemLimit_Text"
			});
			return;
		}
		List<IButtonInfo> list = new List<IButtonInfo>();
		ButtonInfo item = new ButtonInfo
		{
			Function = new Action<int>(this.OnClickBtnSelect),
			Text = "GhostShipEquipBuff_Text",
			Index = 0
		};
		list.Add(item);
		this.ItemTipsComponent.RefreshButton(list);
	}

	// Token: 0x06015441 RID: 87105 RVA: 0x005E4CA4 File Offset: 0x005E2EA4
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		List<ShipTowerBuffQuality> buffQualityList = ModelBase<ShipTowerModel>.Instance.GetBuffQualityList(true);
		if (buffQualityList.Count == 0)
		{
			return null;
		}
		if (configParams.Length != 3)
		{
			return null;
		}
		int num;
		if (!int.TryParse(configParams[1], out num) || num < 0 || num >= buffQualityList.Count)
		{
			return null;
		}
		GenericScrollViewNew<ShipTowerBuffListItem, ShipTowerBuffQuality> scrollView = this.ScrollView;
		ShipTowerBuffListItem shipTowerBuffListItem = (scrollView != null) ? scrollView.GetScrollItemByIndex(num) : null;
		if (shipTowerBuffListItem == null)
		{
			return null;
		}
		return shipTowerBuffListItem.GetGuideUiItemAndUiItemForShowEx(configParams);
	}

	// Token: 0x0400A3F9 RID: 41977
	[Nullable(2)]
	private PopupCaptionItem PopupCaption;

	// Token: 0x0400A3FA RID: 41978
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<ShipTowerBuffListItem, ShipTowerBuffQuality> ScrollView;

	// Token: 0x0400A3FB RID: 41979
	[Nullable(2)]
	private ItemTipsWithButtonComponent ItemTipsComponent;

	// Token: 0x0400A3FC RID: 41980
	[Nullable(2)]
	private ShipTowerBuffData SelectedData;

	// Token: 0x0400A3FD RID: 41981
	private int LoadedBuffNum;

	// Token: 0x0400A3FE RID: 41982
	private int LoadedBuffSumNum;

	// Token: 0x0400A3FF RID: 41983
	[Nullable(2)]
	private CustomPromise<bool> LoadedBuffPromise;

	// Token: 0x02008CF4 RID: 36084
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402F6AF RID: 194223
		ScrollViewBuffList,
		// Token: 0x0402F6B0 RID: 194224
		ItemBuffList,
		// Token: 0x0402F6B1 RID: 194225
		ItemCaption,
		// Token: 0x0402F6B2 RID: 194226
		ItemBuffDesc
	}
}
