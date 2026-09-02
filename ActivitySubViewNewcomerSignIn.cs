using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001460 RID: 5216
[NullableContext(1)]
[Nullable(0)]
public class ActivitySubViewNewcomerSignIn : ActivitySubViewBase
{
	// Token: 0x06009161 RID: 37217 RVA: 0x00265010 File Offset: 0x00263210
	protected unsafe override void OnRegisterComponent()
	{
		int num = 19;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.ClickLeftBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.ClickRightBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(14, new Action(this.ClickWeaponBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.ClickFreeRewardBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009162 RID: 37218 RVA: 0x0026535D File Offset: 0x0026355D
	private void ClickLeftBtn()
	{
		this.SetGrandRewardShowIndex(this.SelectGrandRewardIndex - 1);
	}

	// Token: 0x06009163 RID: 37219 RVA: 0x0026536D File Offset: 0x0026356D
	private void ClickRightBtn()
	{
		this.SetGrandRewardShowIndex(this.SelectGrandRewardIndex + 1);
	}

	// Token: 0x06009164 RID: 37220 RVA: 0x00265380 File Offset: 0x00263580
	private void ClickWeaponBtn()
	{
		if (this.SelectGrandRewardIndex < 0 || this.SelectGrandRewardIndex >= this.GrandRewardConfigs.Count)
		{
			return;
		}
		ActivitySignGrandReward? activitySignGrandReward = this.GrandRewardConfigs[this.SelectGrandRewardIndex];
		if (activitySignGrandReward == null || activitySignGrandReward.Value.PreviewType != 2)
		{
			return;
		}
		WeaponTrialData[] array = new WeaponTrialData[activitySignGrandReward.Value.PreviewListLength];
		for (int i = 0; i < array.Length; i++)
		{
			int trialId = activitySignGrandReward.Value.PreviewList(i);
			WeaponTrialData weaponTrialData = new WeaponTrialData();
			weaponTrialData.SetTrialId(trialId, true);
			array[i] = weaponTrialData;
		}
		WeaponPreviewViewParam weaponPreviewViewParam = new WeaponPreviewViewParam();
		WeaponDataBase[] weaponDataList = array;
		weaponPreviewViewParam.WeaponDataList = weaponDataList;
		weaponPreviewViewParam.SelectedIndex = 0;
		IWeaponPreviewViewParam param = weaponPreviewViewParam;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponPreviewView, param, null);
	}

	// Token: 0x06009165 RID: 37221 RVA: 0x00265454 File Offset: 0x00263654
	private void ClickFreeRewardBtn()
	{
		if (this.ActivitySignData != null && !this.ActivitySignData.GetFreeRewardIsGet())
		{
			ControllerBase<ActivitySevenDaySignController>.Instance.GetActivityFreeDrop(this.ActivitySignData.Id);
			return;
		}
		if (this.ActivitySignConfig == null)
		{
			return;
		}
		List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(this.ActivitySignConfig.Value.FreeDropId);
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(dropPackagePreviewItemList[0].ItemData.ItemId, true, null);
	}

	// Token: 0x06009166 RID: 37222 RVA: 0x002654D8 File Offset: 0x002636D8
	private void ClickCharacterDetailBtn()
	{
		if (this.SelectGrandRewardIndex < 0 || this.SelectGrandRewardIndex >= this.GrandRewardConfigs.Count)
		{
			return;
		}
		ActivitySignGrandReward? activitySignGrandReward = this.GrandRewardConfigs[this.SelectGrandRewardIndex];
		if (activitySignGrandReward == null || activitySignGrandReward.Value.PreviewType != 1)
		{
			return;
		}
		ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Preview, 0, activitySignGrandReward.Value.GetPreviewListArray().ToList<int>(), null, null);
	}

	// Token: 0x06009167 RID: 37223 RVA: 0x0026555A File Offset: 0x0026375A
	protected override void OnSetData()
	{
		this.ActivitySignData = (this.ActivityBaseData as ActivitySevenDaySignData);
	}

	// Token: 0x06009168 RID: 37224 RVA: 0x00265570 File Offset: 0x00263770
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySubViewNewcomerSignIn.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewNewcomerSignIn.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009169 RID: 37225 RVA: 0x002655B4 File Offset: 0x002637B4
	protected override void OnStart()
	{
		foreach (int actId in (this.ActivitySignConfig != null) ? this.ActivitySignConfig.GetValueOrDefault().GetGrandRewardIdArray() : null)
		{
			ActivitySignGrandReward? byId = ConfigBase<ActivitySignGrandRewardConfig>.Instance.GetById(actId);
			if (byId != null)
			{
				this.GrandRewardConfigs.Add(byId);
				this.GrandRewardConfigMap.Add(byId.Value.GrandRewardIndex, byId);
			}
		}
		List<OneItemConfig> list = new List<OneItemConfig>();
		int num = 0;
		for (;;)
		{
			int num2 = num;
			int? num3 = (this.ActivitySignConfig != null) ? new int?(this.ActivitySignConfig.GetValueOrDefault().SignRewardsLength) : null;
			if (!(num2 < num3.GetValueOrDefault() & num3 != null))
			{
				break;
			}
			list.Add(((this.ActivitySignConfig != null) ? this.ActivitySignConfig.GetValueOrDefault().SignRewards(num) : null).Value);
			num++;
		}
		this.Layout.RefreshByData(list, null, false);
		this.UpdateGrandRewardInfo();
		if (this.ActivitySignData != null && !this.ActivitySignData.GetFreeRewardIsGet())
		{
			ControllerBase<ActivitySevenDaySignController>.Instance.GetActivityFreeDrop(this.ActivitySignData.Id);
		}
		Activity? activityConfig = ConfigBase<ActivityConfig>.Instance.GetActivityConfig(this.ActivitySignData.Id);
		if (activityConfig != null)
		{
			base.GetText(15).ShowTextNew(activityConfig.Value.Name);
		}
		List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(this.ActivitySignConfig.Value.FreeDropId);
		if (dropPackagePreviewItemList.Count > 0)
		{
			base.GetText(16).SetText("X" + dropPackagePreviewItemList[0].Count.ToString(), true);
		}
		UUITexture texture = base.GetTexture(17);
		UUITexture texture2 = base.GetTexture(18);
		if (texture != null)
		{
			string resourceId = (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male) ? this.NEWCOMER_LOGO_MALE_RESOURCE_ID : this.NEWCOMER_LOGO_FEMALE_RESOURCE_ID;
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			if (resourcePath != null)
			{
				base.SetTextureByPath(resourcePath, texture, null, null);
				base.SetTextureByPath(resourcePath, texture2, null, null);
			}
		}
	}

	// Token: 0x0600916A RID: 37226 RVA: 0x0026580E File Offset: 0x00263A0E
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.CloseGachaSceneView, new Action(this.UpdateGrandRewardInfo));
	}

	// Token: 0x0600916B RID: 37227 RVA: 0x0026582C File Offset: 0x00263A2C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseGachaSceneView, new Action(this.UpdateGrandRewardInfo));
	}

	// Token: 0x0600916C RID: 37228 RVA: 0x0026584C File Offset: 0x00263A4C
	protected override void OnRefreshView()
	{
		List<OneItemConfig> list = new List<OneItemConfig>();
		int num = 0;
		for (;;)
		{
			int num2 = num;
			int? num3 = (this.ActivitySignConfig != null) ? new int?(this.ActivitySignConfig.GetValueOrDefault().SignRewardsLength) : null;
			if (!(num2 < num3.GetValueOrDefault() & num3 != null))
			{
				break;
			}
			list.Add(((this.ActivitySignConfig != null) ? this.ActivitySignConfig.GetValueOrDefault().SignRewards(num) : null).Value);
			num++;
		}
		this.Layout.RefreshByData(list, null, false);
		if (this.ActivitySignData != null)
		{
			base.GetItem(5).SetUIActive(this.ActivitySignData.GetFreeRewardIsGet());
		}
	}

	// Token: 0x0600916D RID: 37229 RVA: 0x00265910 File Offset: 0x00263B10
	private void UpdateGrandRewardInfo()
	{
		int num = this.GrandRewardConfigs.FindIndex((ActivitySignGrandReward? cfg) => this.ActivitySignData != null && this.ActivitySignData.GetRewardStateByDay(cfg.Value.GrandRewardIndex - 1).GetValueOrDefault() != SignState.IsReceive);
		int grandRewardShowIndex = (num >= 0) ? num : 0;
		this.SetGrandRewardShowIndex(grandRewardShowIndex);
	}

	// Token: 0x0600916E RID: 37230 RVA: 0x00265948 File Offset: 0x00263B48
	private void SetGrandRewardShowIndex(int index)
	{
		if (index < 0 || index >= this.GrandRewardConfigs.Count)
		{
			return;
		}
		if (this.SelectGrandRewardIndex == index)
		{
			return;
		}
		base.SetButtonUiActive(1, index > 0);
		base.SetButtonUiActive(2, index < this.GrandRewardConfigs.Count - 1);
		this.SetGrandRewardShow(index);
	}

	// Token: 0x0600916F RID: 37231 RVA: 0x0026599C File Offset: 0x00263B9C
	private void SetGrandRewardShow(int index)
	{
		ActivitySignGrandReward? activitySignGrandReward = this.GrandRewardConfigs[index];
		if (activitySignGrandReward == null)
		{
			return;
		}
		base.GetItem(7).SetUIActive(activitySignGrandReward.Value.PreviewType == 1);
		base.GetItem(8).SetUIActive(activitySignGrandReward.Value.PreviewType == 2);
		int previewType = activitySignGrandReward.Value.PreviewType;
		if (previewType != 1)
		{
			if (previewType == 2)
			{
				int grandRewardIndex = activitySignGrandReward.Value.GrandRewardIndex;
				if (this.ActivitySignConfig != null && grandRewardIndex > 0 && grandRewardIndex <= this.ActivitySignConfig.Value.SignRewardsLength)
				{
					OneItemConfig? oneItemConfig = this.ActivitySignConfig.Value.SignRewards(grandRewardIndex - 1);
					if (oneItemConfig != null)
					{
						CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(oneItemConfig.Value.ItemId);
						if (itemConfigData != null && this.WeaponStarLayout != null)
						{
							this.WeaponStarLayout.RebuildLayout(itemConfigData.QualityId);
						}
					}
				}
				base.GetText(11).ShowTextNew(activitySignGrandReward.Value.GrandTitle);
			}
		}
		else
		{
			TrialRoleInfo? trialRoleConfig = ConfigBase<TrialRoleConfig>.Instance.GetTrialRoleConfig(activitySignGrandReward.Value.PreviewList(0));
			if (this.DescComponent != null && trialRoleConfig != null)
			{
				this.DescComponent.Update(trialRoleConfig.Value.ParentId, false);
				this.DescComponent.SetLookBtnActive(true);
			}
		}
		base.GetText(6).ShowTextNew(activitySignGrandReward.Value.GrandDesc);
		string text = (this.SelectGrandRewardIndex > index) ? "Switch" : "Switch2";
		if (this.GrandRewardItemMap.ContainsKey(this.SelectGrandRewardIndex))
		{
			this.GrandRewardItemMap[this.SelectGrandRewardIndex].SetUIActive(false);
		}
		if (!this.GrandRewardItemMap.ContainsKey(index))
		{
			this.LoadGrandRewardItem(index, text);
		}
		else
		{
			this.GrandRewardItemMap[index].SetUIActive(true);
			this.PlaySubViewSequence(text, false);
		}
		this.SelectGrandRewardIndex = index;
	}

	// Token: 0x06009170 RID: 37232 RVA: 0x00265BC4 File Offset: 0x00263DC4
	private UniTask LoadGrandRewardItem(int index, string switchAnim)
	{
		ActivitySubViewNewcomerSignIn.<LoadGrandRewardItem>d__28 <LoadGrandRewardItem>d__;
		<LoadGrandRewardItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadGrandRewardItem>d__.<>4__this = this;
		<LoadGrandRewardItem>d__.index = index;
		<LoadGrandRewardItem>d__.switchAnim = switchAnim;
		<LoadGrandRewardItem>d__.<>1__state = -1;
		<LoadGrandRewardItem>d__.<>t__builder.Start<ActivitySubViewNewcomerSignIn.<LoadGrandRewardItem>d__28>(ref <LoadGrandRewardItem>d__);
		return <LoadGrandRewardItem>d__.<>t__builder.Task;
	}

	// Token: 0x06009171 RID: 37233 RVA: 0x00265C17 File Offset: 0x00263E17
	protected override void OnSequenceStart(string sequenceName)
	{
		if (sequenceName == "Start")
		{
			GenericLayout<NewcomerSignInItem, OneItemConfig> layout = this.Layout;
			if (layout == null)
			{
				return;
			}
			UUIInturnAnimController uiAnimController = layout.GetUiAnimController();
			if (uiAnimController == null)
			{
				return;
			}
			uiAnimController.Play("", -1, false);
		}
	}

	// Token: 0x06009172 RID: 37234 RVA: 0x00265C47 File Offset: 0x00263E47
	private NewcomerSignInItem InitItem()
	{
		NewcomerSignInItem newcomerSignInItem = new NewcomerSignInItem();
		newcomerSignInItem.SetActivityData(this.ActivitySignData);
		newcomerSignInItem.SetGrandRewardConfigMap(this.GrandRewardConfigMap);
		return newcomerSignInItem;
	}

	// Token: 0x06009173 RID: 37235 RVA: 0x00265C68 File Offset: 0x00263E68
	protected override void OnTimer(float gap)
	{
		if (this.ActivityBaseData == null)
		{
			return;
		}
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(this.ActivityBaseData, null);
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		UUIText text = base.GetText(19);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(item);
		text.SetText(item2, true);
	}

	// Token: 0x04004381 RID: 17281
	private string NEWCOMER_LOGO_MALE_RESOURCE_ID = "T_NewcomerLogoMale";

	// Token: 0x04004382 RID: 17282
	private string NEWCOMER_LOGO_FEMALE_RESOURCE_ID = "T_NewcomerLogoFemale";

	// Token: 0x04004383 RID: 17283
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<NewcomerSignInItem, OneItemConfig> Layout;

	// Token: 0x04004384 RID: 17284
	[Nullable(2)]
	private ActivitySevenDaySignData ActivitySignData;

	// Token: 0x04004385 RID: 17285
	private ActivitySign? ActivitySignConfig;

	// Token: 0x04004386 RID: 17286
	[Nullable(2)]
	private global::RoleDescribeComponent DescComponent;

	// Token: 0x04004387 RID: 17287
	private readonly List<ActivitySignGrandReward?> GrandRewardConfigs = new List<ActivitySignGrandReward?>();

	// Token: 0x04004388 RID: 17288
	private readonly Dictionary<int, ActivitySignGrandReward?> GrandRewardConfigMap = new Dictionary<int, ActivitySignGrandReward?>();

	// Token: 0x04004389 RID: 17289
	private readonly Dictionary<int, UUIItem> GrandRewardItemMap = new Dictionary<int, UUIItem>();

	// Token: 0x0400438A RID: 17290
	private readonly HashSet<int> GrandRewardLoadSet = new HashSet<int>();

	// Token: 0x0400438B RID: 17291
	[Nullable(2)]
	private SimpleGenericLayout WeaponStarLayout;

	// Token: 0x0400438C RID: 17292
	private int SelectGrandRewardIndex = -1;

	// Token: 0x0200785D RID: 30813
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029652 RID: 169554
		public const int RewardContent = 0;

		// Token: 0x04029653 RID: 169555
		public const int LeftBtn = 1;

		// Token: 0x04029654 RID: 169556
		public const int RightBtn = 2;

		// Token: 0x04029655 RID: 169557
		public const int BtnFreeReward = 3;

		// Token: 0x04029656 RID: 169558
		public const int PnlNml = 4;

		// Token: 0x04029657 RID: 169559
		public const int PnlGot = 5;

		// Token: 0x04029658 RID: 169560
		public const int GrandRewardText = 6;

		// Token: 0x04029659 RID: 169561
		public const int GrandRoleItem = 7;

		// Token: 0x0402965A RID: 169562
		public const int GrandWeaponItem = 8;

		// Token: 0x0402965B RID: 169563
		public const int Layout = 9;

		// Token: 0x0402965C RID: 169564
		public const int GridItem = 10;

		// Token: 0x0402965D RID: 169565
		public const int WeaponText = 11;

		// Token: 0x0402965E RID: 169566
		public const int WeaponStarLayout = 12;

		// Token: 0x0402965F RID: 169567
		public const int WeaponStarItem = 13;

		// Token: 0x04029660 RID: 169568
		public const int LookWeaponBtn = 14;

		// Token: 0x04029661 RID: 169569
		public const int TitleText = 15;

		// Token: 0x04029662 RID: 169570
		public const int RewardCountText = 16;

		// Token: 0x04029663 RID: 169571
		public const int TitleLogo = 17;

		// Token: 0x04029664 RID: 169572
		public const int TitleLogo2 = 18;

		// Token: 0x04029665 RID: 169573
		public const int TitleSubText = 19;
	}
}
