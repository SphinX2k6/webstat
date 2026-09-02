using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.BlackScreen;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002A3F RID: 10815
[NullableContext(2)]
[Nullable(0)]
public class SkinObtainView : UiViewBase
{
	// Token: 0x06015A79 RID: 88697 RVA: 0x00602EEE File Offset: 0x006010EE
	[NullableContext(1)]
	public SkinObtainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015A7A RID: 88698 RVA: 0x00602EF8 File Offset: 0x006010F8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
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
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBackBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickConfirmBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickShareBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06015A7B RID: 88699 RVA: 0x00603134 File Offset: 0x00601334
	protected override void OnStart()
	{
		this.ItemLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(4), new Func<CommonItemSmallItemGrid>(this.InitGridItem), null, false, true);
		SkinObtainViewData skinObtainViewData = (SkinObtainViewData)this.OpenParam;
		int configId = skinObtainViewData.ObtainSkinData[0].ConfigId;
		this.ObtainSkinData = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(configId);
		RewardItemData[] otherRewardData = skinObtainViewData.OtherRewardData;
		if (otherRewardData != null)
		{
			List<TItem> list = new List<TItem>();
			foreach (RewardItemData rewardItemData in otherRewardData)
			{
				InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(rewardItemData.ConfigId));
				if (itemDataTypeByConfigId != InventoryDefine.EItemDataType.WeaponSkinItem)
				{
					InventoryDefine.GetItemData itemData = new InventoryDefine.GetItemData(rewardItemData.ConfigId, 0);
					int count = 0;
					if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.VirtualItem)
					{
						count = rewardItemData.Count;
					}
					TItem item = new TItem(itemData, count);
					list.Add(item);
				}
			}
			this.ExtraRewardData = list.ToArray();
		}
	}

	// Token: 0x06015A7C RID: 88700 RVA: 0x00603212 File Offset: 0x00601412
	[NullableContext(1)]
	private CommonItemSmallItemGrid InitGridItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x06015A7D RID: 88701 RVA: 0x00603219 File Offset: 0x00601419
	private void OnClickBackBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x06015A7E RID: 88702 RVA: 0x00603224 File Offset: 0x00601424
	private void OnClickConfirmBtn()
	{
		int roleId = this.ObtainSkinData.GetRoleId();
		bool flag = this.ObtainSkinData.GetIfHaveRole();
		if (ModelBase<RoleModel>.Instance.IsMainRole(roleId))
		{
			roleId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId().Value;
			flag = true;
		}
		if (!flag)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ObtainNoRole);
			ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, null);
			return;
		}
		ControllerBase<BlackScreenController>.Instance.AddBlackScreenAsync("Start", "OpenRoleSkinView", "Black");
		base.CloseMe(delegate(bool _)
		{
			ControllerBase<SkinController>.Instance.SkipToSkinView(roleId, EUiTabViewName.RoleSkinTabView, true, this.ObtainSkinData.GetItemId(), delegate(bool _, int _)
			{
				ControllerBase<BlackScreenController>.Instance.RemoveBlackScreen("Close", "OpenRoleSkinView");
			}, null, null);
		});
	}

	// Token: 0x06015A7F RID: 88703 RVA: 0x006032D0 File Offset: 0x006014D0
	private void OnClickShareBtn()
	{
		RoleSkinData obtainSkinData = this.ObtainSkinData;
		PhotoSaveViewParam param = new PhotoSaveViewParam
		{
			ScreenShot = false,
			IsHiddenBattleView = false,
			HandBookPhotoData = null,
			RoleSkinData = obtainSkinData,
			ShareId = 16
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhotoSaveView, param, null);
	}

	// Token: 0x06015A80 RID: 88704 RVA: 0x0060331F File Offset: 0x0060151F
	protected override void OnBeforeShow()
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), "ObtainRoleSkin", Array.Empty<object>());
		this.RefreshView();
	}

	// Token: 0x06015A81 RID: 88705 RVA: 0x00603343 File Offset: 0x00601543
	protected override void OnBeforeHide()
	{
	}

	// Token: 0x06015A82 RID: 88706 RVA: 0x00603348 File Offset: 0x00601548
	private void RefreshView()
	{
		this.RefreshName(this.ObtainSkinData);
		this.RefreshSubName(this.ObtainSkinData);
		this.RefreshLayout(this.ObtainSkinData);
		this.RefreshRoleSpine(this.ObtainSkinData);
		this.RefreshFrameTextureColor(this.ObtainSkinData);
		this.RefreshFrameTextureColor2(this.ObtainSkinData);
	}

	// Token: 0x06015A83 RID: 88707 RVA: 0x006033A0 File Offset: 0x006015A0
	private void RefreshName(RoleSkinData data)
	{
		if (data == null)
		{
			base.GetText(2).SetText("", true);
			return;
		}
		string titleName = data.GetTitleName();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), titleName, Array.Empty<object>());
	}

	// Token: 0x06015A84 RID: 88708 RVA: 0x006033E4 File Offset: 0x006015E4
	private void RefreshSubName(RoleSkinData data)
	{
		if (data == null)
		{
			base.GetText(3).SetText("", true);
			return;
		}
		string subTitle = data.GetSubTitle();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), subTitle, Array.Empty<object>());
	}

	// Token: 0x06015A85 RID: 88709 RVA: 0x00603428 File Offset: 0x00601628
	private void RefreshLayout(RoleSkinData data)
	{
		if (this.ExtraRewardData == null)
		{
			GenericLayout<CommonItemSmallItemGrid, TItem> itemLayout = this.ItemLayout;
			if (itemLayout == null)
			{
				return;
			}
			itemLayout.SetActive(false);
			return;
		}
		else
		{
			TItem[] extraRewardData = this.ExtraRewardData;
			GenericLayout<CommonItemSmallItemGrid, TItem> itemLayout2 = this.ItemLayout;
			if (itemLayout2 != null)
			{
				itemLayout2.SetActive(extraRewardData.Length != 0);
			}
			GenericLayout<CommonItemSmallItemGrid, TItem> itemLayout3 = this.ItemLayout;
			if (itemLayout3 == null)
			{
				return;
			}
			itemLayout3.RefreshByData(extraRewardData.ToList<TItem>(), null, false);
			return;
		}
	}

	// Token: 0x06015A86 RID: 88710 RVA: 0x00603484 File Offset: 0x00601684
	private UniTask RefreshRoleSpine(RoleSkinData data)
	{
		SkinObtainView.<RefreshRoleSpine>d__17 <RefreshRoleSpine>d__;
		<RefreshRoleSpine>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRoleSpine>d__.<>4__this = this;
		<RefreshRoleSpine>d__.data = data;
		<RefreshRoleSpine>d__.<>1__state = -1;
		<RefreshRoleSpine>d__.<>t__builder.Start<SkinObtainView.<RefreshRoleSpine>d__17>(ref <RefreshRoleSpine>d__);
		return <RefreshRoleSpine>d__.<>t__builder.Task;
	}

	// Token: 0x06015A87 RID: 88711 RVA: 0x006034D0 File Offset: 0x006016D0
	private void RefreshFrameTextureColor(RoleSkinData data)
	{
		if (data == null)
		{
			base.GetTexture(8).SetUIActive(false);
			return;
		}
		base.GetTexture(8).SetUIActive(true);
		FColor color = FColor.FromHex(data.GetObtainFrameColor1());
		base.GetTexture(8).SetColor(color);
	}

	// Token: 0x06015A88 RID: 88712 RVA: 0x00603514 File Offset: 0x00601714
	private void RefreshFrameTextureColor2(RoleSkinData data)
	{
		if (data == null)
		{
			base.GetTexture(9).SetUIActive(false);
			return;
		}
		base.GetTexture(9).SetUIActive(true);
		FColor color = FColor.FromHex(data.GetObtainFrameColor2());
		base.GetTexture(9).SetColor(color);
	}

	// Token: 0x0400A65B RID: 42587
	private RoleSkinData ObtainSkinData;

	// Token: 0x0400A65C RID: 42588
	private TItem[] ExtraRewardData;

	// Token: 0x0400A65D RID: 42589
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> ItemLayout;

	// Token: 0x02008DC3 RID: 36291
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402FB63 RID: 195427
		BackBtn,
		// Token: 0x0402FB64 RID: 195428
		TextureSpine,
		// Token: 0x0402FB65 RID: 195429
		TitleText,
		// Token: 0x0402FB66 RID: 195430
		TitleSubText,
		// Token: 0x0402FB67 RID: 195431
		HorizontalLayout,
		// Token: 0x0402FB68 RID: 195432
		RewardItem,
		// Token: 0x0402FB69 RID: 195433
		ConfirmBtn,
		// Token: 0x0402FB6A RID: 195434
		ShareBtn,
		// Token: 0x0402FB6B RID: 195435
		FrameTexture1,
		// Token: 0x0402FB6C RID: 195436
		FrameTexture2,
		// Token: 0x0402FB6D RID: 195437
		TextureImage,
		// Token: 0x0402FB6E RID: 195438
		RewardParentItem,
		// Token: 0x0402FB6F RID: 195439
		TextObtainTip
	}
}
