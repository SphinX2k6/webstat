using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.Kurotato.View.Components;
using CSharpScript.Game.Module.Kurotato.View.Settlement;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.KurotatoLevelSelect
{
	// Token: 0x02005AAF RID: 23215
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoLevelSelectView : UiTickViewBase
	{
		// Token: 0x0603AB54 RID: 240468 RVA: 0x00EE1848 File Offset: 0x00EDFA48
		public KurotatoLevelSelectView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603AB55 RID: 240469 RVA: 0x00EE1864 File Offset: 0x00EDFA64
		protected unsafe override void OnRegisterComponent()
		{
			int num = 27;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIMultiTemplateScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(25, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnMonsterHandbookBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AB56 RID: 240470 RVA: 0x00EE1C58 File Offset: 0x00EDFE58
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoLevelSelectView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoLevelSelectView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AB57 RID: 240471 RVA: 0x00EE1C9C File Offset: 0x00EDFE9C
		protected override void OnBeforeShow()
		{
			this.RefreshRecordInfo();
			this.InitScrollViewData();
			this.SelectedIndex = this.GetSelectedLevelIndex();
			MultiTemplateScrollViewRefreshContext multiTemplateScrollViewRefreshContext = new MultiTemplateScrollViewRefreshContext(this.ScrollDataList);
			multiTemplateScrollViewRefreshContext.ScrollToGridIndex = this.SelectedIndex;
			multiTemplateScrollViewRefreshContext.GridAnimName = "Start";
			multiTemplateScrollViewRefreshContext.PlayGridAnim = true;
			this.LevelMultiTemplateScrollView.RefreshByData(multiTemplateScrollViewRefreshContext);
			KurotatoLevelItem kurotatoLevelItem = this.LevelMultiTemplateScrollView.GetProxyByGridIndex(this.SelectedIndex) as KurotatoLevelItem;
			if (kurotatoLevelItem != null)
			{
				this.OnItemClick(kurotatoLevelItem.Id, this.SelectedIndex);
			}
			this.RefreshArchiveItem();
			KurotatoLevelGroup? levelGroupConfig = ConfigBase<KurotatoConfig>.Instance.GetLevelGroupConfig((int)this.LevelSelectViewData.LevelMode);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(22), levelGroupConfig.Value.Name, Array.Empty<object>());
		}

		// Token: 0x0603AB58 RID: 240472 RVA: 0x00EE1D65 File Offset: 0x00EDFF65
		protected override void OnTick(float delta)
		{
			this.RefreshLockText();
		}

		// Token: 0x0603AB59 RID: 240473 RVA: 0x00EE1D70 File Offset: 0x00EDFF70
		private void RefreshRecordInfo()
		{
			bool flag = this.LevelSelectViewData.LevelMode == EKurotatoLevelMode.Endless;
			UUIItem item = base.GetItem(23);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			UUIItem item2 = base.GetItem(12);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(!flag);
		}

		// Token: 0x0603AB5A RID: 240474 RVA: 0x00EE1DB8 File Offset: 0x00EDFFB8
		private void InitScrollViewData()
		{
			this.ScrollDataList = new List<IMultiTemplateGridData>();
			foreach (int num in ConfigBase<KurotatoConfig>.Instance.GetLevelGroupConfig((int)this.LevelSelectViewData.LevelMode).Value.SecondGroupIter())
			{
				KurotatoLevelSecondGroup? levelSecondGroupConfig = ConfigBase<KurotatoConfig>.Instance.GetLevelSecondGroupConfig(num);
				KurotatoLevelTitleItemData data = new KurotatoLevelTitleItemData
				{
					TextId = levelSecondGroupConfig.Value.Name,
					BgPath = levelSecondGroupConfig.Value.TitleBg
				};
				KurotatoLevelTitleItemTemplateData kurotatoLevelTitleItemTemplateData = new KurotatoLevelTitleItemTemplateData();
				kurotatoLevelTitleItemTemplateData.Data = data;
				this.ScrollDataList.Add(kurotatoLevelTitleItemTemplateData);
				foreach (KurotatoLevel kurotatoLevel in ConfigBase<KurotatoConfig>.Instance.GetLevelListBySecondGroup(num))
				{
					KurotatoLevelItemTemplateData kurotatoLevelItemTemplateData = new KurotatoLevelItemTemplateData();
					kurotatoLevelItemTemplateData.Data = kurotatoLevel.Id;
					kurotatoLevelItemTemplateData.OnClickCb = new Action<int, int>(this.OnItemClick);
					kurotatoLevelItemTemplateData.IsSelected = new Func<int, bool>(this.IsSelected);
					this.ScrollDataList.Add(kurotatoLevelItemTemplateData);
				}
			}
		}

		// Token: 0x0603AB5B RID: 240475 RVA: 0x00EE1F14 File Offset: 0x00EE0114
		private int GetSelectedLevelIndex()
		{
			for (int i = 0; i < this.ScrollDataList.Count; i++)
			{
				KurotatoLevelItemTemplateData kurotatoLevelItemTemplateData = this.ScrollDataList[i] as KurotatoLevelItemTemplateData;
				if (kurotatoLevelItemTemplateData != null && kurotatoLevelItemTemplateData.Data == this.LevelSelectViewData.LevelId)
				{
					return i;
				}
			}
			return 1;
		}

		// Token: 0x0603AB5C RID: 240476 RVA: 0x00EE1F62 File Offset: 0x00EE0162
		private void RefreshView()
		{
			this.RefreshLevelBasicInfo();
			this.RefreshTargetList();
			this.RefreshRewardPanel();
			this.RefreshUnlockRolePanel();
			this.RefreshLimitRolePanel();
			this.RefreshEndlessInfo();
			this.RefreshBottomInfo();
		}

		// Token: 0x0603AB5D RID: 240477 RVA: 0x00EE1F90 File Offset: 0x00EE0190
		private void RefreshLevelBasicInfo()
		{
			KurotatoLevel? levelConfig = ConfigBase<KurotatoConfig>.Instance.GetLevelConfig(this.SelectedLevelData.Id);
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.SetText(this.SelectedLevelData.Number, true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), this.SelectedLevelData.Name, Array.Empty<object>());
			base.SetTextureByPath(levelConfig.Value.Picture, base.GetTexture(6), null, null);
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), levelConfig.Value.DetailDesc, new <>z__ReadOnlySingleElementList<object>(levelConfig.Value.DetailDescParamsIter()));
		}

		// Token: 0x0603AB5E RID: 240478 RVA: 0x00EE2060 File Offset: 0x00EE0260
		private void RefreshTargetList()
		{
			KurotatoLevel? levelConfig = ConfigBase<KurotatoConfig>.Instance.GetLevelConfig(this.SelectedLevelData.Id);
			List<KurotatoLevelTargetItemData> list = new List<KurotatoLevelTargetItemData>();
			foreach (string text in levelConfig.Value.TargetDescIter())
			{
				KurotatoLevelTargetItemData item = new KurotatoLevelTargetItemData
				{
					Text = text,
					IsFinish = (this.SelectedLevelData.IsFinished && !this.SelectedLevelData.IsEndless),
					IsEndless = this.SelectedLevelData.IsEndless
				};
				list.Add(item);
			}
			GenericScrollViewNew<KurotatoLevelTargetItem, KurotatoLevelTargetItemData> targetScroll = this.TargetScroll;
			if (targetScroll == null)
			{
				return;
			}
			targetScroll.RefreshByData(list, delegate
			{
				GenericScrollViewNew<KurotatoLevelTargetItem, KurotatoLevelTargetItemData> targetScroll2 = this.TargetScroll;
				if (targetScroll2 == null)
				{
					return;
				}
				targetScroll2.ScrollToTop(0);
			}, true);
		}

		// Token: 0x0603AB5F RID: 240479 RVA: 0x00EE2138 File Offset: 0x00EE0338
		private void RefreshRewardPanel()
		{
			List<IKurotatoSmallItemGridData> sortedRewardList = this.GetSortedRewardList(ConfigBase<KurotatoConfig>.Instance.GetLevelConfig(this.SelectedLevelData.Id).Value);
			UUIItem item = base.GetItem(21);
			if (item != null)
			{
				item.SetUIActive(sortedRewardList.Count > 0);
			}
			if (sortedRewardList.Count > 0)
			{
				GenericScrollViewNew<KurotatoWeaponSmallItemGrid, IKurotatoSmallItemGridData> rewardScroll = this.RewardScroll;
				if (rewardScroll == null)
				{
					return;
				}
				rewardScroll.RefreshByData(sortedRewardList, delegate
				{
					GenericScrollViewNew<KurotatoWeaponSmallItemGrid, IKurotatoSmallItemGridData> rewardScroll2 = this.RewardScroll;
					if (rewardScroll2 == null)
					{
						return;
					}
					rewardScroll2.ScrollToLeft(0);
				}, true);
			}
		}

		// Token: 0x0603AB60 RID: 240480 RVA: 0x00EE21AC File Offset: 0x00EE03AC
		private List<IKurotatoSmallItemGridData> GetSortedRewardList(KurotatoLevel levelConfig)
		{
			List<IKurotatoSmallItemGridData> list = new List<IKurotatoSmallItemGridData>();
			list.AddRange(this.SortRewardByQuality(levelConfig.UnLockedWeaponsIter().ToList<int>(), EKurotatoCardType.Weapon));
			list.AddRange(this.SortRewardByQuality(levelConfig.UnLockedItemsIter().ToList<int>(), EKurotatoCardType.Item));
			return list;
		}

		// Token: 0x0603AB61 RID: 240481 RVA: 0x00EE21E8 File Offset: 0x00EE03E8
		private List<IKurotatoSmallItemGridData> SortRewardByQuality(List<int> ids, EKurotatoCardType cardType)
		{
			KurotatoConfig kurotatoConfig = ConfigBase<KurotatoConfig>.Instance;
			List<int> list = new List<int>(ids);
			list.Sort(delegate(int a, int b)
			{
				int num = base.<SortRewardByQuality>g__GetQuality|0(a);
				int num2 = base.<SortRewardByQuality>g__GetQuality|0(b);
				if (num != num2)
				{
					return num2 - num;
				}
				return a - b;
			});
			return (from id in list
			select new KurotatoSmallItemGridData
			{
				Type = cardType,
				Id = id,
				IncId = 0,
				Count = 1,
				IsReceived = new bool?(this.SelectedLevelData.IsFinished)
			}).ToList<IKurotatoSmallItemGridData>();
		}

		// Token: 0x0603AB62 RID: 240482 RVA: 0x00EE2244 File Offset: 0x00EE0444
		private void RefreshUnlockRolePanel()
		{
			List<int> list = ConfigBase<KurotatoConfig>.Instance.GetLevelConfig(this.SelectedLevelData.Id).Value.UnlockCharactersIter().ToList<int>();
			int? num = (list.Count > 0) ? new int?(list[0]) : null;
			KurotatoLevelUnlockRolePanel unlockRolePanel = this.UnlockRolePanel;
			if (unlockRolePanel != null)
			{
				unlockRolePanel.SetUiActive(num != null && !this.SelectedLevelData.IsEndless);
			}
			if (num != null && num.Value != 0)
			{
				KurotatoLevelUnlockRolePanel unlockRolePanel2 = this.UnlockRolePanel;
				if (unlockRolePanel2 == null)
				{
					return;
				}
				unlockRolePanel2.Refresh(num.Value);
			}
		}

		// Token: 0x0603AB63 RID: 240483 RVA: 0x00EE22F4 File Offset: 0x00EE04F4
		private void RefreshLimitRolePanel()
		{
			int limitRoleId = this.GetLimitRoleId(ConfigBase<KurotatoConfig>.Instance.GetLevelConfig(this.SelectedLevelData.Id).Value.CharactersIter().ToList<int>());
			UUIItem item = base.GetItem(24);
			if (item != null)
			{
				item.SetUIActive(limitRoleId != 0);
			}
			if (limitRoleId == 0)
			{
				return;
			}
			KurotatoRoleData kurotatoRoleData = this.ActivityData.GetKurotatoRoleData(limitRoleId);
			base.SetTextureByPath(ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(kurotatoRoleData.RealRoleSkinId).Value.RoleHeadIconLarge, base.GetTexture(25), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(26), kurotatoRoleData.Name, Array.Empty<object>());
		}

		// Token: 0x0603AB64 RID: 240484 RVA: 0x00EE23B4 File Offset: 0x00EE05B4
		private int GetLimitRoleId(IReadOnlyList<int> characters)
		{
			if (characters.Count == 0)
			{
				return 0;
			}
			if (characters.Count == 1)
			{
				return characters[0];
			}
			List<KurotatoRoleData> kurotatoRoleList = this.ActivityData.GetKurotatoRoleList();
			using (IEnumerator<int> enumerator = characters.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int id = enumerator.Current;
					if (kurotatoRoleList.Any((KurotatoRoleData data) => data.Id == id))
					{
						return id;
					}
				}
			}
			return characters[0];
		}

		// Token: 0x0603AB65 RID: 240485 RVA: 0x00EE2450 File Offset: 0x00EE0650
		private void RefreshEndlessInfo()
		{
			if (!this.SelectedLevelData.IsEndless)
			{
				return;
			}
			KurotatoEndlessHistoryPanel endlessHistoryPanel = this.EndlessHistoryPanel;
			if (endlessHistoryPanel == null)
			{
				return;
			}
			endlessHistoryPanel.Refresh(this.SelectedLevelData);
		}

		// Token: 0x0603AB66 RID: 240486 RVA: 0x00EE2478 File Offset: 0x00EE0678
		private void RefreshBottomInfo()
		{
			bool hasArchivedData = this.SelectedLevelData.HasArchivedData;
			UUIItem item = base.GetItem(14);
			if (item != null)
			{
				item.SetUIActive(this.SelectedLevelData.IsUnLock);
			}
			UUIItem item2 = base.GetItem(19);
			if (item2 != null)
			{
				item2.SetUIActive(!this.SelectedLevelData.IsUnLock);
			}
			UUIItem item3 = base.GetItem(16);
			if (item3 != null)
			{
				item3.SetUIActive(hasArchivedData);
			}
			UUIItem item4 = base.GetItem(18);
			if (item4 != null)
			{
				item4.SetUIActive(!hasArchivedData);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(17), this.SelectedLevelData.IsArchiveSpecialWave ? "Kurotato_Special_Boss_Prograss" : "Kurotato_Level_Select_Progress", new <>z__ReadOnlyArray<object>(new object[]
			{
				this.SelectedLevelData.ArchiveWave,
				this.SelectedLevelData.TotalWave
			}));
			string textId = hasArchivedData ? "Kurotato_Level_Select_Continue" : "Kurotato_Level_Select_Start";
			ButtonItem gotoBtn = this.GotoBtn;
			if (gotoBtn == null)
			{
				return;
			}
			gotoBtn.SetLocalTextNew(textId, Array.Empty<object>());
		}

		// Token: 0x0603AB67 RID: 240487 RVA: 0x00EE2580 File Offset: 0x00EE0780
		private void RefreshLockText()
		{
			if (this.SelectedLevelData == null || this.SelectedLevelData.IsUnLock)
			{
				return;
			}
			if (this.SelectedLevelData.IsReachUnlockTime())
			{
				KurotatoLevel? levelConfig = ConfigBase<KurotatoConfig>.Instance.GetLevelConfig(this.SelectedLevelData.PreId);
				string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(levelConfig.Value.Name);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(20), "Kurotato_Level_Select_UnlockTip", new <>z__ReadOnlySingleElementList<object>(multiTextByKey));
				return;
			}
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("Kurotato_Level_Select_UnlockTip2", null);
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.SelectedLevelData.UnlockTime, localTextNew);
			UUIText text = base.GetText(20);
			if (text == null)
			{
				return;
			}
			text.SetText(remainTimeText, true);
		}

		// Token: 0x0603AB68 RID: 240488 RVA: 0x00EE2638 File Offset: 0x00EE0838
		private void OnItemClick(int id, int index)
		{
			this.LevelSelectViewData.LevelId = id;
			this.SelectedLevelData = this.ActivityData.GetKurotatoLevelData(id);
			this.LevelMultiTemplateScrollView.RefreshProxyDirectly(this.SelectedIndex);
			this.SelectedIndex = index;
			this.LevelMultiTemplateScrollView.RefreshProxyDirectly(index);
			this.RefreshView();
			this.RefreshArchiveItem();
			base.PlayOrReplaySequence("Switch", false, null);
		}

		// Token: 0x0603AB69 RID: 240489 RVA: 0x00EE26AA File Offset: 0x00EE08AA
		private bool IsSelected(int id)
		{
			return this.LevelSelectViewData.LevelId == id;
		}

		// Token: 0x0603AB6A RID: 240490 RVA: 0x00EE26BC File Offset: 0x00EE08BC
		private void OnRewardToggleClickCallback(IKurotatoSmallItemGridData cardData)
		{
			List<IKurotatoSmallItemGridData> sortedRewardList = this.GetSortedRewardList(ConfigBase<KurotatoConfig>.Instance.GetLevelConfig(this.LevelSelectViewData.LevelId).Value);
			List<KurotatoCardTip> cardData2 = (from entry in sortedRewardList
			select new KurotatoCardTip
			{
				CardType = entry.Type,
				SelectId = entry.Id,
				IsConfigId = new bool?(true)
			}).ToList<KurotatoCardTip>();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoPopupWeaponDetailView, new KurotatoPopupItemDetailOpenParam
			{
				Index = sortedRewardList.FindIndex((IKurotatoSmallItemGridData entry) => entry.Type == cardData.Type && entry.Id == cardData.Id),
				CardData = cardData2,
				IsOutSide = new bool?(true)
			}, null);
		}

		// Token: 0x0603AB6B RID: 240491 RVA: 0x00EE2768 File Offset: 0x00EE0968
		private KurotatoWeaponSmallItemGrid CreateRewardItem()
		{
			KurotatoWeaponSmallItemGrid item = new KurotatoWeaponSmallItemGrid(false);
			item.BindCallback(delegate(IKurotatoSmallItemGridData data, EToggleState state, int gridIndex)
			{
				if (state != EToggleState.ETT_Checked)
				{
					return;
				}
				item.SetSelected(false, false);
				this.OnRewardToggleClickCallback(data);
			});
			return item;
		}

		// Token: 0x0603AB6C RID: 240492 RVA: 0x00EE27AB File Offset: 0x00EE09AB
		private KurotatoLevelTargetItem CreateTargetItem()
		{
			return new KurotatoLevelTargetItem();
		}

		// Token: 0x0603AB6D RID: 240493 RVA: 0x00EE27B4 File Offset: 0x00EE09B4
		private void OnUnlockRoleBtnClick(int roleId)
		{
			List<int> list = ConfigBase<KurotatoConfig>.Instance.GetLevelConfig(this.SelectedLevelData.Id).Value.UnlockCharactersIter().ToList<int>();
			int index = list.IndexOf(roleId);
			KurotatoPopupUnlockRoleOpenParam param = new KurotatoPopupUnlockRoleOpenParam
			{
				RoleIds = list,
				Index = index
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoPopupUnlockRoleView, param, null);
		}

		// Token: 0x0603AB6E RID: 240494 RVA: 0x00EE281C File Offset: 0x00EE0A1C
		private void OnMonsterHandbookBtnClick()
		{
			KurotatoEnemyDetailBookMainViewOpenParam param = new KurotatoEnemyDetailBookMainViewOpenParam
			{
				TargetLevel = this.SelectedLevelData.Id,
				TargetWave = 0
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoEnemyDetailBookMainView, param, null);
		}

		// Token: 0x0603AB6F RID: 240495 RVA: 0x00EE2858 File Offset: 0x00EE0A58
		private void OnClickArchiveBtn()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(630);
		}

		// Token: 0x0603AB70 RID: 240496 RVA: 0x00EE286C File Offset: 0x00EE0A6C
		private void RefreshArchiveItem()
		{
			KurotatoLevelData selectedLevelData = this.SelectedLevelData;
			bool flag = selectedLevelData != null && selectedLevelData.HasArchivedData;
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem != null)
			{
				captionItem.SetCaptionStateActive(true);
			}
			PopupCaptionItem captionItem2 = this.CaptionItem;
			if (captionItem2 != null)
			{
				captionItem2.SetCaptionStateTip(flag ? "Kurotato_Has_Archive" : "Kurotato_Can_Archive");
			}
			PopupCaptionItem captionItem3 = this.CaptionItem;
			if (captionItem3 == null)
			{
				return;
			}
			captionItem3.SetCaptionChangeColor(flag);
		}

		// Token: 0x0603AB71 RID: 240497 RVA: 0x00EE28CF File Offset: 0x00EE0ACF
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603AB72 RID: 240498 RVA: 0x00EE28D8 File Offset: 0x00EE0AD8
		private void OnHelpBtnClick()
		{
			int helpGroupId = (this.LevelSelectViewData.LevelMode == EKurotatoLevelMode.Endless) ? 614 : 573;
			ControllerBase<HelpController>.Instance.OpenHelpById(helpGroupId);
		}

		// Token: 0x0603AB73 RID: 240499 RVA: 0x00EE2910 File Offset: 0x00EE0B10
		private void OnGotoBtnClick(int data)
		{
			if (this.SelectedLevelData.ArchiveWave != -1)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.KurotatoArchiveConfirm);
				confirmBoxDataNew.IsEscViewTriggerCallBack = false;
				confirmBoxDataNew.FunctionMap[1] = delegate()
				{
					ControllerBase<KurotatoController>.Instance.RequestKurotatoLevelRecordDelete(this.LevelSelectViewData.LevelId).ContinueWith(delegate(bool isSuccess)
					{
						if (!isSuccess)
						{
							return;
						}
						Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoRoleSelectView, this.LevelSelectViewData, null);
					}).Forget();
				};
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					ControllerBase<KurotatoController>.Instance.RequestEnterInst(this.LevelSelectViewData.LevelId, 0, true);
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoRoleSelectView, this.LevelSelectViewData, null);
		}

		// Token: 0x04021331 RID: 135985
		[Nullable(2)]
		private KurotatoLevelSelectViewData LevelSelectViewData;

		// Token: 0x04021332 RID: 135986
		private KurotatoActivityData ActivityData;

		// Token: 0x04021333 RID: 135987
		private List<IMultiTemplateGridData> ScrollDataList = new List<IMultiTemplateGridData>();

		// Token: 0x04021334 RID: 135988
		private int SelectedIndex = 1;

		// Token: 0x04021335 RID: 135989
		private KurotatoLevelData SelectedLevelData;

		// Token: 0x04021336 RID: 135990
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04021337 RID: 135991
		[Nullable(2)]
		private MultiTemplateScrollView LevelMultiTemplateScrollView;

		// Token: 0x04021338 RID: 135992
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<KurotatoLevelTargetItem, KurotatoLevelTargetItemData> TargetScroll;

		// Token: 0x04021339 RID: 135993
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<KurotatoWeaponSmallItemGrid, IKurotatoSmallItemGridData> RewardScroll;

		// Token: 0x0402133A RID: 135994
		[Nullable(2)]
		private KurotatoLevelUnlockRolePanel UnlockRolePanel;

		// Token: 0x0402133B RID: 135995
		[Nullable(2)]
		private KurotatoEndlessHistoryPanel EndlessHistoryPanel;

		// Token: 0x0402133C RID: 135996
		[Nullable(2)]
		private ButtonItem GotoBtn;
	}
}
