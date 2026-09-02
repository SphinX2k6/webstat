using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.DeadRevive;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001241 RID: 4673
[NullableContext(2)]
[Nullable(0)]
public class BabelTowerReviveView : UiViewBase
{
	// Token: 0x06007C82 RID: 31874 RVA: 0x0020C0C5 File Offset: 0x0020A2C5
	[NullableContext(1)]
	public BabelTowerReviveView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06007C83 RID: 31875 RVA: 0x0020C0D0 File Offset: 0x0020A2D0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007C84 RID: 31876 RVA: 0x0020C244 File Offset: 0x0020A444
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerReviveView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerReviveView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007C85 RID: 31877 RVA: 0x0020C287 File Offset: 0x0020A487
	private void OnCancelButtonClick()
	{
		ControllerBase<BabelTowerController>.Instance.BabelTowerSettlementRequest();
		base.CloseMe(null);
	}

	// Token: 0x06007C86 RID: 31878 RVA: 0x0020C29C File Offset: 0x0020A49C
	private void OnConfirmButtonClick()
	{
		ControllerBase<DeadReviveController>.Instance.ReviveRequest(false, null, null);
		base.CloseMe(null);
	}

	// Token: 0x06007C87 RID: 31879 RVA: 0x0020C2C8 File Offset: 0x0020A4C8
	public void Refresh()
	{
		IBabelTowerReviveViewData data = this.Data;
		BabelTowerLevel value = ConfigBabelTowerLevelById.GetConfig(data.LevelId, true).Value;
		int starNum = data.StarNum;
		int reviveStar = value.ReviveStar;
		int num = Math.Max(0, starNum - reviveStar);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "Text_BabelTowerReviveStarsNeed_Text", new <>z__ReadOnlySingleElementList<object>(reviveStar));
		int passStar = value.PassStar;
		bool flag = num < passStar;
		base.GetItem(9).SetUIActive(flag);
		base.GetArtText(2).SetText(starNum.ToString());
		UUIArtText artText = base.GetArtText(3);
		artText.SetText(num.ToString());
		UUIItem uuiitem = artText;
		bool bUseChangeColor = !flag;
		FColor? fcolor = new FColor?(artText.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		int reviveBuffId = value.ReviveBuffId;
		BabelTowerBuffItemData data2 = new BabelTowerBuffItemData
		{
			Id = reviveBuffId,
			IsDeTerm = false,
			CanClick = false,
			ShowStar = new bool?(false)
		};
		this.BuffItem.Refresh(data2, false, 0);
		BabelTowerBuff value2 = ConfigBabelTowerBuffById.GetConfig(reviveBuffId, true).Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), value2.NameText, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), value2.DesText, Array.Empty<object>());
	}

	// Token: 0x04003B92 RID: 15250
	private IBabelTowerReviveViewData Data;

	// Token: 0x04003B93 RID: 15251
	private ButtonItem CancelButtonItem;

	// Token: 0x04003B94 RID: 15252
	private ButtonItem ConfirmButtonItem;

	// Token: 0x04003B95 RID: 15253
	private BabelTowerBuffItem BuffItem;

	// Token: 0x020075B1 RID: 30129
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x040289A1 RID: 166305
		public const int TitleText = 0;

		// Token: 0x040289A2 RID: 166306
		public const int TipText = 1;

		// Token: 0x040289A3 RID: 166307
		public const int SrcArtText = 2;

		// Token: 0x040289A4 RID: 166308
		public const int DestArtText = 3;

		// Token: 0x040289A5 RID: 166309
		public const int BuffItem = 4;

		// Token: 0x040289A6 RID: 166310
		public const int BuffNameText = 5;

		// Token: 0x040289A7 RID: 166311
		public const int BuffDescText = 6;

		// Token: 0x040289A8 RID: 166312
		public const int CancelButtonItem = 7;

		// Token: 0x040289A9 RID: 166313
		public const int ConfirmButtonItem = 8;

		// Token: 0x040289AA RID: 166314
		public const int LowStarTipItem = 9;
	}
}
