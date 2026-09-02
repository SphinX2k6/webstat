using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012F4 RID: 4852
[NullableContext(1)]
[Nullable(0)]
public class DangoMonopolyMainCaption : UiPanelBase
{
	// Token: 0x0600837A RID: 33658 RVA: 0x0022B854 File Offset: 0x00229A54
	public UniTask Init(UUIItem item)
	{
		DangoMonopolyMainCaption.<Init>d__4 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.item = item;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<DangoMonopolyMainCaption.<Init>d__4>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600837B RID: 33659 RVA: 0x0022B8A0 File Offset: 0x00229AA0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickCloseBtn)),
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickHelpBtn))
		};
	}

	// Token: 0x0600837C RID: 33660 RVA: 0x0022B935 File Offset: 0x00229B35
	private void OnClickCloseBtn()
	{
		Action onCloseCallback = this.OnCloseCallback;
		if (onCloseCallback == null)
		{
			return;
		}
		onCloseCallback();
	}

	// Token: 0x0600837D RID: 33661 RVA: 0x0022B947 File Offset: 0x00229B47
	private void OnClickHelpBtn()
	{
		Action onHelpCallback = this.OnHelpCallback;
		if (onHelpCallback == null)
		{
			return;
		}
		onHelpCallback();
	}

	// Token: 0x0600837E RID: 33662 RVA: 0x0022B959 File Offset: 0x00229B59
	private UUIButtonComponent GetBtnClose()
	{
		return base.GetButton(0);
	}

	// Token: 0x0600837F RID: 33663 RVA: 0x0022B962 File Offset: 0x00229B62
	private UUIButtonComponent GetBtnHelp()
	{
		return base.GetButton(1);
	}

	// Token: 0x06008380 RID: 33664 RVA: 0x0022B96B File Offset: 0x00229B6B
	public UUIItem GetCostContent()
	{
		return base.GetItem(2);
	}

	// Token: 0x06008381 RID: 33665 RVA: 0x0022B974 File Offset: 0x00229B74
	public void SetBtnHelpVisible(bool state)
	{
		this.GetBtnHelp().RootUIComp.Get().SetUIActive(state);
	}

	// Token: 0x06008382 RID: 33666 RVA: 0x0022B99C File Offset: 0x00229B9C
	public void SetBtnCloseVisible(bool state)
	{
		this.GetBtnClose().RootUIComp.Get().SetUIActive(state);
	}

	// Token: 0x06008383 RID: 33667 RVA: 0x0022B9C2 File Offset: 0x00229BC2
	public void SetCurrencyVisible(bool bVisible)
	{
		this.GetCostContent().SetUIActive(bVisible);
	}

	// Token: 0x06008384 RID: 33668 RVA: 0x0022B9D0 File Offset: 0x00229BD0
	public UniTask SetCurrencyItemList(int[] itemIdList)
	{
		DangoMonopolyMainCaption.<SetCurrencyItemList>d__14 <SetCurrencyItemList>d__;
		<SetCurrencyItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SetCurrencyItemList>d__.<>4__this = this;
		<SetCurrencyItemList>d__.itemIdList = itemIdList;
		<SetCurrencyItemList>d__.<>1__state = -1;
		<SetCurrencyItemList>d__.<>t__builder.Start<DangoMonopolyMainCaption.<SetCurrencyItemList>d__14>(ref <SetCurrencyItemList>d__);
		return <SetCurrencyItemList>d__.<>t__builder.Task;
	}

	// Token: 0x06008385 RID: 33669 RVA: 0x0022BA1B File Offset: 0x00229C1B
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<CommonCurrencyItem> GetCurrencyItemList()
	{
		CommonCurrencyItemListComponent currencyItemListComponent = this.CurrencyItemListComponent;
		if (currencyItemListComponent == null)
		{
			return null;
		}
		return currencyItemListComponent.GetCurrencyItemList();
	}

	// Token: 0x06008386 RID: 33670 RVA: 0x0022BA30 File Offset: 0x00229C30
	public void SetCurrencyItemBtnFunction(int itemId, Action<int> callBack)
	{
		CommonCurrencyItemListComponent currencyItemListComponent = this.CurrencyItemListComponent;
		List<CommonCurrencyItem> list = (currencyItemListComponent != null) ? currencyItemListComponent.GetCurrencyItemList() : null;
		if (list != null)
		{
			foreach (CommonCurrencyItem commonCurrencyItem in list)
			{
				if (commonCurrencyItem.ItemId == itemId)
				{
					commonCurrencyItem.SetButtonFunction(callBack);
					break;
				}
			}
		}
	}

	// Token: 0x04003E7E RID: 15998
	[Nullable(2)]
	private CommonCurrencyItemListComponent CurrencyItemListComponent;

	// Token: 0x04003E7F RID: 15999
	[Nullable(2)]
	public Action OnCloseCallback;

	// Token: 0x04003E80 RID: 16000
	[Nullable(2)]
	public Action OnHelpCallback;

	// Token: 0x02007675 RID: 30325
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x04028D18 RID: 167192
		BtnClose,
		// Token: 0x04028D19 RID: 167193
		BtnHelp,
		// Token: 0x04028D1A RID: 167194
		CostContent
	}
}
