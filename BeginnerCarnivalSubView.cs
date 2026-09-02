using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200125E RID: 4702
[NullableContext(2)]
[Nullable(0)]
public class BeginnerCarnivalSubView : ActivitySubViewBase
{
	// Token: 0x06007D4C RID: 32076 RVA: 0x0021083C File Offset: 0x0020EA3C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickSelectRoleBtn)),
			new ValueTuple<int, Delegate>(12, new Action(this.OnClickGachaBtn)),
			new ValueTuple<int, Delegate>(10, new Action(this.OnClickShopBtn))
		};
	}

	// Token: 0x06007D4D RID: 32077 RVA: 0x00210A27 File Offset: 0x0020EC27
	protected override void OnSetData()
	{
		this.BeginnerCarnivalData = (this.ActivityBaseData as BeginnerCarnivalData);
	}

	// Token: 0x06007D4E RID: 32078 RVA: 0x00210A3C File Offset: 0x0020EC3C
	protected override UniTask OnBeforeStartAsync()
	{
		BeginnerCarnivalSubView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BeginnerCarnivalSubView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007D4F RID: 32079 RVA: 0x00210A80 File Offset: 0x0020EC80
	protected override void OnStart()
	{
		EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
		base.GetItem(15).SetUIActive(playerGender == EPlayerGender.Male);
		base.GetItem(16).SetUIActive(playerGender == EPlayerGender.Female);
		this.RefreshDesc();
	}

	// Token: 0x06007D50 RID: 32080 RVA: 0x00210AC0 File Offset: 0x0020ECC0
	private void RefreshDesc()
	{
		Activity? localConfig = this.ActivityBaseData.LocalConfig;
		string descTheme = localConfig.Value.DescTheme;
		string desc = localConfig.Value.Desc;
		bool flag = !StringUtils.IsEmpty(descTheme);
		this.TitleComponent.SetSubTitleVisible(flag);
		if (flag)
		{
			this.TitleComponent.SetSubTitleByTextId(descTheme, Array.Empty<string>());
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), desc, Array.Empty<object>());
	}

	// Token: 0x06007D51 RID: 32081 RVA: 0x00210B3C File Offset: 0x0020ED3C
	private void RefreshTitle()
	{
		this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
		this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		this.TitleComponent.SetTimeTextVisible(item);
		if (item)
		{
			this.TitleComponent.SetTimeTextByText(item2);
		}
	}

	// Token: 0x06007D52 RID: 32082 RVA: 0x00210BA0 File Offset: 0x0020EDA0
	protected override void OnRefreshView()
	{
		this.RefreshTitle();
		BeginnerCarnivalData beginnerCarnivalData = ControllerBase<BeginnerCarnivalController>.Instance.GetBeginnerCarnivalData();
		ActivityTask taskDataById = beginnerCarnivalData.GetTaskDataById(beginnerCarnivalData.GetRoleTaskId);
		if (taskDataById == null)
		{
			return;
		}
		bool uiactive = taskDataById.Status == ActivityTaskState.ActivityTaskTaken;
		base.GetItem(7).SetUIActive(uiactive);
		base.GetTexture(6).SetUIActive(uiactive);
		int choseRoleId = beginnerCarnivalData.ChoseRoleId;
		bool flag = choseRoleId > 0;
		base.GetItem(8).SetUIActive(!flag);
		base.GetTexture(5).SetUIActive(flag);
		if (flag)
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(choseRoleId);
			base.SetTextureByPath(roleConfig.Value.RoleHeadIcon, base.GetTexture(5), null, null);
			base.SetTextureByPath(roleConfig.Value.RoleHeadIcon, base.GetTexture(6), null, null);
		}
		NewbieCarnivalParam? newbieCarnivalParam = ConfigBase<BeginnerCarnivalConfig>.Instance.GetNewbieCarnivalParam(ControllerBase<BeginnerCarnivalController>.Instance.ActivityId);
		base.GetText(9).SetText("<color=#f5cf47>" + beginnerCarnivalData.GetCurrentItemCount().ToString() + "</color>/" + ((newbieCarnivalParam != null) ? new int?(newbieCarnivalParam.GetValueOrDefault().AllCount) : null).ToString(), true);
		base.GetItem(14).SetUIActive(beginnerCarnivalData.GetRoleGetTaskTabRedDotShow(5));
		if (ModelBase<FunctionModel>.Instance.IsOpen(10009))
		{
			ProtoGachaInfo gachaInfo = ModelBase<GachaModel>.Instance.GetGachaInfo(beginnerCarnivalData.GachaId[0]);
			ProtoGachaInfo gachaInfo2 = ModelBase<GachaModel>.Instance.GetGachaInfo(beginnerCarnivalData.GachaId[1]);
			base.GetButton(12).RootUIComp.Get().SetUIActive(gachaInfo != null || gachaInfo2 != null);
		}
		else
		{
			base.GetButton(12).RootUIComp.Get().SetUIActive(false);
		}
		bool flag2 = false;
		foreach (PayShopGoods payShopGoods in ModelBase<PayShopModel>.Instance.GetPayShopTabData(PayShopDefine.EPayShopTabType.GiftBag, 5, true))
		{
			IRemainingData remainingData = payShopGoods.GetRemainingData();
			if (remainingData != null && remainingData.Count > 0)
			{
				flag2 = true;
				break;
			}
		}
		bool flag3 = ModelBase<FunctionModel>.Instance.IsOpen(10010);
		base.GetButton(10).RootUIComp.Get().SetUIActive(flag2 && flag3);
		base.GetItem(11).SetUIActive(!beginnerCarnivalData.GetHaveShopEnter());
		base.GetItem(13).SetUIActive(!beginnerCarnivalData.GetHaveGachaEnter());
		ActivityFunctionalTypeA bottomComponent = this.BottomComponent;
		if (bottomComponent == null)
		{
			return;
		}
		bottomComponent.SetFunctionRedDotVisible(beginnerCarnivalData.GetAnyTaskRedDotShow());
	}

	// Token: 0x06007D53 RID: 32083 RVA: 0x00210E6C File Offset: 0x0020F06C
	private void OnClickTaskBtn()
	{
		if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
		{
			int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BeginnerCarnivalMainView, null, null);
	}

	// Token: 0x06007D54 RID: 32084 RVA: 0x00210EBC File Offset: 0x0020F0BC
	private void OnClickSelectRoleBtn()
	{
		if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
		{
			int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BeginnerCarnivalRoleTaskView, null, null);
	}

	// Token: 0x06007D55 RID: 32085 RVA: 0x00210F0C File Offset: 0x0020F10C
	private void OnClickShopBtn()
	{
		if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
		{
			int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			return;
		}
		BeginnerCarnivalData beginnerCarnivalData = ControllerBase<BeginnerCarnivalController>.Instance.GetBeginnerCarnivalData();
		ControllerBase<PayShopController>.Instance.OpenPayShopViewWithTab(PayShopDefine.EPayShopTabType.GiftBag, 5);
		beginnerCarnivalData.SetShopEnter();
	}

	// Token: 0x06007D56 RID: 32086 RVA: 0x00210F64 File Offset: 0x0020F164
	private void OnClickGachaBtn()
	{
		if (!this.ActivityBaseData.GetPreGuideQuestFinishState())
		{
			int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			return;
		}
		BeginnerCarnivalData beginnerCarnivalData = ControllerBase<BeginnerCarnivalController>.Instance.GetBeginnerCarnivalData();
		ProtoGachaInfo gachaInfo = ModelBase<GachaModel>.Instance.GetGachaInfo(beginnerCarnivalData.GachaId[0]);
		ProtoGachaInfo gachaInfo2 = ModelBase<GachaModel>.Instance.GetGachaInfo(beginnerCarnivalData.GachaId[1]);
		if (gachaInfo != null || gachaInfo2 != null)
		{
			ControllerBase<GachaController>.Instance.OpenGachaView((gachaInfo != null) ? beginnerCarnivalData.GachaId[0] : beginnerCarnivalData.GachaId[1]);
		}
		else
		{
			ControllerBase<GachaController>.Instance.OpenGachaView(0);
		}
		beginnerCarnivalData.SetGachaEnter();
	}

	// Token: 0x04003C1C RID: 15388
	private const int ROLE_TAB_INDEX = 5;

	// Token: 0x04003C1D RID: 15389
	private const int CARNIVAL_SHOP_TAB_ID = 5;

	// Token: 0x04003C1E RID: 15390
	private BeginnerCarnivalData BeginnerCarnivalData;

	// Token: 0x04003C1F RID: 15391
	private ActivityFunctionalTypeA BottomComponent;

	// Token: 0x04003C20 RID: 15392
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x04003C21 RID: 15393
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> RewardListComponent;
}
