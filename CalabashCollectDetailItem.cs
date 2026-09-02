using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020017ED RID: 6125
[NullableContext(2)]
[Nullable(0)]
public class CalabashCollectDetailItem : UiPanelBase
{
	// Token: 0x0600AE07 RID: 44551 RVA: 0x002E4290 File Offset: 0x002E2490
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(10, new Action(this.OnPositionBtnClick)),
			new ValueTuple<int, Delegate>(7, new Action(this.OnHelpBtnClick)),
			new ValueTuple<int, Delegate>(11, this.OnLookOverBtnClick),
			new ValueTuple<int, Delegate>(15, new Action(this.OnMonsterSkinBtnClick))
		};
	}

	// Token: 0x0600AE08 RID: 44552 RVA: 0x002E4478 File Offset: 0x002E2678
	private void OnPositionBtnClick()
	{
		CalabashDevelopReward? calabashDevelopReward;
		ControllerBase<AdventureGuideController>.Instance.JumpToTargetView(EUiTabViewName.MonsterDetectView, (ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(this.PhantomId) != null) ? new int?(calabashDevelopReward.GetValueOrDefault().MonsterProbeId) : null, null);
	}

	// Token: 0x0600AE09 RID: 44553 RVA: 0x002E44D0 File Offset: 0x002E26D0
	private void OnHelpBtnClick()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.CalabashCollectSuitTipId);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600AE0A RID: 44554 RVA: 0x002E44F4 File Offset: 0x002E26F4
	private void OnMonsterSkinBtnClick()
	{
		if (this.SkinList == null)
		{
			return;
		}
		this.ShowSkinIndex++;
		if (this.ShowSkinIndex >= this.SkinList.Length)
		{
			this.ShowSkinIndex = 0;
		}
		if (this.OnMonsterSkinBtnClickCallBack != null)
		{
			int monsterId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(this.SkinList[this.ShowSkinIndex]).Value.MonsterId;
			bool flag = (this.ShowSkinIndex == 0) ? (!this.Data.UnlockData) : (this.ShowSkinIndex > 0 && !ModelBase<PhantomBattleModel>.Instance.GetSkinIsUnlock(this.SkinList[this.ShowSkinIndex]));
			this.OnMonsterSkinBtnClickCallBack(monsterId, flag);
			base.GetButton(11).RootUIComp.Get().SetUIActive(!flag);
		}
	}

	// Token: 0x0600AE0B RID: 44555 RVA: 0x002E45D0 File Offset: 0x002E27D0
	protected override UniTask OnBeforeStartAsync()
	{
		CalabashCollectDetailItem.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CalabashCollectDetailItem.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AE0C RID: 44556 RVA: 0x002E4613 File Offset: 0x002E2813
	private void OnSuitItemClick(int id)
	{
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.JumpToPhantomBattleFettersTabView, id);
	}

	// Token: 0x0600AE0D RID: 44557 RVA: 0x002E4626 File Offset: 0x002E2826
	[NullableContext(1)]
	private VisionFetterSuitItem CreateVisionFetterSuitItem()
	{
		return new VisionFetterSuitItem(null)
		{
			OnItemClick = new Action<int>(this.OnSuitItemClick)
		};
	}

	// Token: 0x0600AE0E RID: 44558 RVA: 0x002E4640 File Offset: 0x002E2840
	[NullableContext(1)]
	public void Update(CalabashDevelopRewardData data)
	{
		this.Data = data;
		CalabashDevelopRewardData data2 = this.Data;
		this.PhantomId = ((data2 != null) ? data2.DevelopRewardData.MonsterId : 0);
		int[] phantomItemIdArrayByMonsterId = ModelBase<PhantomBattleModel>.Instance.GetPhantomItemIdArrayByMonsterId(this.PhantomId);
		this.ItemConfig = ConfigBase<InventoryConfig>.Instance.GetPhantomItemConfig(phantomItemIdArrayByMonsterId[0]);
		this.Refresh();
	}

	// Token: 0x0600AE0F RID: 44559 RVA: 0x002E46A0 File Offset: 0x002E28A0
	public void UpdateSkinInfo(int data)
	{
		this.PhantomId = data;
		int[] phantomItemIdArrayByMonsterId = ModelBase<PhantomBattleModel>.Instance.GetPhantomItemIdArrayByMonsterId(this.PhantomId);
		this.ItemConfig = ConfigBase<InventoryConfig>.Instance.GetPhantomItemConfig(phantomItemIdArrayByMonsterId[0]);
		if (this.ShowSkinIndex != 0)
		{
			this.RefreshTitleBySkinId();
			return;
		}
		this.RefreshTitle();
	}

	// Token: 0x0600AE10 RID: 44560 RVA: 0x002E46ED File Offset: 0x002E28ED
	public void Refresh()
	{
		this.RefreshTitle();
		this.RefreshStage();
		this.RefreshSuit();
		this.RefreshDesc();
		this.RefreshInfoItem();
		this.RefreshSkinBtn();
	}

	// Token: 0x0600AE11 RID: 44561 RVA: 0x002E4714 File Offset: 0x002E2914
	public void RefreshTitle()
	{
		CalabashDevelopRewardData data = this.Data;
		if (!data.UnlockData)
		{
			return;
		}
		string monsterNumber = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(this.PhantomId).Value.MonsterNumber;
		IReadOnlyList<PhantomItem> phantomItemByMonsterId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(this.PhantomId);
		PhantomRarity? phantomRareConfig = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(phantomItemByMonsterId[0].Rarity);
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(data.SkillName, null);
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetText(monsterNumber + localTextNew, true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), phantomRareConfig.Value.Desc, Array.Empty<object>());
	}

	// Token: 0x0600AE12 RID: 44562 RVA: 0x002E47D0 File Offset: 0x002E29D0
	public void RefreshTitleBySkinId()
	{
		if (!this.Data.UnlockData)
		{
			return;
		}
		string monsterNumber = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(this.PhantomId).Value.MonsterNumber;
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(this.ItemConfig.Value.MonsterName, null);
		UUIText text = base.GetText(0);
		if (text == null)
		{
			return;
		}
		text.SetText(monsterNumber + localTextNew, true);
	}

	// Token: 0x0600AE13 RID: 44563 RVA: 0x002E4840 File Offset: 0x002E2A40
	public void RefreshStage()
	{
		ICalabashDevelopRewardInfoData[] calabashDevelopRewardInfoData = ModelBase<CalabashModel>.Instance.GetCalabashDevelopRewardInfoData(this.PhantomId);
		if (calabashDevelopRewardInfoData == null || calabashDevelopRewardInfoData.Length != this.StageItemList.Count)
		{
			return;
		}
		int num = calabashDevelopRewardInfoData.Length;
		int num2 = -1;
		for (int i = 0; i < this.StageItemList.Count; i++)
		{
			ICalabashDevelopRewardInfoData calabashDevelopRewardInfoData2 = calabashDevelopRewardInfoData[i];
			this.StageItemList[i].Refresh(calabashDevelopRewardInfoData2, false, i);
			if (calabashDevelopRewardInfoData2.IsUnlock)
			{
				num2 = i;
			}
		}
		UUITexture texture = base.GetTexture(2);
		if (texture == null)
		{
			return;
		}
		texture.SetFillAmount((float)num2 / (float)(num - 1));
	}

	// Token: 0x0600AE14 RID: 44564 RVA: 0x002E48CC File Offset: 0x002E2ACC
	public void RefreshSuit()
	{
		int[] array = this.ItemConfig.Value.FetterGroup();
		List<PhantomFetterGroup> list = new List<PhantomFetterGroup>();
		foreach (int groupId in array)
		{
			PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(groupId);
			list.Add(fetterGroupById);
		}
		GenericLayout<VisionFetterSuitItem, PhantomFetterGroup> suitLayout = this.SuitLayout;
		if (suitLayout == null)
		{
			return;
		}
		suitLayout.RefreshByData(list, null, false);
	}

	// Token: 0x0600AE15 RID: 44565 RVA: 0x002E4930 File Offset: 0x002E2B30
	public void RefreshDesc()
	{
		PhantomSkill? phantomSkillBySkillId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillBySkillId(this.ItemConfig.Value.SkillId);
		if (phantomSkillBySkillId == null || StringUtils.IsEmpty(phantomSkillBySkillId.Value.SimplyDescription))
		{
			base.GetText(9).SetText("", true);
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), phantomSkillBySkillId.Value.SimplyDescription, Array.Empty<object>());
	}

	// Token: 0x0600AE16 RID: 44566 RVA: 0x002E49B4 File Offset: 0x002E2BB4
	public void RefreshInfoItem()
	{
		base.GetItem(12).SetUIActive(this.Data.UnlockData);
		base.GetButton(11).RootUIComp.Get().SetUIActive(this.Data.UnlockData);
	}

	// Token: 0x0600AE17 RID: 44567 RVA: 0x002E4A00 File Offset: 0x002E2C00
	public void RefreshSkinBtn()
	{
		int[] monsterSkinListByMonsterId = ModelBase<PhantomBattleModel>.Instance.GetMonsterSkinListByMonsterId(this.Data.DevelopRewardData.MonsterId);
		if (monsterSkinListByMonsterId == null)
		{
			base.GetButton(15).RootUIComp.Get().SetUIActive(false);
			return;
		}
		base.GetButton(15).RootUIComp.Get().SetUIActive(this.Data.UnlockData && monsterSkinListByMonsterId.Length > 1);
		this.SkinList = monsterSkinListByMonsterId;
		this.ShowSkinIndex = 0;
	}

	// Token: 0x0600AE18 RID: 44568 RVA: 0x002E4A88 File Offset: 0x002E2C88
	public void RefreshDetailState()
	{
		bool ifSimpleState = ModelBase<CalabashModel>.Instance.GetIfSimpleState();
		UUIItem item = base.GetItem(14);
		if (item != null)
		{
			item.SetUIActive(!ifSimpleState);
		}
		UUIItem item2 = base.GetItem(13);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(!ifSimpleState);
	}

	// Token: 0x0600AE19 RID: 44569 RVA: 0x002E4AD0 File Offset: 0x002E2CD0
	public void PlayDetailShowSequence()
	{
		LevelSequencePlayer infoLevelSequencePlayer = this.InfoLevelSequencePlayer;
		if (infoLevelSequencePlayer == null)
		{
			return;
		}
		infoLevelSequencePlayer.PlayLevelSequenceByName("Start", true, null, false);
	}

	// Token: 0x0600AE1A RID: 44570 RVA: 0x002E4B00 File Offset: 0x002E2D00
	public void PlayDetailHideSequence()
	{
		UUIItem item = base.GetItem(14);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		UUIItem item2 = base.GetItem(13);
		if (item2 != null)
		{
			item2.SetUIActive(true);
		}
		LevelSequencePlayer infoLevelSequencePlayer = this.InfoLevelSequencePlayer;
		if (infoLevelSequencePlayer == null)
		{
			return;
		}
		infoLevelSequencePlayer.PlayLevelSequenceByName("Close", true, null, false);
	}

	// Token: 0x04005261 RID: 21089
	private int PhantomId;

	// Token: 0x04005262 RID: 21090
	private CalabashDevelopRewardData Data;

	// Token: 0x04005263 RID: 21091
	private PhantomItem? ItemConfig;

	// Token: 0x04005264 RID: 21092
	[Nullable(1)]
	private readonly List<CalabashCollectStageItem> StageItemList = new List<CalabashCollectStageItem>();

	// Token: 0x04005265 RID: 21093
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<VisionFetterSuitItem, PhantomFetterGroup> SuitLayout;

	// Token: 0x04005266 RID: 21094
	private LevelSequencePlayer InfoLevelSequencePlayer;

	// Token: 0x04005267 RID: 21095
	private int[] SkinList;

	// Token: 0x04005268 RID: 21096
	private int ShowSkinIndex;

	// Token: 0x04005269 RID: 21097
	public Action OnLookOverBtnClick;

	// Token: 0x0400526A RID: 21098
	public Action<int, bool> OnMonsterSkinBtnClickCallBack;

	// Token: 0x02007B64 RID: 31588
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A2DF RID: 172767
		NameText,
		// Token: 0x0402A2E0 RID: 172768
		LevelText,
		// Token: 0x0402A2E1 RID: 172769
		StageBarTexture,
		// Token: 0x0402A2E2 RID: 172770
		StageItem1,
		// Token: 0x0402A2E3 RID: 172771
		StageItem2,
		// Token: 0x0402A2E4 RID: 172772
		StageItem3,
		// Token: 0x0402A2E5 RID: 172773
		StageItem4,
		// Token: 0x0402A2E6 RID: 172774
		HelpBtn,
		// Token: 0x0402A2E7 RID: 172775
		SuitLayout,
		// Token: 0x0402A2E8 RID: 172776
		DescText,
		// Token: 0x0402A2E9 RID: 172777
		PositionBtn,
		// Token: 0x0402A2EA RID: 172778
		LookOverBtn,
		// Token: 0x0402A2EB RID: 172779
		InfoItem,
		// Token: 0x0402A2EC RID: 172780
		SuitItem,
		// Token: 0x0402A2ED RID: 172781
		DescItem,
		// Token: 0x0402A2EE RID: 172782
		MonsterSkinBtn
	}
}
