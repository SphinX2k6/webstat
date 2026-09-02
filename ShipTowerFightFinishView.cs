using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029B7 RID: 10679
[NullableContext(2)]
[Nullable(0)]
public class ShipTowerFightFinishView : UiViewBase
{
	// Token: 0x060154CE RID: 87246 RVA: 0x005E75ED File Offset: 0x005E57ED
	[NullableContext(1)]
	public ShipTowerFightFinishView(UiViewInfo ViewInfo) : base(ViewInfo)
	{
	}

	// Token: 0x060154CF RID: 87247 RVA: 0x005E75F8 File Offset: 0x005E57F8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060154D0 RID: 87248 RVA: 0x005E7749 File Offset: 0x005E5949
	private void InitDataParam()
	{
	}

	// Token: 0x060154D1 RID: 87249 RVA: 0x005E774C File Offset: 0x005E594C
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerFightFinishView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerFightFinishView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060154D2 RID: 87250 RVA: 0x005E778F File Offset: 0x005E598F
	protected override void OnBeforeShow()
	{
		this.UpdateData();
	}

	// Token: 0x060154D3 RID: 87251 RVA: 0x005E7797 File Offset: 0x005E5997
	[NullableContext(1)]
	private ShipTowerFightFinishItem CreateItem()
	{
		return new ShipTowerFightFinishItem();
	}

	// Token: 0x060154D4 RID: 87252 RVA: 0x005E77A0 File Offset: 0x005E59A0
	private void UpdateData()
	{
		ShipTowerFightFinishViewParams shipTowerFightFinishViewParams = this.OpenParam as ShipTowerFightFinishViewParams;
		GenericLayout<ShipTowerFightFinishItem, ShipTowerFightFinishItemData> areaLayout = this.AreaLayout;
		if (areaLayout != null)
		{
			areaLayout.RefreshByData(((shipTowerFightFinishViewParams != null) ? shipTowerFightFinishViewParams.AreaList : null) ?? new List<ShipTowerFightFinishItemData>(), null, false);
		}
		base.GetText(3).SetText(this.GetTotalScore().ToString(), true);
		UUITexture texture = base.GetTexture(4);
		bool flag = ((shipTowerFightFinishViewParams != null) ? shipTowerFightFinishViewParams.GradeResId : null) != null;
		texture.SetUIActive(flag);
		if (flag)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(shipTowerFightFinishViewParams.GradeResId);
			base.SetTextureByPath(resourcePath, texture, null, null);
		}
		base.GetItem(2).SetUIActive(shipTowerFightFinishViewParams != null && shipTowerFightFinishViewParams.IsNewRecord);
		bool flag2 = shipTowerFightFinishViewParams != null && shipTowerFightFinishViewParams.IsEndless && this.GetTotalScore() > 0;
		ShareBtnItem shareBtnItem = this.ShareBtnItem;
		if (shareBtnItem != null)
		{
			shareBtnItem.SetUiActive(flag2);
		}
		if (flag2)
		{
			ShareBtnItem shareBtnItem2 = this.ShareBtnItem;
			if (shareBtnItem2 != null)
			{
				shareBtnItem2.SetShareActionId(EShareActionId.ChallengeRecord);
			}
		}
		this.UpdateBtn();
	}

	// Token: 0x060154D5 RID: 87253 RVA: 0x005E78A4 File Offset: 0x005E5AA4
	private int GetTotalScore()
	{
		ShipTowerFightFinishViewParams shipTowerFightFinishViewParams = this.OpenParam as ShipTowerFightFinishViewParams;
		if (shipTowerFightFinishViewParams == null)
		{
			return 0;
		}
		if (shipTowerFightFinishViewParams.TotalScore != 0)
		{
			return shipTowerFightFinishViewParams.TotalScore;
		}
		return shipTowerFightFinishViewParams.AreaList.Sum((ShipTowerFightFinishItemData x) => x.ScoreA + x.ScoreB);
	}

	// Token: 0x060154D6 RID: 87254 RVA: 0x005E78FC File Offset: 0x005E5AFC
	private void OnBtnLeftClicked()
	{
		IRewardExploreConfirmButton btnLeftInfo = this.BtnLeftInfo;
		if (((btnLeftInfo != null) ? btnLeftInfo.OnClickedCallback : null) != null)
		{
			this.BtnLeftInfo.OnClickedCallback(0);
		}
		if (this.BtnLeftInfo != null && this.BtnLeftInfo.IsClickedCloseView)
		{
			base.CloseMe(null);
		}
	}

	// Token: 0x060154D7 RID: 87255 RVA: 0x005E794C File Offset: 0x005E5B4C
	private void OnBtnRightClicked()
	{
		IRewardExploreConfirmButton btnRightInfo = this.BtnRightInfo;
		if (((btnRightInfo != null) ? btnRightInfo.OnClickedCallback : null) != null)
		{
			this.BtnRightInfo.OnClickedCallback(1);
		}
		if (this.BtnRightInfo != null && this.BtnRightInfo.IsClickedCloseView)
		{
			base.CloseMe(null);
		}
	}

	// Token: 0x060154D8 RID: 87256 RVA: 0x005E799C File Offset: 0x005E5B9C
	private UniTask OnShareBtnClickedAsync()
	{
		ShipTowerFightFinishView.<OnShareBtnClickedAsync>d__18 <OnShareBtnClickedAsync>d__;
		<OnShareBtnClickedAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnShareBtnClickedAsync>d__.<>4__this = this;
		<OnShareBtnClickedAsync>d__.<>1__state = -1;
		<OnShareBtnClickedAsync>d__.<>t__builder.Start<ShipTowerFightFinishView.<OnShareBtnClickedAsync>d__18>(ref <OnShareBtnClickedAsync>d__);
		return <OnShareBtnClickedAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060154D9 RID: 87257 RVA: 0x005E79E0 File Offset: 0x005E5BE0
	private unsafe void UpdateBtn()
	{
		UUIText text = base.GetText(7);
		<>y__InlineArray2<ButtonItem> <>y__InlineArray = default(<>y__InlineArray2<ButtonItem>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ButtonItem>, ButtonItem>(ref <>y__InlineArray, 0) = this.BtnLeft;
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ButtonItem>, ButtonItem>(ref <>y__InlineArray, 1) = this.BtnRight;
		Span<ButtonItem> span = <PrivateImplementationDetails>.InlineArrayAsSpan<<>y__InlineArray2<ButtonItem>, ButtonItem>(ref <>y__InlineArray, 2);
		<>y__InlineArray2<UUIText> <>y__InlineArray2 = default(<>y__InlineArray2<UUIText>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<UUIText>, UUIText>(ref <>y__InlineArray2, 0) = null;
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<UUIText>, UUIText>(ref <>y__InlineArray2, 1) = text;
		Span<UUIText> span2 = <PrivateImplementationDetails>.InlineArrayAsSpan<<>y__InlineArray2<UUIText>, UUIText>(ref <>y__InlineArray2, 2);
		ShipTowerFightFinishViewParams shipTowerFightFinishViewParams = this.OpenParam as ShipTowerFightFinishViewParams;
		for (int i = 0; i < span.Length; i++)
		{
			ButtonItem buttonItem = *span[i];
			IRewardExploreConfirmButton rewardExploreConfirmButton = (shipTowerFightFinishViewParams != null) ? shipTowerFightFinishViewParams.ButtonList[i] : null;
			if (rewardExploreConfirmButton != null)
			{
				if (buttonItem != null)
				{
					buttonItem.SetShowText(rewardExploreConfirmButton.ButtonTextId);
				}
				string descriptionTextId = rewardExploreConfirmButton.DescriptionTextId;
				if (descriptionTextId != null)
				{
					List<object> descriptionArgs = rewardExploreConfirmButton.DescriptionArgs;
					if (descriptionArgs != null && descriptionArgs.Count > 0)
					{
						object[] array = new object[descriptionArgs.Count];
						for (int j = 0; j < descriptionArgs.Count; j++)
						{
							array[j] = descriptionArgs[j];
						}
						Singleton<LguiUtil>.Instance.SetLocalTextNew(*span2[i], descriptionTextId, array);
					}
					else
					{
						Singleton<LguiUtil>.Instance.SetLocalTextNew(*span2[i], descriptionTextId, Array.Empty<object>());
					}
				}
				UUIText uuitext = *span2[i];
				if (uuitext != null)
				{
					uuitext.SetUIActive(descriptionTextId != null);
				}
			}
			if (buttonItem != null)
			{
				buttonItem.SetActive(rewardExploreConfirmButton != null);
			}
		}
		this.BtnLeftInfo = ((shipTowerFightFinishViewParams != null) ? shipTowerFightFinishViewParams.ButtonList.GetValueOrDefault(0) : null);
		this.BtnRightInfo = ((shipTowerFightFinishViewParams != null) ? shipTowerFightFinishViewParams.ButtonList.GetValueOrDefault(1) : null);
	}

	// Token: 0x0400A432 RID: 42034
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ShipTowerFightFinishItem, ShipTowerFightFinishItemData> AreaLayout;

	// Token: 0x0400A433 RID: 42035
	private ButtonItem BtnLeft;

	// Token: 0x0400A434 RID: 42036
	private ButtonItem BtnRight;

	// Token: 0x0400A435 RID: 42037
	private ShareBtnItem ShareBtnItem;

	// Token: 0x0400A436 RID: 42038
	private IRewardExploreConfirmButton BtnLeftInfo;

	// Token: 0x0400A437 RID: 42039
	private IRewardExploreConfirmButton BtnRightInfo;

	// Token: 0x0400A438 RID: 42040
	private ShipTowerStageData StageData;

	// Token: 0x02008D0D RID: 36109
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F72F RID: 194351
		public const int VLayoutContainer = 0;

		// Token: 0x0402F730 RID: 194352
		public const int ItemArea = 1;

		// Token: 0x0402F731 RID: 194353
		public const int ItemNewRecord = 2;

		// Token: 0x0402F732 RID: 194354
		public const int TextScore = 3;

		// Token: 0x0402F733 RID: 194355
		public const int TextureGrade = 4;

		// Token: 0x0402F734 RID: 194356
		public const int BtnRight = 5;

		// Token: 0x0402F735 RID: 194357
		public const int BtnLeft = 6;

		// Token: 0x0402F736 RID: 194358
		public const int TextRightBtnDesc = 7;

		// Token: 0x0402F737 RID: 194359
		public const int ShareItem = 8;
	}
}
