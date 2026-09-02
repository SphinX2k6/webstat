using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020010D4 RID: 4308
[NullableContext(1)]
[Nullable(0)]
public class GolemHackingMatrixPanel : UiPanelBase
{
	// Token: 0x06007043 RID: 28739 RVA: 0x001D4C60 File Offset: 0x001D2E60
	public GolemHackingMatrixPanel(GolemHackingGameProxy proxy)
	{
		this.Proxy = proxy;
	}

	// Token: 0x06007044 RID: 28740 RVA: 0x001D4C70 File Offset: 0x001D2E70
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007045 RID: 28741 RVA: 0x001D4D9F File Offset: 0x001D2F9F
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<GolemHackingMatrixVerticalPanel, List<GolemHackingGridInfo>>(base.GetHorizontalLayout(6), new Func<GolemHackingMatrixVerticalPanel>(this.CreateVertical), null, false, true);
		this.InitCallback();
		this.InitGamePlay();
		base.GetTexture(5).SetUIActive(false);
	}

	// Token: 0x06007046 RID: 28742 RVA: 0x001D4DDC File Offset: 0x001D2FDC
	protected void InitCallback()
	{
		this.Proxy.ResetMatrixCallback = new Action(this.ResetMatrixCallback);
		this.Proxy.StartMatrixTickCallback = delegate()
		{
			this.SetNeedTick(true);
		};
		this.Proxy.StopMatrixTickCallback = delegate()
		{
			this.SetNeedTick(false);
		};
		this.Proxy.HoverCodeCallback = new Action<string>(this.HoverCodeCallback);
		this.Proxy.UnHoverCodeCallback = new Action(this.UnHoverCodeCallback);
		this.Proxy.OnGetHelpTips = new Func<List<GolemHackingTipsGirdInfo>>(this.OnGetHelpTips);
	}

	// Token: 0x06007047 RID: 28743 RVA: 0x001D4E74 File Offset: 0x001D3074
	protected void InitGamePlay()
	{
		bool needTick = this.Proxy.GetNeedTick();
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(!needTick);
		}
		UUIItem item2 = base.GetItem(1);
		if (item2 != null)
		{
			item2.SetUIActive(needTick);
		}
		if (needTick)
		{
			UUISprite sprite = base.GetSprite(3);
			if (sprite != null)
			{
				sprite.SetFillAmount(1f);
			}
			this.SetTimeTxt(this.Proxy.GetMaxTime());
		}
		List<List<GolemHackingGridInfo>> gridInfoMatrix = this.Proxy.GetGridInfoMatrix();
		this.Layout.RefreshByData(gridInfoMatrix, delegate
		{
			this.UpdateBtnActiveState();
		}, false);
	}

	// Token: 0x06007048 RID: 28744 RVA: 0x001D4F08 File Offset: 0x001D3108
	protected void UpdateBtnActiveState()
	{
		foreach (GolemHackingMatrixVerticalPanel golemHackingMatrixVerticalPanel in this.Layout.GetLayoutItemList())
		{
			golemHackingMatrixVerticalPanel.UpdateBtnActiveState();
		}
	}

	// Token: 0x06007049 RID: 28745 RVA: 0x001D4F60 File Offset: 0x001D3160
	protected void OnUnHoverFakeHide(int index, bool reset = false)
	{
		foreach (GolemHackingMatrixVerticalPanel golemHackingMatrixVerticalPanel in this.Layout.GetLayoutItemList())
		{
			golemHackingMatrixVerticalPanel.OnUnHoverFakeHide(index, reset);
		}
	}

	// Token: 0x0600704A RID: 28746 RVA: 0x001D4FB8 File Offset: 0x001D31B8
	protected void OnHoverFakeVisible(int index)
	{
		foreach (GolemHackingMatrixVerticalPanel golemHackingMatrixVerticalPanel in this.Layout.GetLayoutItemList())
		{
			golemHackingMatrixVerticalPanel.OnHoverFakeVisible(index);
		}
	}

	// Token: 0x0600704B RID: 28747 RVA: 0x001D5010 File Offset: 0x001D3210
	private void SetTimeTxt(double second)
	{
		int num = (int)Math.Floor(Math.Floor(second) / 60.0);
		int num2 = (int)Math.Floor(second) % 60;
		int num3 = (int)Math.Floor(second * 100.0) % 100;
		string text;
		if (num < 10)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("0");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num);
			text = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		else
		{
			text = num.ToString();
		}
		string text2 = text;
		string text3;
		if (num2 < 10)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("0");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
			text3 = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		else
		{
			text3 = num2.ToString();
		}
		string text4 = text3;
		string text5;
		if (num3 < 10)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("0");
			defaultInterpolatedStringHandler.AppendFormatted<int>(num3);
			text5 = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		else
		{
			text5 = num3.ToString();
		}
		string text6 = text5;
		string newText = StringUtils.Format("{0}:{1}:{2}", new string[]
		{
			text2,
			text4,
			text6
		});
		UUIText text7 = base.GetText(2);
		if (text7 == null)
		{
			return;
		}
		text7.SetText(newText, true);
	}

	// Token: 0x0600704C RID: 28748 RVA: 0x001D5123 File Offset: 0x001D3323
	public void SetNeedTick(bool value)
	{
		this.NeedTick = value;
	}

	// Token: 0x0600704D RID: 28749 RVA: 0x001D512C File Offset: 0x001D332C
	[NullableContext(2)]
	public GolemHackingMatrixCodeButton GetCodeButtonByIndex(int index)
	{
		if (this.Layout.IsLock)
		{
			return null;
		}
		foreach (GolemHackingMatrixVerticalPanel golemHackingMatrixVerticalPanel in this.Layout.GetLayoutItemList())
		{
			GolemHackingMatrixCodeButton codeButtonByIndex = golemHackingMatrixVerticalPanel.GetCodeButtonByIndex(index);
			if (codeButtonByIndex != null)
			{
				return codeButtonByIndex;
			}
		}
		return null;
	}

	// Token: 0x0600704E RID: 28750 RVA: 0x001D519C File Offset: 0x001D339C
	[NullableContext(2)]
	public UUIItem GetCodeButtonNavListenerByIndex(int index)
	{
		GolemHackingMatrixCodeButton codeButtonByIndex = this.GetCodeButtonByIndex(index);
		if (codeButtonByIndex == null)
		{
			return null;
		}
		return codeButtonByIndex.GetFirstUiItemWithNavListener();
	}

	// Token: 0x0600704F RID: 28751 RVA: 0x001D51BC File Offset: 0x001D33BC
	[NullableContext(2)]
	public GolemHackingMatrixVerticalPanel GetVerticalPanelByIndex(int index)
	{
		if (this.Layout.IsLock)
		{
			return null;
		}
		return this.Layout.GetLayoutItemByIndex(index);
	}

	// Token: 0x06007050 RID: 28752 RVA: 0x001D51DC File Offset: 0x001D33DC
	public void OnTick(float delta)
	{
		if (!this.NeedTick)
		{
			return;
		}
		ValueTuple<double, double> valueTuple = this.Proxy.AddCurrentTime((double)delta);
		double item = valueTuple.Item1;
		double item2 = valueTuple.Item2;
		if (item2 <= 0.0)
		{
			return;
		}
		this.SetTimeTxt(item);
		UUISprite sprite = base.GetSprite(3);
		if (sprite != null)
		{
			sprite.SetFillAmount((float)(item / item2));
		}
		if (item <= 0.0)
		{
			this.SetNeedTick(false);
		}
	}

	// Token: 0x06007051 RID: 28753 RVA: 0x001D524C File Offset: 0x001D344C
	private GolemHackingMatrixVerticalPanel CreateVertical()
	{
		return new GolemHackingMatrixVerticalPanel(this.Proxy)
		{
			OnHoverCallback = new Action<int>(this.OnHoveredGrid),
			OnUnHoverCallback = new Action<int>(this.OnUnHoveredGrid),
			OnClickedCallback = new Action<int>(this.OnClickedGrid)
		};
	}

	// Token: 0x06007052 RID: 28754 RVA: 0x001D529C File Offset: 0x001D349C
	private void OnHoveredGrid(int index)
	{
		ValueTuple<int, bool> indexPos = this.Proxy.GetIndexPos(index);
		int item = indexPos.Item1;
		bool item2 = indexPos.Item2;
		this.OnHoverFakeVisible(index);
		base.GetTexture(5).SetUIActive(true);
		base.GetTexture(4).SetUIActive(true);
		if (item2)
		{
			base.GetTexture(5).SetAnchorOffsetX((float)(1 + 136 * item));
		}
		else
		{
			base.GetTexture(4).SetAnchorOffsetY((float)(-1 * (1 + 136 * item)));
		}
		this.UpdateBtnActiveState();
		this.Proxy.OnHoveredMatrixGrid(index);
	}

	// Token: 0x06007053 RID: 28755 RVA: 0x001D5328 File Offset: 0x001D3528
	private void OnUnHoveredGrid(int index)
	{
		bool item = this.Proxy.GetIndexPos(index).Item2;
		this.OnUnHoverFakeHide(index, false);
		if (item)
		{
			base.GetTexture(5).SetUIActive(false);
		}
		else
		{
			base.GetTexture(4).SetUIActive(false);
		}
		this.Proxy.OnUnHoveredMatrixGrid();
	}

	// Token: 0x06007054 RID: 28756 RVA: 0x001D5378 File Offset: 0x001D3578
	private void OnClickedGrid(int index)
	{
		ValueTuple<int, bool> valueTuple = this.Proxy.OnClickedGrid(index);
		int item = valueTuple.Item1;
		bool item2 = valueTuple.Item2;
		UUITexture texture = base.GetTexture(4);
		UUITexture texture2 = base.GetTexture(5);
		texture.SetHierarchyIndex((!item2) ? 1 : 0);
		texture2.SetHierarchyIndex((item2 > false) ? 1 : 0);
		FColor changeColor = texture.changeColor;
		FColor changeColor2 = texture2.changeColor;
		if (Singleton<Info>.Instance.IsMobileInputModel() && !Singleton<Info>.Instance.IsInGamepad())
		{
			texture.SetUIActive(item2);
			texture2.SetUIActive(!item2);
		}
		UUIItem uuiitem = texture;
		bool bUseChangeColor = !item2;
		FColor? fcolor = new FColor?(changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		UUIItem uuiitem2 = texture2;
		bool bUseChangeColor2 = item2;
		fcolor = new FColor?(changeColor2);
		uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
		if (!item2)
		{
			texture2.SetAnchorOffsetX((float)(1 + 136 * item));
			return;
		}
		texture.SetAnchorOffsetY((float)(-1 * (1 + 136 * item)));
	}

	// Token: 0x06007055 RID: 28757 RVA: 0x001D5450 File Offset: 0x001D3650
	private void ResetMatrixCallback()
	{
		this.SetNeedTick(false);
		UUITexture texture = base.GetTexture(4);
		UUITexture texture2 = base.GetTexture(5);
		texture.SetUIActive(true);
		texture2.SetUIActive(false);
		texture.SetAnchorOffsetY(-1f);
		texture.SetHierarchyIndex(0);
		texture2.SetHierarchyIndex(1);
		FColor changeColor = texture.changeColor;
		FColor changeColor2 = texture2.changeColor;
		UUIItem uuiitem = texture;
		bool bUseChangeColor = false;
		FColor? fcolor = new FColor?(changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		bool bUseChangeColor2 = true;
		fcolor = new FColor?(changeColor2);
		texture2.SetChangeColor(bUseChangeColor2, fcolor);
		List<List<GolemHackingGridInfo>> gridInfoMatrix = this.Proxy.GetGridInfoMatrix();
		this.Layout.RefreshByData(gridInfoMatrix, delegate
		{
			this.UpdateBtnActiveState();
		}, false);
		this.OnUnHoverFakeHide(0, true);
		UUISprite sprite = base.GetSprite(3);
		if (sprite != null)
		{
			sprite.SetFillAmount(1f);
		}
		this.SetTimeTxt(this.Proxy.GetMaxTime());
	}

	// Token: 0x06007056 RID: 28758 RVA: 0x001D5520 File Offset: 0x001D3720
	private void HoverCodeCallback(string value)
	{
		foreach (GolemHackingMatrixVerticalPanel golemHackingMatrixVerticalPanel in this.Layout.GetLayoutItemList())
		{
			golemHackingMatrixVerticalPanel.OnCodeHover(value);
		}
	}

	// Token: 0x06007057 RID: 28759 RVA: 0x001D5578 File Offset: 0x001D3778
	private void UnHoverCodeCallback()
	{
		foreach (GolemHackingMatrixVerticalPanel golemHackingMatrixVerticalPanel in this.Layout.GetLayoutItemList())
		{
			golemHackingMatrixVerticalPanel.OnCodeUnHover();
		}
	}

	// Token: 0x06007058 RID: 28760 RVA: 0x001D55D0 File Offset: 0x001D37D0
	private List<GolemHackingTipsGirdInfo> OnGetHelpTips()
	{
		Dictionary<int, GolemHackingMatrixCodeButton> dictionary = new Dictionary<int, GolemHackingMatrixCodeButton>();
		foreach (GolemHackingMatrixVerticalPanel golemHackingMatrixVerticalPanel in this.Layout.GetLayoutItemList())
		{
			foreach (GolemHackingMatrixCodeButton golemHackingMatrixCodeButton in golemHackingMatrixVerticalPanel.GetAllGrid())
			{
				dictionary[golemHackingMatrixCodeButton.CurData.Index] = golemHackingMatrixCodeButton;
			}
		}
		List<GolemHackingTipsGirdInfo> list = new List<GolemHackingTipsGirdInfo>();
		int padSize = this.Proxy.GetPadSize();
		for (int i = 0; i < this.Proxy.OfficialAnswer.Count; i++)
		{
			int num = this.Proxy.OfficialAnswer[i];
			GolemHackingMatrixCodeButton golemHackingMatrixCodeButton2 = dictionary[num];
			FVector lguispaceAbsolutePosition = golemHackingMatrixCodeButton2.GetRootItem().GetLGUISpaceAbsolutePosition();
			GolemHackingTipsGirdInfo item = new GolemHackingTipsGirdInfo
			{
				Index = num,
				NextIndex = ((i < this.Proxy.OfficialAnswer.Count - 1) ? this.Proxy.OfficialAnswer[i + 1] : -1),
				Size = padSize,
				Code = golemHackingMatrixCodeButton2.CurData.Code,
				PosX = lguispaceAbsolutePosition.X,
				PosY = lguispaceAbsolutePosition.Y,
				PosZ = lguispaceAbsolutePosition.Z
			};
			list.Add(item);
		}
		return list;
	}

	// Token: 0x04003608 RID: 13832
	private const int GRID_WIDTH = 136;

	// Token: 0x04003609 RID: 13833
	private const string TIME_STRING = "{0}:{1}:{2}";

	// Token: 0x0400360A RID: 13834
	protected GenericLayout<GolemHackingMatrixVerticalPanel, List<GolemHackingGridInfo>> Layout;

	// Token: 0x0400360B RID: 13835
	protected bool NeedTick;

	// Token: 0x0400360C RID: 13836
	protected GolemHackingGameProxy Proxy;

	// Token: 0x02007465 RID: 29797
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x040283C2 RID: 164802
		PanelProgressEmpty,
		// Token: 0x040283C3 RID: 164803
		PanelHackingTime,
		// Token: 0x040283C4 RID: 164804
		TxtTime,
		// Token: 0x040283C5 RID: 164805
		SpriteProgressFill,
		// Token: 0x040283C6 RID: 164806
		TexBgSelFrameH,
		// Token: 0x040283C7 RID: 164807
		TexBgSelFrameV,
		// Token: 0x040283C8 RID: 164808
		PanelHorizon,
		// Token: 0x040283C9 RID: 164809
		PanelVerticalItem
	}
}
