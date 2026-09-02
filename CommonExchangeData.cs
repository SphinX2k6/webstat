using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;

// Token: 0x0200204D RID: 8269
[NullableContext(1)]
[Nullable(0)]
public class CommonExchangeData : UiPopViewData, IViewOpenParamMultipleView
{
	// Token: 0x1700129B RID: 4763
	// (get) Token: 0x0600FBDE RID: 64478 RVA: 0x00452AAF File Offset: 0x00450CAF
	// (set) Token: 0x0600FBDF RID: 64479 RVA: 0x00452AB7 File Offset: 0x00450CB7
	public bool IsMultipleView { get; set; } = true;

	// Token: 0x0600FBE0 RID: 64480 RVA: 0x00452AC0 File Offset: 0x00450CC0
	public void InitBySrcAndDestItemId(int srcItemId, int destItemId, int? srcItemCount = null, int? destItemCount = null)
	{
		this.SrcExchangeUnitData.SetDataByItemId(srcItemId, srcItemCount);
		this.DestExchangeUnitData.SetDataByItemId(destItemId, destItemCount);
	}

	// Token: 0x0600FBE1 RID: 64481 RVA: 0x00452AE0 File Offset: 0x00450CE0
	public void InitByItemId(int itemId)
	{
		ItemExchangeContent value = ConfigBase<ItemExchangeConfig>.Instance.GetFirstExChangeConfigList(itemId).Value;
		if (itemId == 3)
		{
			this.ShowPayGold = true;
		}
		if (value.Consume().Count > 1)
		{
			Singleton<Log>.Instance.Error(ELogModule.ItemExchange, ELogAuthor.ZJC, "暂不支持消耗数量为1以上的道具兑换, 需要扩展!", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		if (value.Consume().Count > 0)
		{
			using (Dictionary<int, int>.Enumerator enumerator = value.Consume().GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					KeyValuePair<int, int> keyValuePair = enumerator.Current;
					this.SrcExchangeUnitData.SetDataByItemId(keyValuePair.Key, null);
				}
			}
		}
		this.DestExchangeUnitData.SetDataByItemId(value.ItemId, null);
	}

	// Token: 0x0600FBE2 RID: 64482 RVA: 0x00452BC4 File Offset: 0x00450DC4
	public string GetSrcName()
	{
		return this.SrcExchangeUnitData.Name;
	}

	// Token: 0x0600FBE3 RID: 64483 RVA: 0x00452BD1 File Offset: 0x00450DD1
	public int GetSrcItemId()
	{
		return this.SrcExchangeUnitData.ItemId;
	}

	// Token: 0x0600FBE4 RID: 64484 RVA: 0x00452BDE File Offset: 0x00450DDE
	public int GetSrcTotalCount()
	{
		return this.SrcExchangeUnitData.TotalCount;
	}

	// Token: 0x0600FBE5 RID: 64485 RVA: 0x00452BEB File Offset: 0x00450DEB
	public string GetDestName()
	{
		return this.DestExchangeUnitData.Name;
	}

	// Token: 0x0600FBE6 RID: 64486 RVA: 0x00452BF8 File Offset: 0x00450DF8
	public int GetDestItemId()
	{
		return this.DestExchangeUnitData.ItemId;
	}

	// Token: 0x040078E7 RID: 30951
	private readonly ExchangeUnitData SrcExchangeUnitData = new ExchangeUnitData();

	// Token: 0x040078E8 RID: 30952
	private readonly ExchangeUnitData DestExchangeUnitData = new ExchangeUnitData();

	// Token: 0x040078E9 RID: 30953
	[Nullable(2)]
	public Action CancelCallBack;

	// Token: 0x040078EA RID: 30954
	public bool ConfirmNoClose;

	// Token: 0x040078EB RID: 30955
	public bool ShowPayGold;

	// Token: 0x040078EC RID: 30956
	[Nullable(2)]
	public Action<int, int> ConfirmCallBack;
}
