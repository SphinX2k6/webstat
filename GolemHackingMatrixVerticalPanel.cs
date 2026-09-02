using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020010D5 RID: 4309
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class GolemHackingMatrixVerticalPanel : GridProxyAbstract<List<GolemHackingGridInfo>>
{
	// Token: 0x0600705D RID: 28765 RVA: 0x001D5786 File Offset: 0x001D3986
	public GolemHackingMatrixVerticalPanel(GolemHackingGameProxy proxy)
	{
		this.Proxy = proxy;
	}

	// Token: 0x0600705E RID: 28766 RVA: 0x001D5798 File Offset: 0x001D3998
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600705F RID: 28767 RVA: 0x001D5801 File Offset: 0x001D3A01
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<GolemHackingMatrixCodeButton, GolemHackingGridInfo>(base.GetVerticalLayout(0), new Func<GolemHackingMatrixCodeButton>(this.CreateGrid), null, false, true);
	}

	// Token: 0x06007060 RID: 28768 RVA: 0x001D5824 File Offset: 0x001D3A24
	public override void Refresh(List<GolemHackingGridInfo> data, bool isSelected, int gridIndex)
	{
		this.Layout.RefreshByData(data, null, false);
	}

	// Token: 0x06007061 RID: 28769 RVA: 0x001D5834 File Offset: 0x001D3A34
	public void OnCodeHover(string value)
	{
		foreach (GolemHackingMatrixCodeButton golemHackingMatrixCodeButton in this.Layout.GetLayoutItemList())
		{
			golemHackingMatrixCodeButton.OnCodeHover(value);
		}
	}

	// Token: 0x06007062 RID: 28770 RVA: 0x001D588C File Offset: 0x001D3A8C
	public void OnCodeUnHover()
	{
		foreach (GolemHackingMatrixCodeButton golemHackingMatrixCodeButton in this.Layout.GetLayoutItemList())
		{
			golemHackingMatrixCodeButton.OnCodeUnHover();
		}
	}

	// Token: 0x06007063 RID: 28771 RVA: 0x001D58E4 File Offset: 0x001D3AE4
	public void UpdateBtnActiveState()
	{
		foreach (GolemHackingMatrixCodeButton golemHackingMatrixCodeButton in this.Layout.GetLayoutItemList())
		{
			golemHackingMatrixCodeButton.UpdateBtnActiveState();
		}
	}

	// Token: 0x06007064 RID: 28772 RVA: 0x001D593C File Offset: 0x001D3B3C
	public void OnUnHoverFakeHide(int indexFake, bool fadeAll = false)
	{
		List<GolemHackingMatrixCodeButton> layoutItemList = this.Layout.GetLayoutItemList();
		int realHoverIndex = this.Proxy.GetRealHoverIndex(indexFake, false);
		if (!fadeAll && indexFake == realHoverIndex)
		{
			return;
		}
		foreach (GolemHackingMatrixCodeButton golemHackingMatrixCodeButton in layoutItemList)
		{
			if (golemHackingMatrixCodeButton.CurData.Index == realHoverIndex || fadeAll)
			{
				golemHackingMatrixCodeButton.SetHoverFakeVisibility(false);
			}
		}
	}

	// Token: 0x06007065 RID: 28773 RVA: 0x001D59C0 File Offset: 0x001D3BC0
	public void OnHoverFakeVisible(int indexFake)
	{
		List<GolemHackingMatrixCodeButton> layoutItemList = this.Layout.GetLayoutItemList();
		int realHoverIndex = this.Proxy.GetRealHoverIndex(indexFake, true);
		if (indexFake == realHoverIndex)
		{
			return;
		}
		foreach (GolemHackingMatrixCodeButton golemHackingMatrixCodeButton in layoutItemList)
		{
			if (golemHackingMatrixCodeButton.CurData.Index == realHoverIndex)
			{
				golemHackingMatrixCodeButton.SetHoverFakeVisibility(true);
			}
		}
	}

	// Token: 0x06007066 RID: 28774 RVA: 0x001D5A3C File Offset: 0x001D3C3C
	public List<GolemHackingMatrixCodeButton> GetAllGrid()
	{
		return this.Layout.GetLayoutItemList();
	}

	// Token: 0x06007067 RID: 28775 RVA: 0x001D5A4C File Offset: 0x001D3C4C
	[NullableContext(2)]
	public GolemHackingMatrixCodeButton GetCodeButtonByIndex(int index)
	{
		foreach (GolemHackingMatrixCodeButton golemHackingMatrixCodeButton in this.Layout.GetLayoutItemList())
		{
			if (golemHackingMatrixCodeButton.CurData.Index == index)
			{
				return golemHackingMatrixCodeButton;
			}
		}
		return null;
	}

	// Token: 0x06007068 RID: 28776 RVA: 0x001D5AB4 File Offset: 0x001D3CB4
	private GolemHackingMatrixCodeButton CreateGrid()
	{
		return new GolemHackingMatrixCodeButton(this.Proxy)
		{
			OnHoverCallback = this.OnHoverCallback,
			OnUnHoverCallback = this.OnUnHoverCallback,
			OnClickedCallback = this.OnClickedCallback
		};
	}

	// Token: 0x0400360D RID: 13837
	[Nullable(2)]
	public Action<int> OnHoverCallback;

	// Token: 0x0400360E RID: 13838
	[Nullable(2)]
	public Action<int> OnUnHoverCallback;

	// Token: 0x0400360F RID: 13839
	[Nullable(2)]
	public Action<int> OnClickedCallback;

	// Token: 0x04003610 RID: 13840
	protected GenericLayout<GolemHackingMatrixCodeButton, GolemHackingGridInfo> Layout;

	// Token: 0x04003611 RID: 13841
	protected GolemHackingGameProxy Proxy;

	// Token: 0x02007466 RID: 29798
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x040283CB RID: 164811
		Layout,
		// Token: 0x040283CC RID: 164812
		Item
	}
}
