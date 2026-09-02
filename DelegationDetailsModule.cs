using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013C5 RID: 5061
[NullableContext(1)]
[Nullable(0)]
public class DelegationDetailsModule : UiPanelBase
{
	// Token: 0x06008BAC RID: 35756 RVA: 0x0024C2C8 File Offset: 0x0024A4C8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(6, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(12, new Action(this.OnConfirm))
		};
	}

	// Token: 0x06008BAD RID: 35757 RVA: 0x0024C454 File Offset: 0x0024A654
	private UniTask InitCostItem()
	{
		DelegationDetailsModule.<InitCostItem>d__12 <InitCostItem>d__;
		<InitCostItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCostItem>d__.<>4__this = this;
		<InitCostItem>d__.<>1__state = -1;
		<InitCostItem>d__.<>t__builder.Start<DelegationDetailsModule.<InitCostItem>d__12>(ref <InitCostItem>d__);
		return <InitCostItem>d__.<>t__builder.Task;
	}

	// Token: 0x06008BAE RID: 35758 RVA: 0x0024C498 File Offset: 0x0024A698
	private UniTask InitRoleModule()
	{
		DelegationDetailsModule.<InitRoleModule>d__13 <InitRoleModule>d__;
		<InitRoleModule>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRoleModule>d__.<>4__this = this;
		<InitRoleModule>d__.<>1__state = -1;
		<InitRoleModule>d__.<>t__builder.Start<DelegationDetailsModule.<InitRoleModule>d__13>(ref <InitRoleModule>d__);
		return <InitRoleModule>d__.<>t__builder.Task;
	}

	// Token: 0x06008BAF RID: 35759 RVA: 0x0024C4DC File Offset: 0x0024A6DC
	private UniTask InitCharacterListModule()
	{
		DelegationDetailsModule.<InitCharacterListModule>d__14 <InitCharacterListModule>d__;
		<InitCharacterListModule>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCharacterListModule>d__.<>4__this = this;
		<InitCharacterListModule>d__.<>1__state = -1;
		<InitCharacterListModule>d__.<>t__builder.Start<DelegationDetailsModule.<InitCharacterListModule>d__14>(ref <InitCharacterListModule>d__);
		return <InitCharacterListModule>d__.<>t__builder.Task;
	}

	// Token: 0x06008BB0 RID: 35760 RVA: 0x0024C520 File Offset: 0x0024A720
	private UniTask InitEditTeamModule()
	{
		DelegationDetailsModule.<InitEditTeamModule>d__15 <InitEditTeamModule>d__;
		<InitEditTeamModule>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitEditTeamModule>d__.<>4__this = this;
		<InitEditTeamModule>d__.<>1__state = -1;
		<InitEditTeamModule>d__.<>t__builder.Start<DelegationDetailsModule.<InitEditTeamModule>d__15>(ref <InitEditTeamModule>d__);
		return <InitEditTeamModule>d__.<>t__builder.Task;
	}

	// Token: 0x06008BB1 RID: 35761 RVA: 0x0024C563 File Offset: 0x0024A763
	private void InitBtn()
	{
		this.HelperBtn = new ButtonItem(base.GetItem(14));
		this.HelperBtn.SetFunction(delegate(int _)
		{
			this.OnSkipToHelper();
		});
	}

	// Token: 0x06008BB2 RID: 35762 RVA: 0x0024C590 File Offset: 0x0024A790
	protected override UniTask OnBeforeStartAsync()
	{
		DelegationDetailsModule.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DelegationDetailsModule.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008BB3 RID: 35763 RVA: 0x0024C5D4 File Offset: 0x0024A7D4
	protected override UniTask OnBeforeShowAsyncImplement()
	{
		DelegationDetailsModule.<OnBeforeShowAsyncImplement>d__18 <OnBeforeShowAsyncImplement>d__;
		<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<DelegationDetailsModule.<OnBeforeShowAsyncImplement>d__18>(ref <OnBeforeShowAsyncImplement>d__);
		return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06008BB4 RID: 35764 RVA: 0x0024C617 File Offset: 0x0024A817
	protected override void OnAfterHide()
	{
		this.HelperBtn.UnBindRedDot();
		this.SelectedRoleIdSet.Clear();
	}

	// Token: 0x06008BB5 RID: 35765 RVA: 0x0024C630 File Offset: 0x0024A830
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length < 2)
		{
			return null;
		}
		string text = configParams[1];
		UUIItem guideUiItem = base.GetGuideUiItem(text);
		string a = text;
		if (a == "0".ToString() || a == "1".ToString() || a == "2".ToString() || a == "3".ToString() || a == "4".ToString())
		{
			if (guideUiItem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				guideUiItem,
				guideUiItem
			};
		}
		else
		{
			if (!(a == "EditTeam".ToString()))
			{
				return null;
			}
			EditTeamModule editTeamModule = this.EditTeamModule;
			if (editTeamModule == null)
			{
				return null;
			}
			return editTeamModule.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
	}

	// Token: 0x06008BB6 RID: 35766 RVA: 0x0024C6E8 File Offset: 0x0024A8E8
	private void RefreshTitle()
	{
		TrackMoonEntrust delegationConfig = ConfigBase<BusinessConfig>.Instance.GetDelegationConfig(this.Data.Id);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), delegationConfig.Title, Array.Empty<object>());
	}

	// Token: 0x06008BB7 RID: 35767 RVA: 0x0024C728 File Offset: 0x0024A928
	private void RefreshStar()
	{
		TrackMoonEntrust delegationConfig = ConfigBase<BusinessConfig>.Instance.GetDelegationConfig(this.Data.Id);
		this.StarLayout.RefreshByDataAsync(new List<object>(), false, new int?(delegationConfig.Star)).Forget();
	}

	// Token: 0x06008BB8 RID: 35768 RVA: 0x0024C770 File Offset: 0x0024A970
	private void RefreshContent()
	{
		TrackMoonEntrust delegationConfig = ConfigBase<BusinessConfig>.Instance.GetDelegationConfig(this.Data.Id);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), delegationConfig.Content, Array.Empty<object>());
	}

	// Token: 0x06008BB9 RID: 35769 RVA: 0x0024C7B0 File Offset: 0x0024A9B0
	private void RefreshEvaluate()
	{
		base.GetItem(4).SetUIActive(this.Data.HasBestEvaluate());
		if (this.Data.HasBestEvaluate())
		{
			base.SetTextureByPath(ConfigBase<BusinessConfig>.Instance.GetEvaluateByLevel(this.Data.BestEvaluateLevel).Icon, base.GetTexture(5), null, null);
		}
	}

	// Token: 0x06008BBA RID: 35770 RVA: 0x0024C818 File Offset: 0x0024AA18
	private UniTask RefreshRecommend()
	{
		DelegationDetailsModule.<RefreshRecommend>d__25 <RefreshRecommend>d__;
		<RefreshRecommend>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshRecommend>d__.<>4__this = this;
		<RefreshRecommend>d__.<>1__state = -1;
		<RefreshRecommend>d__.<>t__builder.Start<DelegationDetailsModule.<RefreshRecommend>d__25>(ref <RefreshRecommend>d__);
		return <RefreshRecommend>d__.<>t__builder.Task;
	}

	// Token: 0x06008BBB RID: 35771 RVA: 0x0024C85C File Offset: 0x0024AA5C
	private UniTask RefreshCharacterList()
	{
		DelegationDetailsModule.<RefreshCharacterList>d__26 <RefreshCharacterList>d__;
		<RefreshCharacterList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshCharacterList>d__.<>4__this = this;
		<RefreshCharacterList>d__.<>1__state = -1;
		<RefreshCharacterList>d__.<>t__builder.Start<DelegationDetailsModule.<RefreshCharacterList>d__26>(ref <RefreshCharacterList>d__);
		return <RefreshCharacterList>d__.<>t__builder.Task;
	}

	// Token: 0x06008BBC RID: 35772 RVA: 0x0024C8A0 File Offset: 0x0024AAA0
	private UniTask RefreshEditTeamModule()
	{
		DelegationDetailsModule.<RefreshEditTeamModule>d__27 <RefreshEditTeamModule>d__;
		<RefreshEditTeamModule>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshEditTeamModule>d__.<>4__this = this;
		<RefreshEditTeamModule>d__.<>1__state = -1;
		<RefreshEditTeamModule>d__.<>t__builder.Start<DelegationDetailsModule.<RefreshEditTeamModule>d__27>(ref <RefreshEditTeamModule>d__);
		return <RefreshEditTeamModule>d__.<>t__builder.Task;
	}

	// Token: 0x06008BBD RID: 35773 RVA: 0x0024C8E3 File Offset: 0x0024AAE3
	private void RefreshRole()
	{
		this.RoleModule.Refresh(this.SelectedRoleIdSet);
	}

	// Token: 0x06008BBE RID: 35774 RVA: 0x0024C8F8 File Offset: 0x0024AAF8
	private void RefreshConsume()
	{
		List<IItemData> consumeList = this.Data.GetConsumeList();
		IItemData itemData = consumeList[0];
		this.FirstCost.UpdateItem(itemData.ItemId, itemData.Count);
		this.FirstCost.RefreshCountEnableState();
		IItemData itemData2 = consumeList[1];
		this.SecondCost.UpdateItem(itemData2.ItemId, itemData2.Count);
		this.SecondCost.RefreshCountEnableState();
	}

	// Token: 0x06008BBF RID: 35775 RVA: 0x0024C963 File Offset: 0x0024AB63
	private void RefreshConfirm()
	{
		base.GetButton(12).SetSelfInteractive(this.FirstCost.IsEnough && this.SecondCost.IsEnough);
	}

	// Token: 0x06008BC0 RID: 35776 RVA: 0x0024C98D File Offset: 0x0024AB8D
	private void RefreshRedDot()
	{
		this.HelperBtn.BindRedDot(ERedDotName.MoonChasingRole, 0);
	}

	// Token: 0x06008BC1 RID: 35777 RVA: 0x0024C9A0 File Offset: 0x0024ABA0
	private CharacterItem InitCharacterItem()
	{
		return new CharacterItem();
	}

	// Token: 0x06008BC2 RID: 35778 RVA: 0x0024C9A7 File Offset: 0x0024ABA7
	private CharacterNameWithBg InitRecommendItem()
	{
		return new CharacterNameWithBg();
	}

	// Token: 0x06008BC3 RID: 35779 RVA: 0x0024C9AE File Offset: 0x0024ABAE
	private DelegationDetailsModuleStarItem InitStarItem()
	{
		return new DelegationDetailsModuleStarItem();
	}

	// Token: 0x06008BC4 RID: 35780 RVA: 0x0024C9B8 File Offset: 0x0024ABB8
	private void OnConfirm()
	{
		if (this.SelectedRoleIdSet.Count == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_EditBattleTeamLastRole_Text", Array.Empty<object>());
			return;
		}
		if (this.SelectedRoleIdSet.Count < 3 && this.SelectedRoleIdSet.Count < this.EditTeamModule.GetDataLength())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.MoonChasingEditTeam);
			confirmBoxDataNew.FunctionMap[2] = new Action(this.<OnConfirm>g__AcceptDelegateRequest|35_0);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		this.<OnConfirm>g__AcceptDelegateRequest|35_0();
	}

	// Token: 0x06008BC5 RID: 35781 RVA: 0x0024CA43 File Offset: 0x0024AC43
	private void OnSkipToHelper()
	{
		ControllerBase<MoonChasingController>.Instance.OpenHelperView();
	}

	// Token: 0x06008BC6 RID: 35782 RVA: 0x0024CA50 File Offset: 0x0024AC50
	private void RefreshDetails(int roleId, bool isSelected)
	{
		if (isSelected)
		{
			this.SelectedRoleIdSet.Add(roleId);
		}
		else
		{
			this.SelectedRoleIdSet.Remove(roleId);
		}
		DelegationRoleModule roleModule = this.RoleModule;
		if (roleModule != null)
		{
			roleModule.Refresh(this.SelectedRoleIdSet);
		}
		this.RefreshCharacterList().Forget();
		this.RefreshConfirm();
	}

	// Token: 0x06008BC7 RID: 35783 RVA: 0x0024CAA4 File Offset: 0x0024ACA4
	private bool CanExecuteChange(int roleId, EToggleState toggle)
	{
		if (toggle == EToggleState.ETT_Checked)
		{
			return true;
		}
		if (this.SelectedRoleIdSet.Count < 3)
		{
			return true;
		}
		if (this.SelectedRoleIdSet.Contains(roleId))
		{
			return true;
		}
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Moonfiesta_PartnerFull", Array.Empty<object>());
		return false;
	}

	// Token: 0x06008BC8 RID: 35784 RVA: 0x0024CAE1 File Offset: 0x0024ACE1
	private bool IsItemSelected(int roleId)
	{
		return this.SelectedRoleIdSet.Contains(roleId);
	}

	// Token: 0x06008BC9 RID: 35785 RVA: 0x0024CAEF File Offset: 0x0024ACEF
	public void SetDelegationData(DelegationData data)
	{
		this.Data = data;
	}

	// Token: 0x06008BCA RID: 35786 RVA: 0x0024CAF8 File Offset: 0x0024ACF8
	public UniTask RefreshAsync()
	{
		DelegationDetailsModule.<RefreshAsync>d__41 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<DelegationDetailsModule.<RefreshAsync>d__41>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008BCE RID: 35790 RVA: 0x0024CB60 File Offset: 0x0024AD60
	[CompilerGenerated]
	private void <OnConfirm>g__AcceptDelegateRequest|35_0()
	{
		List<int> roleIdList = new List<int>(this.SelectedRoleIdSet);
		ControllerBase<MoonChasingController>.Instance.AcceptDelegateRequest(this.Data.Id, roleIdList);
	}

	// Token: 0x04004128 RID: 16680
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayout<CharacterNameWithBg, int> RecommendLayout;

	// Token: 0x04004129 RID: 16681
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected CharacterListModule<CharacterItem> CharacterListModule;

	// Token: 0x0400412A RID: 16682
	[Nullable(2)]
	protected DelegationRoleModule RoleModule;

	// Token: 0x0400412B RID: 16683
	protected CommonCostItem FirstCost;

	// Token: 0x0400412C RID: 16684
	protected CommonCostItem SecondCost;

	// Token: 0x0400412D RID: 16685
	[Nullable(2)]
	protected EditTeamModule EditTeamModule;

	// Token: 0x0400412E RID: 16686
	protected DelegationData Data;

	// Token: 0x0400412F RID: 16687
	protected HashSet<int> SelectedRoleIdSet = new HashSet<int>();

	// Token: 0x04004130 RID: 16688
	[Nullable(new byte[]
	{
		1,
		1,
		2
	})]
	protected GenericLayout<DelegationDetailsModuleStarItem, object> StarLayout;

	// Token: 0x04004131 RID: 16689
	protected ButtonItem HelperBtn;

	// Token: 0x02007790 RID: 30608
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x04029281 RID: 168577
		public const int Title = 0;

		// Token: 0x04029282 RID: 168578
		public const int StarLayout = 1;

		// Token: 0x04029283 RID: 168579
		public const int StarItem = 2;

		// Token: 0x04029284 RID: 168580
		public const int Content = 3;

		// Token: 0x04029285 RID: 168581
		public const int BestEvaluateItem = 4;

		// Token: 0x04029286 RID: 168582
		public const int BestEvaluateTexture = 5;

		// Token: 0x04029287 RID: 168583
		public const int RecommendLayout = 6;

		// Token: 0x04029288 RID: 168584
		public const int RecommendItem = 7;

		// Token: 0x04029289 RID: 168585
		public const int CharacterListItem = 8;

		// Token: 0x0402928A RID: 168586
		public const int SelectedRoleRootItem = 9;

		// Token: 0x0402928B RID: 168587
		public const int FirstCost = 10;

		// Token: 0x0402928C RID: 168588
		public const int SecondCost = 11;

		// Token: 0x0402928D RID: 168589
		public const int ConfirmBtn = 12;

		// Token: 0x0402928E RID: 168590
		public const int RoleListRootItem = 13;

		// Token: 0x0402928F RID: 168591
		public const int HelperItem = 14;
	}
}
