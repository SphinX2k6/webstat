using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020010D1 RID: 4305
[NullableContext(1)]
[Nullable(0)]
public class GolemHackingCodePanel : UiPanelBase
{
	// Token: 0x06007013 RID: 28691 RVA: 0x001D345A File Offset: 0x001D165A
	public GolemHackingCodePanel(GolemHackingGameProxy proxy)
	{
		this.Proxy = proxy;
	}

	// Token: 0x06007014 RID: 28692 RVA: 0x001D3470 File Offset: 0x001D1670
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnClickedHelp));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnClickedReset));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007015 RID: 28693 RVA: 0x001D3689 File Offset: 0x001D1889
	protected override void OnStart()
	{
		this.InitLayout();
		this.InitGamePlay();
		this.InitInfo();
	}

	// Token: 0x06007016 RID: 28694 RVA: 0x001D36A0 File Offset: 0x001D18A0
	protected void InitLayout()
	{
		this.CodeLayout = new GenericLayout<GolemHackingCodeKeyListItem, List<GolemHackingCodeGridInfo>>(base.GetVerticalLayout(0), new Func<GolemHackingCodeKeyListItem>(this.CreateCodePanelItem), null, false, true);
		this.IconLayout = new GenericLayout<GolemHackingCodeIconItem, EGolemHackingBarState>(base.GetVerticalLayout(3), new Func<GolemHackingCodeIconItem>(this.CreateIconItem), null, false, true);
		this.BarLayout = new GenericLayout<GolemHackingCodeKeyBarItem, EGolemHackingBarState>(base.GetVerticalLayout(5), new Func<GolemHackingCodeKeyBarItem>(this.CreateBarItem), null, false, true);
		this.InputLayout = new GenericLayout<GolemHackingCodeInputItem, GolemHackingInputInfo>(base.GetHorizontalLayout(8), new Func<GolemHackingCodeInputItem>(this.CreateInputItem), null, false, true);
	}

	// Token: 0x06007017 RID: 28695 RVA: 0x001D3734 File Offset: 0x001D1934
	protected void InitGamePlay()
	{
		this.Proxy.ResetCodeCallback = new Action(this.OnResetCallBack);
		this.Proxy.HoverMatrixCallback = new Action<int, string>(this.OnMatrixHoverCallBack);
		this.Proxy.UnHoverMatrixCallback = new Action(this.OnMatrixUnHoverCallBack);
		this.Proxy.EnterCodeCallback = new Action<List<string>, List<GolemHackingCodeEnterResult>>(this.OnMatrixEnterCallBack);
	}

	// Token: 0x06007018 RID: 28696 RVA: 0x001D37A0 File Offset: 0x001D19A0
	protected void InitInfo()
	{
		UUIButtonComponent button = base.GetButton(10);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(this.Proxy.NeedHelpBtn());
		}
		this.Proxy.InitCodePanelInfo();
	}

	// Token: 0x06007019 RID: 28697 RVA: 0x001D37E4 File Offset: 0x001D19E4
	protected void RefreshEnterPanel(List<string> inputList, List<GolemHackingCodeEnterResult> codeParam)
	{
		int maxLength = this.Proxy.GetMaxLength();
		UUIText text = base.GetText(7);
		if (text != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(inputList.Count);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(maxLength);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		int num = Math.Min(inputList.Count, maxLength - 1);
		UUITexture texture = base.GetTexture(1);
		if (texture != null)
		{
			texture.SetAnchorOffsetX((float)(9 + num * 133));
		}
		List<GolemHackingInputInfo> inputDataList = this.GetInputDataList(inputList, codeParam);
		foreach (GolemHackingCodeKeyListItem golemHackingCodeKeyListItem in this.CodeLayout.GetLayoutItemList())
		{
			golemHackingCodeKeyListItem.OnMatrixUnHover();
		}
		this.InputLayout.RefreshByData(inputDataList, null, false);
	}

	// Token: 0x0600701A RID: 28698 RVA: 0x001D38D0 File Offset: 0x001D1AD0
	protected List<GolemHackingInputInfo> GetInputDataList(List<string> inputList, List<GolemHackingCodeEnterResult> codeParam)
	{
		int maxLength = this.Proxy.GetMaxLength();
		List<GolemHackingInputInfo> list = new List<GolemHackingInputInfo>();
		bool isReset = this.Proxy.IsRestart && inputList.Count == 0;
		bool isFail = false;
		int num = 0;
		foreach (GolemHackingCodeEnterResult golemHackingCodeEnterResult in codeParam)
		{
			if (golemHackingCodeEnterResult.State == EGolemHackingBarState.Success)
			{
				num++;
			}
			else if (golemHackingCodeEnterResult.State == EGolemHackingBarState.Fail)
			{
				isFail = true;
				break;
			}
		}
		bool isSuccess = num == codeParam.Count;
		int animCount = 0;
		Action<GolemHackingInputInfo, int> action = delegate(GolemHackingInputInfo data, int index)
		{
			if (isSuccess | isFail | isReset)
			{
				data.AnimIndex = index + 1;
				if (isReset)
				{
					data.AnimName = "Reset";
					return;
				}
				int animCount;
				if (isSuccess)
				{
					animCount = animCount;
					animCount++;
					data.AnimName = "Success";
					return;
				}
				if (isFail)
				{
					animCount = animCount;
					animCount++;
					data.AnimName = "Fail";
				}
			}
		};
		for (int i = 0; i < 9; i++)
		{
			GolemHackingInputInfo golemHackingInputInfo = new GolemHackingInputInfo
			{
				Code = "",
				State = EGolemHackingInputState.Block,
				AnimIndex = 0,
				AnimName = ""
			};
			if (i < inputList.Count)
			{
				golemHackingInputInfo.Code = inputList[i];
				golemHackingInputInfo.State = EGolemHackingInputState.Occupy;
				action(golemHackingInputInfo, i);
			}
			else if (i == inputList.Count && i < maxLength)
			{
				golemHackingInputInfo.State = EGolemHackingInputState.Enterring;
				action(golemHackingInputInfo, i);
			}
			else if (i < maxLength)
			{
				golemHackingInputInfo.State = EGolemHackingInputState.Empty;
				action(golemHackingInputInfo, i);
			}
			list.Add(golemHackingInputInfo);
		}
		if (animCount > 0)
		{
			this.BarAnimCount = animCount;
		}
		return list;
	}

	// Token: 0x0600701B RID: 28699 RVA: 0x001D3A6C File Offset: 0x001D1C6C
	protected void RefreshCodePanel(List<GolemHackingCodeEnterResult> codeParam, bool needAnim)
	{
		List<EGolemHackingBarState> list = new List<EGolemHackingBarState>();
		List<List<GolemHackingCodeGridInfo>> list2 = new List<List<GolemHackingCodeGridInfo>>();
		int num = 0;
		int num2 = 0;
		foreach (GolemHackingCodeEnterResult golemHackingCodeEnterResult in codeParam)
		{
			list.Add(golemHackingCodeEnterResult.State);
			if (golemHackingCodeEnterResult.State != EGolemHackingBarState.Default)
			{
				num++;
			}
			if (golemHackingCodeEnterResult.State == EGolemHackingBarState.Fail)
			{
				num2++;
			}
			if (needAnim)
			{
				for (int i = 0; i < golemHackingCodeEnterResult.Code.Count; i++)
				{
					golemHackingCodeEnterResult.Code[i].AnimIndex = i + 1;
				}
			}
			list2.Add(golemHackingCodeEnterResult.Code);
		}
		if (num == codeParam.Count || num2 > 0)
		{
			if (this.BarAnimCount == -1)
			{
				this.BarAnimCount = 0;
			}
			this.BarAnimCount += ((num2 > 0) ? num2 : num);
			if (num2 > 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("IntrusionProtocol_InsufficientBufferTips", Array.Empty<object>());
			}
			Singleton<UiLayer>.Instance.SetShowNormalMaskLayer(true, "");
		}
		else
		{
			this.BarAnimCount = -1;
		}
		this.CodeLayout.RefreshByData(list2, null, false);
		this.BarLayout.RefreshByData(list, null, false);
		this.IconLayout.RefreshByData(list, null, false);
	}

	// Token: 0x0600701C RID: 28700 RVA: 0x001D3BBC File Offset: 0x001D1DBC
	private void OnClickedHelp()
	{
		List<GolemHackingTipsGirdInfo> helpTipsInfo = this.Proxy.GetHelpTipsInfo();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.GolemHackingGameTipsPopView, helpTipsInfo, null);
	}

	// Token: 0x0600701D RID: 28701 RVA: 0x001D3BE8 File Offset: 0x001D1DE8
	private void OnClickedReset()
	{
		double now = Singleton<Time>.Instance.Now;
		if (now - this.ResetTimeRecord < 400.0)
		{
			return;
		}
		this.ResetTimeRecord = now;
		this.Proxy.Reset();
	}

	// Token: 0x0600701E RID: 28702 RVA: 0x001D3C28 File Offset: 0x001D1E28
	private void OnMatrixHoverCallBack(int curIndex, string code)
	{
		foreach (GolemHackingCodeKeyListItem golemHackingCodeKeyListItem in this.CodeLayout.GetLayoutItemList())
		{
			golemHackingCodeKeyListItem.OnMatrixHover(curIndex, code);
		}
		GolemHackingCodeInputItem layoutItemByIndex = this.InputLayout.GetLayoutItemByIndex(curIndex);
		if (layoutItemByIndex == null)
		{
			return;
		}
		layoutItemByIndex.EnterInputCode(code);
	}

	// Token: 0x0600701F RID: 28703 RVA: 0x001D3C98 File Offset: 0x001D1E98
	private void OnMatrixUnHoverCallBack()
	{
		foreach (GolemHackingCodeKeyListItem golemHackingCodeKeyListItem in this.CodeLayout.GetLayoutItemList())
		{
			golemHackingCodeKeyListItem.OnMatrixUnHover();
		}
		foreach (GolemHackingCodeInputItem golemHackingCodeInputItem in this.InputLayout.GetLayoutItemList())
		{
			golemHackingCodeInputItem.ClearInputCode();
		}
	}

	// Token: 0x06007020 RID: 28704 RVA: 0x001D3D34 File Offset: 0x001D1F34
	private void OnMatrixEnterCallBack(List<string> curEnter, List<GolemHackingCodeEnterResult> codeParam)
	{
		this.RefreshEnterPanel(curEnter, codeParam);
		this.RefreshCodePanel(codeParam, curEnter.Count == 0);
	}

	// Token: 0x06007021 RID: 28705 RVA: 0x001D3D50 File Offset: 0x001D1F50
	private void OnResetCallBack()
	{
		UUIButtonComponent button = base.GetButton(10);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(this.Proxy.NeedHelpBtn());
		}
		this.Proxy.InitCodePanelInfo();
		UUITexture texture = base.GetTexture(1);
		if (texture != null)
		{
			texture.SetAnchorOffsetX(9f);
		}
		foreach (GolemHackingCodeKeyListItem golemHackingCodeKeyListItem in this.CodeLayout.GetLayoutItemList())
		{
			golemHackingCodeKeyListItem.OnMatrixUnHover();
		}
	}

	// Token: 0x06007022 RID: 28706 RVA: 0x001D3DF4 File Offset: 0x001D1FF4
	private void OnBarAnimEnd()
	{
		if (this.BarAnimCount == -1)
		{
			return;
		}
		this.BarAnimCount--;
		if (this.BarAnimCount == 0)
		{
			this.Proxy.OnOneTurnEndAfterAnim();
			Singleton<UiLayer>.Instance.SetShowNormalMaskLayer(false, "");
			this.BarAnimCount = -1;
		}
	}

	// Token: 0x06007023 RID: 28707 RVA: 0x001D3E43 File Offset: 0x001D2043
	private GolemHackingCodeKeyListItem CreateCodePanelItem()
	{
		return new GolemHackingCodeKeyListItem(this.Proxy);
	}

	// Token: 0x06007024 RID: 28708 RVA: 0x001D3E50 File Offset: 0x001D2050
	private GolemHackingCodeIconItem CreateIconItem()
	{
		return new GolemHackingCodeIconItem();
	}

	// Token: 0x06007025 RID: 28709 RVA: 0x001D3E57 File Offset: 0x001D2057
	private GolemHackingCodeKeyBarItem CreateBarItem()
	{
		return new GolemHackingCodeKeyBarItem
		{
			OnAnimEndCallback = new Action(this.OnBarAnimEnd)
		};
	}

	// Token: 0x06007026 RID: 28710 RVA: 0x001D3E70 File Offset: 0x001D2070
	private GolemHackingCodeInputItem CreateInputItem()
	{
		return new GolemHackingCodeInputItem
		{
			OnBarAnimEnd = new Action(this.OnBarAnimEnd)
		};
	}

	// Token: 0x06007027 RID: 28711 RVA: 0x001D3E89 File Offset: 0x001D2089
	[NullableContext(2)]
	public GolemHackingCodeKeyListItem GetHorizontalPanelByIndex(int index)
	{
		if (this.CodeLayout.IsLock)
		{
			return null;
		}
		return this.CodeLayout.GetLayoutItemByIndex(index);
	}

	// Token: 0x040035F3 RID: 13811
	private const int SCAN_INTERNAL = 133;

	// Token: 0x040035F4 RID: 13812
	private const int SCAN_START = 9;

	// Token: 0x040035F5 RID: 13813
	private const int RESET_COOLDOWN = 400;

	// Token: 0x040035F6 RID: 13814
	protected GenericLayout<GolemHackingCodeKeyListItem, List<GolemHackingCodeGridInfo>> CodeLayout;

	// Token: 0x040035F7 RID: 13815
	protected GenericLayout<GolemHackingCodeIconItem, EGolemHackingBarState> IconLayout;

	// Token: 0x040035F8 RID: 13816
	protected GenericLayout<GolemHackingCodeKeyBarItem, EGolemHackingBarState> BarLayout;

	// Token: 0x040035F9 RID: 13817
	protected GenericLayout<GolemHackingCodeInputItem, GolemHackingInputInfo> InputLayout;

	// Token: 0x040035FA RID: 13818
	protected int BarAnimCount = -1;

	// Token: 0x040035FB RID: 13819
	private double ResetTimeRecord;

	// Token: 0x040035FC RID: 13820
	protected GolemHackingGameProxy Proxy;

	// Token: 0x0200745F RID: 29791
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x04028394 RID: 164756
		PanelKeyList,
		// Token: 0x04028395 RID: 164757
		TexBgSelectFrame,
		// Token: 0x04028396 RID: 164758
		PanelHackingKeyGroup,
		// Token: 0x04028397 RID: 164759
		PanelLevelIcon,
		// Token: 0x04028398 RID: 164760
		SpriteLevel,
		// Token: 0x04028399 RID: 164761
		PanelStateList,
		// Token: 0x0402839A RID: 164762
		PanelStateBar,
		// Token: 0x0402839B RID: 164763
		TxtKeyCount,
		// Token: 0x0402839C RID: 164764
		PanelCodeGrid,
		// Token: 0x0402839D RID: 164765
		CodeItem,
		// Token: 0x0402839E RID: 164766
		BtnHelp,
		// Token: 0x0402839F RID: 164767
		BtnReset
	}
}
