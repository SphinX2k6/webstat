using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001370 RID: 4976
[NullableContext(1)]
[Nullable(0)]
public class LordGymBossCard : UiPanelBase
{
	// Token: 0x06008868 RID: 34920 RVA: 0x0023F8C0 File Offset: 0x0023DAC0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIGridLayout))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.MoveToLeft)),
			new ValueTuple<int, Delegate>(5, new Action(this.MoveToRight))
		};
	}

	// Token: 0x06008869 RID: 34921 RVA: 0x0023F9C4 File Offset: 0x0023DBC4
	protected override void OnStart()
	{
		UUIButtonComponent button = base.GetButton(4);
		TWeakObjectPtr<UUIItem>? tweakObjectPtr = (button != null) ? new TWeakObjectPtr<UUIItem>?(button.RootUIComp) : null;
		this.LeftBtn = ((tweakObjectPtr != null) ? tweakObjectPtr.GetValueOrDefault() : null);
		UUIButtonComponent button2 = base.GetButton(5);
		tweakObjectPtr = ((button2 != null) ? new TWeakObjectPtr<UUIItem>?(button2.RootUIComp) : null);
		this.RightBtn = ((tweakObjectPtr != null) ? tweakObjectPtr.GetValueOrDefault() : null);
		UUIItem item = base.GetItem(0);
		this.CircleExhibitionView = new CircleAttachView<int, LordGymBossCardItem>((item != null) ? item.GetOwner() : null, false);
		AutoAttachBaseView<int, LordGymBossCardItem> circleExhibitionView = this.CircleExhibitionView;
		UUIItem item2 = base.GetItem(1);
		circleExhibitionView.CreateItems((item2 != null) ? item2.GetOwner() : null, 4f, new Func<AActor, int, int, LordGymBossCardItem>(this.InitGrid), EAttachDirection.Horizontal);
		this.CircleExhibitionView.SetDragBeginCallback(new Action(this.HideSwitchBtn));
		this.CircleExhibitionView.SetPageLimitState(true);
		this.CircleExhibitionView.SetMoveMultiFactor(50f);
		this.PageDotLayout = new GenericLayout<LordGymPageDot, int>(base.GetGridLayout(8), new Func<LordGymPageDot>(this.InitPageDot), null, false, true);
	}

	// Token: 0x0600886A RID: 34922 RVA: 0x0023FAF2 File Offset: 0x0023DCF2
	private void HideSwitchBtn()
	{
		UUIItem rightBtn = this.RightBtn;
		if (rightBtn != null)
		{
			rightBtn.SetUIActive(false);
		}
		UUIItem leftBtn = this.LeftBtn;
		if (leftBtn == null)
		{
			return;
		}
		leftBtn.SetUIActive(false);
	}

	// Token: 0x0600886B RID: 34923 RVA: 0x0023FB18 File Offset: 0x0023DD18
	public void Refresh(List<int> ids)
	{
		if (this.CircleExhibitionView == null || this.PageDotLayout == null)
		{
			return;
		}
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(ids.Count > 1);
		}
		this.CircleExhibitionView.ReloadView(ids.Count, ids.ToArray(), 0);
		if (ids.Count > 1)
		{
			this.CircleExhibitionView.EnableDragEvent();
			int index = this.PageDotLayout.GetSelectedGridIndex();
			this.PageDotLayout.RefreshByData(ids, delegate
			{
				GenericLayout<LordGymPageDot, int> pageDotLayout = this.PageDotLayout;
				if (pageDotLayout == null)
				{
					return;
				}
				pageDotLayout.SelectGridProxy((index < 0) ? 0 : index, true);
			}, false);
		}
		else
		{
			this.CircleExhibitionView.DisableDragEvent();
		}
		UUIItem item2 = base.GetItem(1);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x0600886C RID: 34924 RVA: 0x0023FBD3 File Offset: 0x0023DDD3
	private LordGymPageDot InitPageDot()
	{
		return new LordGymPageDot();
	}

	// Token: 0x0600886D RID: 34925 RVA: 0x0023FBDA File Offset: 0x0023DDDA
	private LordGymBossCardItem InitGrid(AActor actor, int index, int showNum)
	{
		LordGymBossCardItem lordGymBossCardItem = new LordGymBossCardItem(actor);
		lordGymBossCardItem.BindOnSelected(new Action<int>(this.OnItemSelected));
		return lordGymBossCardItem;
	}

	// Token: 0x0600886E RID: 34926 RVA: 0x0023FBF4 File Offset: 0x0023DDF4
	private void OnItemSelected(int index)
	{
		GenericLayout<LordGymPageDot, int> pageDotLayout = this.PageDotLayout;
		if (pageDotLayout != null)
		{
			pageDotLayout.SelectGridProxy(index, true);
		}
		UUIItem rightBtn = this.RightBtn;
		if (rightBtn != null)
		{
			rightBtn.SetUIActive(true);
		}
		UUIItem leftBtn = this.LeftBtn;
		if (leftBtn == null)
		{
			return;
		}
		leftBtn.SetUIActive(true);
	}

	// Token: 0x0600886F RID: 34927 RVA: 0x0023FC2C File Offset: 0x0023DE2C
	private void MoveToLeft()
	{
		CircleAttachView<int, LordGymBossCardItem> circleExhibitionView = this.CircleExhibitionView;
		if (circleExhibitionView == null)
		{
			return;
		}
		circleExhibitionView.MoveToNextItem(-1);
	}

	// Token: 0x06008870 RID: 34928 RVA: 0x0023FC3F File Offset: 0x0023DE3F
	private void MoveToRight()
	{
		CircleAttachView<int, LordGymBossCardItem> circleExhibitionView = this.CircleExhibitionView;
		if (circleExhibitionView == null)
		{
			return;
		}
		circleExhibitionView.MoveToNextItem(1);
	}

	// Token: 0x0400401E RID: 16414
	private const int SHOW_GAP = 4;

	// Token: 0x0400401F RID: 16415
	private CircleAttachView<int, LordGymBossCardItem> CircleExhibitionView;

	// Token: 0x04004020 RID: 16416
	private GenericLayout<LordGymPageDot, int> PageDotLayout;

	// Token: 0x04004021 RID: 16417
	[Nullable(2)]
	private UUIItem LeftBtn;

	// Token: 0x04004022 RID: 16418
	[Nullable(2)]
	private UUIItem RightBtn;
}
