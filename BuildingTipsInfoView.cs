using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013AE RID: 5038
[NullableContext(1)]
[Nullable(0)]
public class BuildingTipsInfoView : UiViewBase
{
	// Token: 0x06008ADB RID: 35547 RVA: 0x0024925D File Offset: 0x0024745D
	public BuildingTipsInfoView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06008ADC RID: 35548 RVA: 0x00249274 File Offset: 0x00247474
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(14, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(15, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIItem)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(13, new Action(this.Vc.SwitchPrev)),
			new ValueTuple<int, Delegate>(14, new Action(this.Vc.SwitchNext)),
			new ValueTuple<int, Delegate>(15, new Action(this.Vc.JumpToMap)),
			new ValueTuple<int, Delegate>(22, new Action(this.Vc.JumpToConditionTip))
		};
	}

	// Token: 0x06008ADD RID: 35549 RVA: 0x00249518 File Offset: 0x00247718
	private UniTask InitCaption()
	{
		BuildingTipsInfoView.<InitCaption>d__8 <InitCaption>d__;
		<InitCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCaption>d__.<>4__this = this;
		<InitCaption>d__.<>1__state = -1;
		<InitCaption>d__.<>t__builder.Start<BuildingTipsInfoView.<InitCaption>d__8>(ref <InitCaption>d__);
		return <InitCaption>d__.<>t__builder.Task;
	}

	// Token: 0x06008ADE RID: 35550 RVA: 0x0024955C File Offset: 0x0024775C
	private UniTask InitCostItem()
	{
		BuildingTipsInfoView.<InitCostItem>d__9 <InitCostItem>d__;
		<InitCostItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCostItem>d__.<>4__this = this;
		<InitCostItem>d__.<>1__state = -1;
		<InitCostItem>d__.<>t__builder.Start<BuildingTipsInfoView.<InitCostItem>d__9>(ref <InitCostItem>d__);
		return <InitCostItem>d__.<>t__builder.Task;
	}

	// Token: 0x06008ADF RID: 35551 RVA: 0x0024959F File Offset: 0x0024779F
	private void InitLayout()
	{
		this.AttrLayout = new GenericLayout<BuildingAttributeItem, IAdditionData>(base.GetLayoutBase(17), new Func<BuildingAttributeItem>(this.InitAttributeItem), (AUIBaseActor)base.GetItem(18).GetOwner(), false, true);
	}

	// Token: 0x06008AE0 RID: 35552 RVA: 0x002495D4 File Offset: 0x002477D4
	protected override UniTask OnBeforeStartAsync()
	{
		BuildingTipsInfoView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BuildingTipsInfoView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008AE1 RID: 35553 RVA: 0x00249618 File Offset: 0x00247818
	protected override UniTask OnBeforeShowAsyncImplementImplement()
	{
		BuildingTipsInfoView.<OnBeforeShowAsyncImplementImplement>d__12 <OnBeforeShowAsyncImplementImplement>d__;
		<OnBeforeShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplementImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplementImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Start<BuildingTipsInfoView.<OnBeforeShowAsyncImplementImplement>d__12>(ref <OnBeforeShowAsyncImplementImplement>d__);
		return <OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06008AE2 RID: 35554 RVA: 0x0024965C File Offset: 0x0024785C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length < 1)
		{
			return null;
		}
		if (!(configParams[0] == "Cost".ToString()))
		{
			return null;
		}
		UUIItem costContent = this.CaptionItem.GetCostContent();
		if (costContent == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			costContent,
			costContent
		};
	}

	// Token: 0x06008AE3 RID: 35555 RVA: 0x002496A6 File Offset: 0x002478A6
	private BuildingAttributeItem InitAttributeItem()
	{
		return new BuildingAttributeItem();
	}

	// Token: 0x06008AE4 RID: 35556 RVA: 0x002496B0 File Offset: 0x002478B0
	public void RefreshText(int buildingId)
	{
		BuildingData buildingDataById = ModelBase<MoonChasingBuildingModel>.Instance.GetBuildingDataById(buildingId);
		UUIText text = base.GetText(2);
		UUIText text2 = base.GetText(1);
		UUIText text3 = base.GetText(3);
		text.SetUIActive(buildingDataById.IsUnlock);
		Building buildingById = ConfigBase<BuildingConfig>.Instance.GetBuildingById(buildingId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, buildingById.Name ?? "", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text3, buildingById.Desc ?? "", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Moonfiesta_BuildingLevelShow", new <>z__ReadOnlyArray<object>(new object[]
		{
			buildingDataById.Level,
			buildingDataById.LevelMax
		}));
	}

	// Token: 0x06008AE5 RID: 35557 RVA: 0x00249774 File Offset: 0x00247974
	public UniTask RefreshAttribute(int buildingId)
	{
		BuildingTipsInfoView.<RefreshAttribute>d__16 <RefreshAttribute>d__;
		<RefreshAttribute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAttribute>d__.<>4__this = this;
		<RefreshAttribute>d__.buildingId = buildingId;
		<RefreshAttribute>d__.<>1__state = -1;
		<RefreshAttribute>d__.<>t__builder.Start<BuildingTipsInfoView.<RefreshAttribute>d__16>(ref <RefreshAttribute>d__);
		return <RefreshAttribute>d__.<>t__builder.Task;
	}

	// Token: 0x06008AE6 RID: 35558 RVA: 0x002497C0 File Offset: 0x002479C0
	public void RefreshRoleItem(int buildingId)
	{
		BuildingData buildingDataById = ModelBase<MoonChasingBuildingModel>.Instance.GetBuildingDataById(buildingId);
		UUIItem item = base.GetItem(4);
		if (!buildingDataById.IsUnlock)
		{
			item.SetUIActive(false);
			return;
		}
		item.SetUIActive(!buildingDataById.IsBuild);
		if (!buildingDataById.IsBuild)
		{
			Building buildingById = ConfigBase<BuildingConfig>.Instance.GetBuildingById(buildingId);
			base.SetTextureByPath(ConfigBase<BusinessConfig>.Instance.GetEntrustRoleById(buildingById.AssociateRole).SmallHeadIcon, base.GetTexture(5), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), buildingById.RoleTips ?? "", Array.Empty<object>());
		}
	}

	// Token: 0x06008AE7 RID: 35559 RVA: 0x0024986C File Offset: 0x00247A6C
	public void RefreshBottom(int buildingId)
	{
		BuildingData buildingDataById = ModelBase<MoonChasingBuildingModel>.Instance.GetBuildingDataById(buildingId);
		UUIItem item = base.GetItem(7);
		UUIItem item2 = base.GetItem(10);
		UUIItem item3 = base.GetItem(12);
		item.SetUIActive(buildingDataById.IsUnlock && !buildingDataById.IsMax);
		item2.SetUIActive(!buildingDataById.IsUnlock);
		item3.SetUIActive(buildingDataById.IsMax);
		if (!buildingDataById.IsUnlock)
		{
			string textStringId = LevelGeneralCommons.GetConditionGroupHintText(ConfigBase<BuildingConfig>.Instance.GetBuildingById(buildingId).UnlockCondition) ?? "";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), textStringId, Array.Empty<object>());
			return;
		}
		if (buildingDataById.IsMax)
		{
			return;
		}
		int coinItemId = ConfigBase<BusinessConfig>.Instance.GetCoinItemId();
		this.CostItem.UpdateItem(coinItemId, buildingDataById.GetConsumeCount());
		this.CostItem.RefreshCountEnableState();
		if (buildingDataById.IsBuild)
		{
			this.ConfirmItem.SetShowText("PrefabTextItem_2996025119_Text");
			return;
		}
		this.ConfirmItem.SetShowText("Moonfiesta_BuildingTips_Building");
	}

	// Token: 0x06008AE8 RID: 35560 RVA: 0x00249974 File Offset: 0x00247B74
	public void RefreshTexture(int buildingId)
	{
		BuildingData buildingDataById = ModelBase<MoonChasingBuildingModel>.Instance.GetBuildingDataById(buildingId);
		Building buildingById = ConfigBase<BuildingConfig>.Instance.GetBuildingById(buildingId);
		UUIButtonComponent button = base.GetButton(15);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(false);
		}
		UUIButtonComponent button2 = base.GetButton(13);
		if (button2 != null)
		{
			button2.RootUIComp.Get().SetUIActive(false);
		}
		UUIButtonComponent button3 = base.GetButton(14);
		if (button3 != null)
		{
			button3.RootUIComp.Get().SetUIActive(false);
		}
		if (!buildingDataById.IsUnlock)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_BuildItemBLock");
			base.SetTextureByPath(resourcePath, base.GetTexture(0), null, null);
		}
		else if (buildingDataById.IsBuild)
		{
			base.SetTextureByPath(buildingById.BuildingTexture ?? "", base.GetTexture(0), null, null);
		}
		else
		{
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_BuildItemBUnlock");
			base.SetTextureByPath(resourcePath2, base.GetTexture(0), null, null);
		}
		UUIItem item = base.GetItem(19);
		if (item != null)
		{
			item.SetUIActive(!buildingDataById.IsBuild);
		}
		UUIItem item2 = base.GetItem(20);
		if (item2 != null)
		{
			item2.SetUIActive(buildingDataById.IsBuild);
		}
		UUIItem item3 = base.GetItem(21);
		if (item3 == null)
		{
			return;
		}
		item3.SetUIActive(buildingDataById.IsBuild);
	}

	// Token: 0x040040F3 RID: 16627
	protected CommonCostItem CostItem;

	// Token: 0x040040F4 RID: 16628
	protected ButtonItem ConfirmItem;

	// Token: 0x040040F5 RID: 16629
	protected PopupCaptionItem CaptionItem;

	// Token: 0x040040F6 RID: 16630
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<BuildingAttributeItem, IAdditionData> AttrLayout;

	// Token: 0x040040F7 RID: 16631
	private readonly BuildingTipsInfoViewController Vc = new BuildingTipsInfoViewController();

	// Token: 0x02007764 RID: 30564
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x040291C1 RID: 168385
		public const int Texture = 0;

		// Token: 0x040291C2 RID: 168386
		public const int Title = 1;

		// Token: 0x040291C3 RID: 168387
		public const int Level = 2;

		// Token: 0x040291C4 RID: 168388
		public const int Content = 3;

		// Token: 0x040291C5 RID: 168389
		public const int RoleItem = 4;

		// Token: 0x040291C6 RID: 168390
		public const int RoleIcon = 5;

		// Token: 0x040291C7 RID: 168391
		public const int RoleDesc = 6;

		// Token: 0x040291C8 RID: 168392
		public const int ConfirmRootItem = 7;

		// Token: 0x040291C9 RID: 168393
		public const int CostItem = 8;

		// Token: 0x040291CA RID: 168394
		public const int ConfirmItem = 9;

		// Token: 0x040291CB RID: 168395
		public const int LockItem = 10;

		// Token: 0x040291CC RID: 168396
		public const int LockText = 11;

		// Token: 0x040291CD RID: 168397
		public const int MaxItem = 12;

		// Token: 0x040291CE RID: 168398
		public const int LeftBtn = 13;

		// Token: 0x040291CF RID: 168399
		public const int RightBtn = 14;

		// Token: 0x040291D0 RID: 168400
		public const int TrackBtn = 15;

		// Token: 0x040291D1 RID: 168401
		public const int CaptionItem = 16;

		// Token: 0x040291D2 RID: 168402
		public const int AttributeLayout = 17;

		// Token: 0x040291D3 RID: 168403
		public const int AttributeItem = 18;

		// Token: 0x040291D4 RID: 168404
		public const int BuildFrameTexture = 19;

		// Token: 0x040291D5 RID: 168405
		public const int LevelUpFrameBgTexture = 20;

		// Token: 0x040291D6 RID: 168406
		public const int LevelUpFrameTexture = 21;

		// Token: 0x040291D7 RID: 168407
		public const int ConditionBtn = 22;
	}
}
