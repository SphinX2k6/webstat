using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C6F RID: 7279
public class FloroRanchTechDetailPanel : UiPanelBase
{
	// Token: 0x0600D471 RID: 54385 RVA: 0x0038B0F8 File Offset: 0x003892F8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D472 RID: 54386 RVA: 0x0038B26C File Offset: 0x0038946C
	protected override void OnStart()
	{
		TermExplanationRegistryParam param = new TermExplanationRegistryParam
		{
			UiText = base.GetText(2),
			ViewType = ETermExplanationViewType.Side,
			AttachDirection = new ETermExplanationViewAttachDirection?(ETermExplanationViewAttachDirection.Left),
			AttachItem = base.GetRootItem(),
			Style = new ETermExplanationViewStyle?(ETermExplanationViewStyle.FloroRanch),
			ReportType = ETermExplanationReportType.FloroRanch
		};
		ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
		this.UnlockBtn = new ButtonItem(base.GetItem(4));
		this.UnlockBtn.SetFunction(new Action<int>(this.OnClickBtnUnlock));
	}

	// Token: 0x0600D473 RID: 54387 RVA: 0x0038B2F3 File Offset: 0x003894F3
	protected override void OnBeforeDestroy()
	{
		ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(2));
	}

	// Token: 0x0600D474 RID: 54388 RVA: 0x0038B308 File Offset: 0x00389508
	[NullableContext(1)]
	public void Refresh(FloroRanchTechnologyData data)
	{
		this.Data = data;
		this.SetSpriteByPath(data.Icon, base.GetSprite(1), false, null, null);
		UUISprite sprite = base.GetSprite(1);
		UUIItem uuiitem = sprite;
		bool bUseChangeColor = !data.IsUnLock;
		FColor? fcolor = new FColor?(sprite.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Name, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.Des, Array.Empty<object>());
		global::FloroRanchActivityData activityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(EFloroRanchActivityDataType.Normal, true);
		int technologyCoinNum = activityData.GetTechnologyCoinNum();
		UUIText text = base.GetText(3);
		text.SetText(data.Cost.ToString(), true);
		UUIItem uuiitem2 = text;
		bool bUseChangeColor2 = technologyCoinNum < data.Cost;
		fcolor = new FColor?(text.changeColor);
		uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
		base.GetItem(7).SetUIActive(!data.IsUnLock);
		bool flag = activityData.IsPreNodeAllUnlock(data);
		ButtonItem unlockBtn = this.UnlockBtn;
		if (unlockBtn != null)
		{
			unlockBtn.SetUiActive(!data.IsUnLock && flag);
		}
		ButtonItem unlockBtn2 = this.UnlockBtn;
		if (unlockBtn2 != null)
		{
			unlockBtn2.SetRedDotVisible(technologyCoinNum >= data.Cost && !data.IsUnLock && flag);
		}
		base.GetItem(6).SetUIActive(!flag);
		base.GetItem(5).SetUIActive(data.IsUnLock);
		UUISprite sprite2 = base.GetSprite(8);
		if (sprite2 != null)
		{
			sprite2.SetUIActive(data.IsUnLock);
		}
		UUISprite sprite3 = base.GetSprite(9);
		if (sprite3 == null)
		{
			return;
		}
		sprite3.SetUIActive(!data.IsUnLock);
	}

	// Token: 0x0600D475 RID: 54389 RVA: 0x0038B4A0 File Offset: 0x003896A0
	private void OnClickBtnUnlock(int _)
	{
		if (ModelBase<FloroRanchModel>.Instance.GetActivityData(EFloroRanchActivityDataType.Normal, true).GetTechnologyCoinNum() < this.Data.Cost)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_200003_Text", Array.Empty<object>());
			return;
		}
		ControllerBase<FloroRanchController>.Instance.RequestUnlockTechPoint(this.Data.Id, delegate(FloroRanchUnlockTechPointResponse response)
		{
			this.Refresh(this.Data);
			Action<string> unlockSuccessCallback = this.UnlockSuccessCallback;
			if (unlockSuccessCallback == null)
			{
				return;
			}
			unlockSuccessCallback(this.Data.Des);
		});
	}

	// Token: 0x04006511 RID: 25873
	[Nullable(2)]
	public FloroRanchTechnologyData Data;

	// Token: 0x04006512 RID: 25874
	[Nullable(2)]
	private ButtonItem UnlockBtn;

	// Token: 0x04006513 RID: 25875
	[Nullable(1)]
	public Action<string> UnlockSuccessCallback = delegate(string textId)
	{
	};

	// Token: 0x02007F98 RID: 32664
	private class EComponents
	{
		// Token: 0x0402B709 RID: 177929
		public const int TxtName = 0;

		// Token: 0x0402B70A RID: 177930
		public const int SpriteIcon = 1;

		// Token: 0x0402B70B RID: 177931
		public const int TxtDesc = 2;

		// Token: 0x0402B70C RID: 177932
		public const int TxtCost = 3;

		// Token: 0x0402B70D RID: 177933
		public const int ItemUnlockBtn = 4;

		// Token: 0x0402B70E RID: 177934
		public const int ItemUnlockPanel = 5;

		// Token: 0x0402B70F RID: 177935
		public const int ItemLockPanel = 6;

		// Token: 0x0402B710 RID: 177936
		public const int PanelCost = 7;

		// Token: 0x0402B711 RID: 177937
		public const int SpriteIconBg = 8;

		// Token: 0x0402B712 RID: 177938
		public const int SpriteIconBgLock = 9;
	}
}
