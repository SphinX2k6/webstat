using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.BlackScreen;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002A32 RID: 10802
public class FlySkinObtainView : UiViewBase
{
	// Token: 0x06015998 RID: 88472 RVA: 0x005FC801 File Offset: 0x005FAA01
	[NullableContext(1)]
	public FlySkinObtainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015999 RID: 88473 RVA: 0x005FC830 File Offset: 0x005FAA30
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(USpineSkeletonAnimationComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBackBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickConfirmBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601599A RID: 88474 RVA: 0x005FCA6C File Offset: 0x005FAC6C
	protected override void OnStart()
	{
		this.ItemLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(4), this.InitGridItem, null, false, true);
		FlySkinObtainViewData flySkinObtainViewData = this.OpenParam as FlySkinObtainViewData;
		foreach (RewardItemData rewardItemData in flySkinObtainViewData.ObtainFlySkinData)
		{
			FlySkinData flySkinData = ModelBase<FlySkinModel>.Instance.GetFlySkinData(rewardItemData.ConfigId);
			if (flySkinData != null && flySkinData.GetFlySkinConfig().SkinType == 1)
			{
				this.ObtainFlySkinData = flySkinData;
				break;
			}
		}
		List<RewardItemData> otherRewardData = flySkinObtainViewData.OtherRewardData;
		if (otherRewardData != null)
		{
			this.ExtraRewardData = new List<TItem>();
			foreach (RewardItemData rewardItemData2 in otherRewardData)
			{
				InventoryDefine.GetItemData itemData = new InventoryDefine.GetItemData(rewardItemData2.ConfigId, 0);
				int count = 0;
				if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(rewardItemData2.ConfigId)) == InventoryDefine.EItemDataType.VirtualItem)
				{
					count = rewardItemData2.Count;
				}
				TItem item = new TItem(itemData, count);
				this.ExtraRewardData.Add(item);
			}
		}
	}

	// Token: 0x0601599B RID: 88475 RVA: 0x005FCBB0 File Offset: 0x005FADB0
	protected override void OnBeforeShow()
	{
		if (this.ObtainFlySkinData == null)
		{
			return;
		}
		base.GetSpine(1).SetActive(false, false);
		UUIButtonComponent button = base.GetButton(7);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(false);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), this.ObtainFlySkinData.GetTitleName(), Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), this.ObtainFlySkinData.GetSubTitle(), Array.Empty<object>());
		base.SetTextureByPath(this.ObtainFlySkinData.GetTextureInSkinObtainView(), base.GetTexture(10), null, null);
		string hexStr = this.ObtainFlySkinData.GetObtainFrameColor1();
		base.GetTexture(8).SetColor(FColor.FromHex(hexStr));
		hexStr = this.ObtainFlySkinData.GetObtainFrameColor2();
		base.GetTexture(9).SetColor(FColor.FromHex(hexStr));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), "ObtainFlySkin", Array.Empty<object>());
		this.RefreshLayout();
	}

	// Token: 0x0601599C RID: 88476 RVA: 0x005FCCB8 File Offset: 0x005FAEB8
	private void RefreshLayout()
	{
		if (this.ExtraRewardData == null)
		{
			UUIItem item = base.GetItem(11);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
			return;
		}
		else
		{
			List<TItem> extraRewardData = this.ExtraRewardData;
			UUIItem item2 = base.GetItem(11);
			if (item2 != null)
			{
				item2.SetUIActive(extraRewardData.Count != 0);
			}
			GenericLayout<CommonItemSmallItemGrid, TItem> itemLayout = this.ItemLayout;
			if (itemLayout == null)
			{
				return;
			}
			itemLayout.RefreshByData(extraRewardData, null, false);
			return;
		}
	}

	// Token: 0x0601599D RID: 88477 RVA: 0x005FCD17 File Offset: 0x005FAF17
	private void OnClickBackBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0601599E RID: 88478 RVA: 0x005FCD20 File Offset: 0x005FAF20
	private void OnClickConfirmBtn()
	{
		ControllerBase<BlackScreenController>.Instance.AddBlackScreenAsync("Start", "OpenRoleSkinView", "Black");
		base.CloseMe(delegate(bool _)
		{
			int num = ModelBase<RoleModel>.Instance.GetRoleSystemRoleList(false)[0];
			SkinController instance = ControllerBase<SkinController>.Instance;
			int roleId = num;
			EUiTabViewName flySkinTabView = EUiTabViewName.FlySkinTabView;
			bool needLoadRole = true;
			int selectRoleSkinId = -1;
			TOpenViewCallBack finishCallback = delegate(bool success, int viewId)
			{
				ControllerBase<BlackScreenController>.Instance.RemoveBlackScreen("Close", "OpenRoleSkinView");
			};
			FlySkinData obtainFlySkinData = this.ObtainFlySkinData;
			instance.SkipToSkinView(roleId, flySkinTabView, needLoadRole, selectRoleSkinId, finishCallback, (obtainFlySkinData != null) ? new int?(obtainFlySkinData.GetItemId()) : null, null);
		});
	}

	// Token: 0x0400A61B RID: 42523
	[Nullable(2)]
	private FlySkinData ObtainFlySkinData;

	// Token: 0x0400A61C RID: 42524
	[Nullable(2)]
	private List<TItem> ExtraRewardData;

	// Token: 0x0400A61D RID: 42525
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> ItemLayout;

	// Token: 0x0400A61E RID: 42526
	[Nullable(1)]
	private readonly Func<CommonItemSmallItemGrid> InitGridItem = () => new CommonItemSmallItemGrid();

	// Token: 0x02008DAC RID: 36268
	private enum EComponent
	{
		// Token: 0x0402FA7B RID: 195195
		BackBtn,
		// Token: 0x0402FA7C RID: 195196
		TextureSpine,
		// Token: 0x0402FA7D RID: 195197
		TitleText,
		// Token: 0x0402FA7E RID: 195198
		TitleSubText,
		// Token: 0x0402FA7F RID: 195199
		HorizontalLayout,
		// Token: 0x0402FA80 RID: 195200
		RewardItem,
		// Token: 0x0402FA81 RID: 195201
		ConfirmBtn,
		// Token: 0x0402FA82 RID: 195202
		ShareBtn,
		// Token: 0x0402FA83 RID: 195203
		FrameTexture1,
		// Token: 0x0402FA84 RID: 195204
		FrameTexture2,
		// Token: 0x0402FA85 RID: 195205
		TextureImage,
		// Token: 0x0402FA86 RID: 195206
		ItemRewardPanel,
		// Token: 0x0402FA87 RID: 195207
		TextObtainTip
	}
}
