using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064DD RID: 25821
	[NullableContext(2)]
	[Nullable(0)]
	public class RhythmShipChoseLevelView : UiTickViewBase
	{
		// Token: 0x06040AD6 RID: 264918 RVA: 0x01094576 File Offset: 0x01092776
		[NullableContext(1)]
		public RhythmShipChoseLevelView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040AD7 RID: 264919 RVA: 0x010945B0 File Offset: 0x010927B0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIDraggableComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUIText)),
				new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(12, typeof(UUIText)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(16, typeof(UUIItem)),
				new ValueTuple<int, Type>(17, typeof(UUIItem)),
				new ValueTuple<int, Type>(18, typeof(UUIItem)),
				new ValueTuple<int, Type>(19, typeof(UUIItem)),
				new ValueTuple<int, Type>(20, typeof(UUIItem)),
				new ValueTuple<int, Type>(21, typeof(UUIItem)),
				new ValueTuple<int, Type>(22, typeof(UUIItem)),
				new ValueTuple<int, Type>(23, typeof(UUIItem)),
				new ValueTuple<int, Type>(24, typeof(UUIItem)),
				new ValueTuple<int, Type>(25, typeof(UUIItem)),
				new ValueTuple<int, Type>(26, typeof(UUIItem)),
				new ValueTuple<int, Type>(27, typeof(UUIItem)),
				new ValueTuple<int, Type>(28, typeof(UUIItem)),
				new ValueTuple<int, Type>(29, typeof(UUIItem)),
				new ValueTuple<int, Type>(30, typeof(UUIItem)),
				new ValueTuple<int, Type>(31, typeof(UUIItem)),
				new ValueTuple<int, Type>(32, typeof(UUIItem)),
				new ValueTuple<int, Type>(33, typeof(UUIItem)),
				new ValueTuple<int, Type>(34, typeof(UUIItem)),
				new ValueTuple<int, Type>(35, typeof(UUIItem)),
				new ValueTuple<int, Type>(36, typeof(UUINiagara)),
				new ValueTuple<int, Type>(37, typeof(UUITexture)),
				new ValueTuple<int, Type>(38, typeof(UUIItem)),
				new ValueTuple<int, Type>(39, typeof(UUIItem)),
				new ValueTuple<int, Type>(40, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(41, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(42, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnClickKeyBindingsBtn)),
				new ValueTuple<int, Delegate>(4, new Action(this.OnClickLeftBtn)),
				new ValueTuple<int, Delegate>(5, new Action(this.OnClickRightBtn)),
				new ValueTuple<int, Delegate>(11, new Action(this.OnClickTaskBtn)),
				new ValueTuple<int, Delegate>(8, new Action(this.OnClickLimitTaskBtn)),
				new ValueTuple<int, Delegate>(15, new Action(this.OnClickFastTravelBtn)),
				new ValueTuple<int, Delegate>(40, new Action(this.OnClickLevelDetailLeftBtn)),
				new ValueTuple<int, Delegate>(41, new Action(this.OnClickLevelDetailRightBtn))
			};
		}

		// Token: 0x06040AD8 RID: 264920 RVA: 0x01094A6C File Offset: 0x01092C6C
		protected override UniTask OnBeforeStartAsync()
		{
			RhythmShipChoseLevelView.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RhythmShipChoseLevelView.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040AD9 RID: 264921 RVA: 0x01094AAF File Offset: 0x01092CAF
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnRhythmShipJumpLevel, new Action<int, int, int>(this.OnRhythmShipJumpLevel));
			Singleton<EventSystem>.Instance.Add(EEventName.OnRhythmShipRedDotRefresh, new Action<List<int>, List<int>, List<int>>(this.OnRhythmShipRedDotRefresh));
		}

		// Token: 0x06040ADA RID: 264922 RVA: 0x01094AE9 File Offset: 0x01092CE9
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRhythmShipJumpLevel, new Action<int, int, int>(this.OnRhythmShipJumpLevel));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRhythmShipRedDotRefresh, new Action<List<int>, List<int>, List<int>>(this.OnRhythmShipRedDotRefresh));
		}

		// Token: 0x06040ADB RID: 264923 RVA: 0x01094B24 File Offset: 0x01092D24
		protected override void OnStart()
		{
			this.PlayMainViewMusic();
			IRhythmShipChoseLevelViewData rhythmShipChoseLevelViewData = this.OpenParam as IRhythmShipChoseLevelViewData;
			this.CurrentShowType = rhythmShipChoseLevelViewData.OpenShowType;
			if (this.CurrentShowType == ERhythmShipPlanetType.MainLine)
			{
				base.GetItem(38).SetUIActive(false);
				base.GetItem(13).SetUIActive(false);
				base.GetButton(15).RootUIComp.Get().SetUIActive(false);
				base.GetItem(42).SetUIActive(false);
				this.RhythmShipLinkageItem.GetRootItem().SetUIActive(false);
			}
			this.PlanetList = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipPlanetIdListByType((int)this.CurrentShowType, ModelBase<RhythmShipModel>.Instance.ActivityId);
			RhythmShipLevelDetailPanel levelDetailPanel = this.LevelDetailPanel;
			if (levelDetailPanel != null)
			{
				levelDetailPanel.SetUiActive(false);
			}
			this.RefreshView(rhythmShipChoseLevelViewData.PlanetId);
			this.RefreshBgItem();
			this.RefreshTimeText();
			this.RefreshLinkageRedDot();
		}

		// Token: 0x06040ADC RID: 264924 RVA: 0x01094BFE File Offset: 0x01092DFE
		protected override void OnBeforeDestroy()
		{
			this.StopLastMusic();
		}

		// Token: 0x06040ADD RID: 264925 RVA: 0x01094C08 File Offset: 0x01092E08
		protected override void OnBeforeShow()
		{
			base.GetText(12).SetText(ModelBase<RhythmShipModel>.Instance.GetTaskProgressString(0), true);
			base.GetText(9).SetText(ModelBase<RhythmShipModel>.Instance.GetTaskProgressString(1), true);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RhythmShipTask, base.GetItem(31), null, 0);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RhythmShipTimeLimitTask, base.GetItem(30), null, 0);
			foreach (KeyValuePair<int, RhythmShipChoseLevelItem> keyValuePair in this.RhythmShipChoseLevelItemMap)
			{
				keyValuePair.Value.SetToggleSelect(false);
			}
		}

		// Token: 0x06040ADE RID: 264926 RVA: 0x01094CC8 File Offset: 0x01092EC8
		private void PlayMainViewMusic()
		{
			ControllerBase<RhythmShipController>.Instance.PlayLoopAudioEvent("play_ui_jiezoufeichuan_interface");
		}

		// Token: 0x06040ADF RID: 264927 RVA: 0x01094CD9 File Offset: 0x01092ED9
		private void StopLastMusic()
		{
			ControllerBase<RhythmShipController>.Instance.StopLoopAudioEvent();
		}

		// Token: 0x06040AE0 RID: 264928 RVA: 0x01094CE8 File Offset: 0x01092EE8
		protected override void OnAfterPlayStartSequence()
		{
			IRhythmShipChoseLevelViewData rhythmShipChoseLevelViewData = this.OpenParam as IRhythmShipChoseLevelViewData;
			if (rhythmShipChoseLevelViewData.LevelId != null && rhythmShipChoseLevelViewData.SubLevelId != null)
			{
				this.OnClickLevelItem(rhythmShipChoseLevelViewData.LevelId.Value, new int?(rhythmShipChoseLevelViewData.SubLevelId.Value));
			}
		}

		// Token: 0x06040AE1 RID: 264929 RVA: 0x01094D48 File Offset: 0x01092F48
		protected override void OnBeforeHide()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RhythmShipTask, base.GetItem(31), 0);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RhythmShipTimeLimitTask, base.GetItem(30), 0);
		}

		// Token: 0x06040AE2 RID: 264930 RVA: 0x01094D7A File Offset: 0x01092F7A
		protected override void OnTick(float delta)
		{
			if (this.RefreshTime > 500f)
			{
				this.RefreshTimeText();
				this.RefreshTime = 0f;
			}
			this.RefreshTime += delta;
		}

		// Token: 0x06040AE3 RID: 264931 RVA: 0x01094DA8 File Offset: 0x01092FA8
		private void RefreshTimeText()
		{
			RhythmShipData activityData = ModelBase<RhythmShipModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return;
			}
			bool uiactive = activityData.CheckIfInLimitTime();
			base.GetItem(39).SetUIActive(uiactive);
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(activityData.EndRewardTime, "{0}");
			base.GetText(10).SetText(remainTimeText ?? "", true);
		}

		// Token: 0x06040AE4 RID: 264932 RVA: 0x01094E08 File Offset: 0x01093008
		private void RefreshLevelItem()
		{
			List<int> rhythmShipLevelIdListByPlanet = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipLevelIdListByPlanet(this.PlanetList[this.CurrentShowPlanetIndex]);
			this.LevelList = (rhythmShipLevelIdListByPlanet ?? new List<int>());
			if (rhythmShipLevelIdListByPlanet == null)
			{
				return;
			}
			int count = rhythmShipLevelIdListByPlanet.Count;
			List<int> list;
			if (!RhythmShipChoseLevelViewDefine.rhythmShipLevelItemShow.TryGetValue(count, out list))
			{
				return;
			}
			for (int i = 0; i < rhythmShipLevelIdListByPlanet.Count; i++)
			{
				int key = list[i];
				RhythmShipChoseLevelItem rhythmShipChoseLevelItem;
				this.RhythmShipChoseLevelItemMap.TryGetValue(key, out rhythmShipChoseLevelItem);
				if (rhythmShipChoseLevelItem != null)
				{
					rhythmShipChoseLevelItem.RefreshItem(rhythmShipLevelIdListByPlanet[i], false);
				}
			}
			foreach (KeyValuePair<int, RhythmShipChoseLevelItem> keyValuePair in this.RhythmShipChoseLevelItemMap)
			{
				int key2 = keyValuePair.Key;
				RhythmShipChoseLevelItem value = keyValuePair.Value;
				if (value != null)
				{
					UUIItem parentAsUIItem = value.GetRootItem().GetParentAsUIItem();
					if (parentAsUIItem != null)
					{
						parentAsUIItem.SetUIActive(list.Contains(key2));
					}
				}
			}
		}

		// Token: 0x06040AE5 RID: 264933 RVA: 0x01094F10 File Offset: 0x01093110
		private void RefreshNextBgView()
		{
			int id = this.PlanetList[this.CurrentShowPlanetIndex];
			RhythmShipPlanet? rhythmShipPlanetById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipPlanetById(id);
			if (rhythmShipPlanetById == null)
			{
				return;
			}
			RhythmBg? rhythmShipBgById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipBgById(rhythmShipPlanetById.Value.BgId);
			if (rhythmShipBgById == null)
			{
				return;
			}
			base.GetItem(35).SetUIActive(true);
			base.GetItem(35).SetColor(FColor.FromHex(rhythmShipBgById.Value.BgItemColor));
			LevelSequencePlayer switchLevelSequencePlayer = this.SwitchLevelSequencePlayer;
			if (switchLevelSequencePlayer != null)
			{
				switchLevelSequencePlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer switchLevelSequencePlayer2 = this.SwitchLevelSequencePlayer;
			if (switchLevelSequencePlayer2 != null)
			{
				switchLevelSequencePlayer2.PlayLevelSequenceByName("Sle", false, null, false);
			}
			if (StringUtils.IsEmpty(rhythmShipBgById.Value.BgMaskItemColor))
			{
				if (base.GetItem(34).IsUIActiveSelf())
				{
					LevelSequencePlayer bgMaskLevelSequencePlayer = this.BgMaskLevelSequencePlayer;
					if (bgMaskLevelSequencePlayer == null)
					{
						return;
					}
					bgMaskLevelSequencePlayer.PlayLevelSequenceByName("Out", false, null, false);
					return;
				}
			}
			else
			{
				base.GetItem(34).SetUIActive(true);
				base.GetItem(34).SetColor(FColor.FromHex(rhythmShipBgById.Value.BgMaskItemColor));
				LevelSequencePlayer bgMaskLevelSequencePlayer2 = this.BgMaskLevelSequencePlayer;
				if (bgMaskLevelSequencePlayer2 == null)
				{
					return;
				}
				bgMaskLevelSequencePlayer2.PlayLevelSequenceByName("In", false, null, false);
			}
		}

		// Token: 0x06040AE6 RID: 264934 RVA: 0x01095068 File Offset: 0x01093268
		private void RefreshView(int? targetPlanet = null)
		{
			if (targetPlanet != null)
			{
				this.CurrentShowPlanetIndex = this.PlanetList.IndexOf(targetPlanet.Value);
			}
			int num = this.PlanetList[this.CurrentShowPlanetIndex];
			RhythmShipPlanet? rhythmShipPlanetById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipPlanetById(num);
			if (rhythmShipPlanetById == null)
			{
				return;
			}
			RhythmShipData activityData = ModelBase<RhythmShipModel>.Instance.ActivityData;
			if (activityData != null)
			{
				RhythmRedDotPb redDotInfo = activityData.RedDotInfo;
				if (redDotInfo == null || !redDotInfo.ReadPlanet.Contains(num))
				{
					ControllerBase<RhythmShipController>.Instance.RhythmSetRedDotRequest(new List<int>
					{
						num
					}, null, null);
				}
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), rhythmShipPlanetById.Value.Name, Array.Empty<object>());
			bool flag = this.CurrentShowType == ERhythmShipPlanetType.Linkage;
			base.GetItem(24).SetUIActive(flag);
			this.RhythmShipLinkageItem.RefreshItem(!flag);
			base.GetButton(15).RootUIComp.Get().SetUIActive(this.CurrentShowType == ERhythmShipPlanetType.Normal);
			base.GetItem(2).SetUIActive(this.CurrentShowType != ERhythmShipPlanetType.Linkage);
			base.GetText(3).SetUIActive(!flag);
			this.RefreshLevelItem();
			this.RefreshLeftAndRightBtnActive();
			RhythmBg? rhythmShipBgById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipBgById(rhythmShipPlanetById.Value.BgId);
			if (rhythmShipBgById != null && !this.DoNotPlayStartSequence)
			{
				LevelSequencePlayer startLevelSequencePlayer = this.StartLevelSequencePlayer;
				if (startLevelSequencePlayer != null)
				{
					startLevelSequencePlayer.PlayLevelSequenceByName(rhythmShipBgById.Value.StartLevelSequence, false, null, false);
				}
				this.DoNotPlayStartSequence = true;
			}
		}

		// Token: 0x06040AE7 RID: 264935 RVA: 0x01095208 File Offset: 0x01093408
		private void RefreshBgItem()
		{
			int id = this.PlanetList[this.CurrentShowPlanetIndex];
			RhythmShipPlanet? rhythmShipPlanetById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipPlanetById(id);
			if (rhythmShipPlanetById == null)
			{
				return;
			}
			RhythmBg? rhythmShipBgById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipBgById(rhythmShipPlanetById.Value.BgId);
			if (rhythmShipBgById == null)
			{
				return;
			}
			base.GetItem(17).SetColor(FColor.FromHex(rhythmShipBgById.Value.BgItemColor));
			base.GetItem(35).SetUIActive(false);
			if (StringUtils.IsEmpty(rhythmShipBgById.Value.BgMaskItemColor))
			{
				base.GetItem(34).SetUIActive(false);
			}
			else
			{
				base.GetItem(34).SetUIActive(true);
				base.GetItem(34).SetColor(FColor.FromHex(rhythmShipBgById.Value.BgMaskItemColor));
			}
			Singleton<ResourceSystem>.Instance.LoadAsync<UMaterialInterface>(rhythmShipBgById.Value.GlowItemMaterial, delegate([Nullable(2)] UMaterialInterface material, string _)
			{
				base.GetTexture(37).SetCustomUIMaterial(material);
			}, ResourceSystem.EResourceLoadPriority.Ui, this.MemoryTag);
			base.SetTextureByPath(rhythmShipBgById.Value.GlowItemTexture, base.GetTexture(37), null, null);
			FColor fcolor = FColor.FromHex(rhythmShipBgById.Value.NiaSphereParWhiteColor);
			base.GetUiNiagara(36).ColorParameter.Get("Color_01").Constant = FLinearColor.FromSRGBColor(fcolor);
		}

		// Token: 0x06040AE8 RID: 264936 RVA: 0x0109537C File Offset: 0x0109357C
		private void RefreshLeftAndRightBtnActive()
		{
			bool flag = this.CurrentShowPlanetIndex < this.PlanetList.Count - 1;
			bool flag2 = this.CurrentShowPlanetIndex > 0;
			base.GetButton(5).RootUIComp.Get().SetUIActive(flag);
			base.GetButton(4).RootUIComp.Get().SetUIActive(flag2);
			if (flag2)
			{
				bool planetRedDotActive = ModelBase<RhythmShipModel>.Instance.GetPlanetRedDotActive(this.PlanetList[this.CurrentShowPlanetIndex - 1]);
				base.GetItem(32).SetUIActive(planetRedDotActive);
			}
			if (flag)
			{
				bool planetRedDotActive2 = ModelBase<RhythmShipModel>.Instance.GetPlanetRedDotActive(this.PlanetList[this.CurrentShowPlanetIndex + 1]);
				base.GetItem(33).SetUIActive(planetRedDotActive2);
			}
		}

		// Token: 0x06040AE9 RID: 264937 RVA: 0x0109543D File Offset: 0x0109363D
		private void OnClickKeyBindingsBtn()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RhythmShipSetView, null, null);
		}

		// Token: 0x06040AEA RID: 264938 RVA: 0x01095450 File Offset: 0x01093650
		private void OnClickLeftBtn()
		{
			this.CurrentShowPlanetIndex--;
			this.RefreshNextBgView();
			this.RefreshView(null);
		}

		// Token: 0x06040AEB RID: 264939 RVA: 0x01095480 File Offset: 0x01093680
		private void OnClickRightBtn()
		{
			this.CurrentShowPlanetIndex++;
			this.RefreshNextBgView();
			this.RefreshView(null);
		}

		// Token: 0x06040AEC RID: 264940 RVA: 0x010954B0 File Offset: 0x010936B0
		private void OnClickLevelDetailLeftBtn()
		{
			int num = this.LevelList.IndexOf(this.CurrentShowDetailLevel);
			int levelId = this.LevelList[num - 1];
			this.RefreshPanelOnLevelDetailBtnClick(levelId);
		}

		// Token: 0x06040AED RID: 264941 RVA: 0x010954E8 File Offset: 0x010936E8
		private void OnClickLevelDetailRightBtn()
		{
			int num = this.LevelList.IndexOf(this.CurrentShowDetailLevel);
			int levelId = this.LevelList[num + 1];
			this.RefreshPanelOnLevelDetailBtnClick(levelId);
		}

		// Token: 0x06040AEE RID: 264942 RVA: 0x01095520 File Offset: 0x01093720
		private void RefreshPanelOnLevelDetailBtnClick(int levelId)
		{
			RhythmShipLevelDetailPanel levelDetailPanel = this.LevelDetailPanel;
			if (levelDetailPanel != null)
			{
				levelDetailPanel.RefreshPanelByLevelId(levelId, null);
			}
			RhythmShipLevelDetailPanel levelDetailPanel2 = this.LevelDetailPanel;
			if (levelDetailPanel2 != null)
			{
				levelDetailPanel2.SetUiActive(true);
			}
			this.CurrentShowDetailLevel = levelId;
			this.RefreshDetailLevel();
			this.RefreshLevelDetailBtn();
		}

		// Token: 0x06040AEF RID: 264943 RVA: 0x0109556D File Offset: 0x0109376D
		private void OnClickTaskBtn()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RhythmShipTaskView, null, null);
		}

		// Token: 0x06040AF0 RID: 264944 RVA: 0x01095580 File Offset: 0x01093780
		private void OnClickLimitTaskBtn()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RhythmShipLimitTaskView, null, null);
		}

		// Token: 0x06040AF1 RID: 264945 RVA: 0x01095594 File Offset: 0x01093794
		private void OnClickLinkageBtn()
		{
			if (Singleton<TimeUtil>.Instance.GetServerTime() < this.NextCanClickTime)
			{
				return;
			}
			this.NextCanClickTime = Singleton<TimeUtil>.Instance.GetServerTime() + 1.0;
			this.DoNotPlayStartSequence = false;
			if (this.CurrentShowType != ERhythmShipPlanetType.Linkage)
			{
				this.CurrentShowType = ERhythmShipPlanetType.Linkage;
			}
			else
			{
				this.CurrentShowType = ERhythmShipPlanetType.Normal;
			}
			this.PlanetList = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipPlanetIdListByType((int)this.CurrentShowType, ModelBase<RhythmShipModel>.Instance.ActivityId);
			this.CurrentShowPlanetIndex = 0;
			this.RefreshView(null);
			this.RefreshBgItem();
			this.RefreshLinkageRedDot();
		}

		// Token: 0x06040AF2 RID: 264946 RVA: 0x01095630 File Offset: 0x01093830
		private void OnClickFastTravelBtn()
		{
			RhythmShipQuickSelectLevelViewData param = new RhythmShipQuickSelectLevelViewData
			{
				OpenShowType = this.CurrentShowType
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RhythmShipQuickSelectLevelView, param, null);
		}

		// Token: 0x06040AF3 RID: 264947 RVA: 0x01095660 File Offset: 0x01093860
		private void OnClickLevelItem(int levelId)
		{
			this.OnClickLevelItem(levelId, null);
		}

		// Token: 0x06040AF4 RID: 264948 RVA: 0x01095680 File Offset: 0x01093880
		private void OnClickLevelItem(int levelId, int? subLevelId)
		{
			if (!this.LevelPreQuestHandle(levelId))
			{
				return;
			}
			RhythmShipLevelDetailPanel levelDetailPanel = this.LevelDetailPanel;
			if (levelDetailPanel != null)
			{
				levelDetailPanel.RefreshPanelByLevelId(levelId, subLevelId);
			}
			RhythmShipLevelDetailPanel levelDetailPanel2 = this.LevelDetailPanel;
			if (levelDetailPanel2 != null)
			{
				levelDetailPanel2.SetUiActive(true);
			}
			LevelSequencePlayer tipsLevelSequencePlayer = this.TipsLevelSequencePlayer;
			if (tipsLevelSequencePlayer != null)
			{
				tipsLevelSequencePlayer.PlayLevelSequenceByName("TipStart", false, null, false);
			}
			base.GetButton(15).RootUIComp.Get().SetUIActive(false);
			this.CurrentShowDetailLevel = levelId;
			base.GetItem(18).SetUIActive(false);
			base.GetItem(25).SetUIActive(true);
			this.RefreshDetailLevel();
		}

		// Token: 0x06040AF5 RID: 264949 RVA: 0x01095724 File Offset: 0x01093924
		private bool LevelPreQuestHandle(int levelId)
		{
			if (ModelBase<RhythmShipModel>.Instance.GetLevelPreQuestFinish(levelId))
			{
				return true;
			}
			if (ModelBase<RhythmShipModel>.Instance.GetIsInRhythmShipLevel())
			{
				ModelBase<RhythmShipModel>.Instance.TrackLevelPreQuest(levelId);
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
				return false;
			}
			int levelUnFinishPreQuestId = ModelBase<RhythmShipModel>.Instance.GetLevelUnFinishPreQuestId(levelId);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, levelUnFinishPreQuestId, null);
			return false;
		}

		// Token: 0x06040AF6 RID: 264950 RVA: 0x0109578C File Offset: 0x0109398C
		private void OnRhythmShipJumpLevel(int showType, int planetId, int levelId)
		{
			this.CurrentShowType = (ERhythmShipPlanetType)showType;
			this.RefreshView(new int?(planetId));
			this.RefreshBgItem();
			if (!ModelBase<RhythmShipModel>.Instance.GetLevelIsUnlock(levelId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(ModelBase<RhythmShipModel>.Instance.GetLevelLockTips(levelId) ?? "RhythmShipLevelLockTips", Array.Empty<object>());
				return;
			}
			this.OnClickLevelItem(levelId);
			this.HandleOpenQuickSelectLevelView = true;
		}

		// Token: 0x06040AF7 RID: 264951 RVA: 0x010957F4 File Offset: 0x010939F4
		private void OnClickDetailPanelMask()
		{
			RhythmShipLevelDetailPanel levelDetailPanel = this.LevelDetailPanel;
			if (levelDetailPanel != null)
			{
				levelDetailPanel.SetUiActive(false);
			}
			this.PlayMainViewMusic();
			LevelSequencePlayer tipsLevelSequencePlayer = this.TipsLevelSequencePlayer;
			if (tipsLevelSequencePlayer != null)
			{
				tipsLevelSequencePlayer.PlayLevelSequenceByName("TipClose", false, null, false);
			}
			base.GetButton(15).RootUIComp.Get().SetUIActive(this.CurrentShowType == ERhythmShipPlanetType.Normal);
			this.CurrentShowDetailLevel = 0;
			base.GetItem(18).SetUIActive(true);
			base.GetItem(25).SetUIActive(false);
		}

		// Token: 0x06040AF8 RID: 264952 RVA: 0x01095880 File Offset: 0x01093A80
		private void RefreshDetailLevel()
		{
			RhythmShipChoseLevelItem rhythmShipChoseLevelDetailItem = this.RhythmShipChoseLevelDetailItem;
			if (rhythmShipChoseLevelDetailItem != null)
			{
				rhythmShipChoseLevelDetailItem.SetToggleSelect(true);
			}
			RhythmShipChoseLevelItem rhythmShipChoseLevelDetailItem2 = this.RhythmShipChoseLevelDetailItem;
			if (rhythmShipChoseLevelDetailItem2 != null)
			{
				rhythmShipChoseLevelDetailItem2.RefreshItem(this.CurrentShowDetailLevel, true);
			}
			foreach (KeyValuePair<int, RhythmShipChoseLevelItem> keyValuePair in this.RhythmShipChoseLevelItemMap)
			{
				keyValuePair.Value.SetToggleSelect(false);
			}
			this.RefreshLevelDetailBtn();
		}

		// Token: 0x06040AF9 RID: 264953 RVA: 0x0109590C File Offset: 0x01093B0C
		private void RefreshLinkageRedDot()
		{
			if (this.CurrentShowType == ERhythmShipPlanetType.Normal)
			{
				base.GetItem(14).SetUIActive(ModelBase<RhythmShipModel>.Instance.GetPlanetRedDotActive(5));
				return;
			}
			if (this.CurrentShowType == ERhythmShipPlanetType.Linkage)
			{
				List<int> rhythmShipPlanetIdListByType = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipPlanetIdListByType(1, ModelBase<RhythmShipModel>.Instance.ActivityId);
				bool uiactive = false;
				foreach (int planet in rhythmShipPlanetIdListByType)
				{
					if (ModelBase<RhythmShipModel>.Instance.GetPlanetRedDotActive(planet))
					{
						uiactive = true;
						break;
					}
				}
				base.GetItem(14).SetUIActive(uiactive);
			}
		}

		// Token: 0x06040AFA RID: 264954 RVA: 0x010959B4 File Offset: 0x01093BB4
		private void OnRhythmShipRedDotRefresh(List<int> planet, List<int> subLevel, List<int> role)
		{
			this.RefreshLinkageRedDot();
		}

		// Token: 0x06040AFB RID: 264955 RVA: 0x010959BC File Offset: 0x01093BBC
		[NullableContext(1)]
		private void SequenceEvent(string seqName, string eventName)
		{
			List<string> list;
			if (!RhythmShipChoseLevelViewDefine.rhythmShipLevelItemSequenceName.TryGetValue(this.LevelList.Count, out list))
			{
				return;
			}
			int num = int.Parse(eventName[eventName.Length - 1].ToString());
			string text = list[num - 1];
			if (StringUtils.IsEmpty(text))
			{
				return;
			}
			RhythmShipChoseLevelItem rhythmShipChoseLevelItem;
			this.RhythmShipChoseLevelItemMap.TryGetValue(num, out rhythmShipChoseLevelItem);
			if (rhythmShipChoseLevelItem != null)
			{
				rhythmShipChoseLevelItem.LevelSequencePlayerPlay(text);
			}
		}

		// Token: 0x06040AFC RID: 264956 RVA: 0x01095A2D File Offset: 0x01093C2D
		[NullableContext(1)]
		private void SwitchSequenceEnd(string seqName)
		{
			if (seqName == "Sle")
			{
				this.RefreshBgItem();
			}
		}

		// Token: 0x06040AFD RID: 264957 RVA: 0x01095A42 File Offset: 0x01093C42
		[NullableContext(1)]
		private void BgMaskLevelSequencePlayerEnd(string seqName)
		{
			if (seqName == "Out")
			{
				base.GetItem(34).SetUIActive(false);
			}
		}

		// Token: 0x06040AFE RID: 264958 RVA: 0x01095A60 File Offset: 0x01093C60
		private void OnClickCloseBtn()
		{
			if (this.HandleOpenQuickSelectLevelView)
			{
				this.OnClickDetailPanelMask();
				this.OnClickFastTravelBtn();
				this.HandleOpenQuickSelectLevelView = false;
				return;
			}
			if (this.CurrentShowDetailLevel != 0)
			{
				this.OnClickDetailPanelMask();
				return;
			}
			if (this.CurrentShowType == ERhythmShipPlanetType.Linkage)
			{
				this.OnClickLinkageBtn();
				return;
			}
			base.CloseMe(null);
			if (!ModelBase<RhythmShipModel>.Instance.GetIsInRhythmShipLevel())
			{
				return;
			}
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
		}

		// Token: 0x06040AFF RID: 264959 RVA: 0x01095ACC File Offset: 0x01093CCC
		private void RefreshLevelDetailBtn()
		{
			if (this.CurrentShowDetailLevel == 0)
			{
				UUIButtonComponent button = base.GetButton(40);
				if (button != null)
				{
					button.RootUIComp.Get().SetUIActive(false);
				}
				UUIButtonComponent button2 = base.GetButton(41);
				if (button2 == null)
				{
					return;
				}
				button2.RootUIComp.Get().SetUIActive(false);
				return;
			}
			else
			{
				int num = this.LevelList.IndexOf(this.CurrentShowDetailLevel);
				int num2 = num - 1;
				UUIButtonComponent button3 = base.GetButton(40);
				if (button3 != null)
				{
					button3.RootUIComp.Get().SetUIActive(num2 >= 0 && ModelBase<RhythmShipModel>.Instance.GetLevelIsUnlock(this.LevelList[num2]));
				}
				int num3 = num + 1;
				UUIButtonComponent button4 = base.GetButton(41);
				if (button4 == null)
				{
					return;
				}
				button4.RootUIComp.Get().SetUIActive(num3 < this.LevelList.Count && ModelBase<RhythmShipModel>.Instance.GetLevelIsUnlock(this.LevelList[num3]));
				return;
			}
		}

		// Token: 0x040243D2 RID: 148434
		private PopupCaptionItem CaptionItem;

		// Token: 0x040243D3 RID: 148435
		private ERhythmShipPlanetType CurrentShowType = ERhythmShipPlanetType.Normal;

		// Token: 0x040243D4 RID: 148436
		[Nullable(1)]
		private List<int> PlanetList = new List<int>();

		// Token: 0x040243D5 RID: 148437
		[Nullable(1)]
		private List<int> LevelList = new List<int>();

		// Token: 0x040243D6 RID: 148438
		private int CurrentShowPlanetIndex;

		// Token: 0x040243D7 RID: 148439
		private int CurrentShowDetailLevel;

		// Token: 0x040243D8 RID: 148440
		private LevelSequencePlayer StartLevelSequencePlayer;

		// Token: 0x040243D9 RID: 148441
		private LevelSequencePlayer SwitchLevelSequencePlayer;

		// Token: 0x040243DA RID: 148442
		private LevelSequencePlayer TipsLevelSequencePlayer;

		// Token: 0x040243DB RID: 148443
		private LevelSequencePlayer BgMaskLevelSequencePlayer;

		// Token: 0x040243DC RID: 148444
		[Nullable(1)]
		private readonly Dictionary<int, RhythmShipChoseLevelItem> RhythmShipChoseLevelItemMap = new Dictionary<int, RhythmShipChoseLevelItem>();

		// Token: 0x040243DD RID: 148445
		private RhythmShipChoseLevelItem RhythmShipChoseLevelDetailItem;

		// Token: 0x040243DE RID: 148446
		private RhythmShipLevelDetailPanel LevelDetailPanel;

		// Token: 0x040243DF RID: 148447
		private RhythmShipLinkageBtnItem RhythmShipLinkageItem;

		// Token: 0x040243E0 RID: 148448
		private float RefreshTime;

		// Token: 0x040243E1 RID: 148449
		private bool DoNotPlayStartSequence = true;

		// Token: 0x040243E2 RID: 148450
		private double NextCanClickTime;

		// Token: 0x040243E3 RID: 148451
		private bool HandleOpenQuickSelectLevelView;
	}
}
