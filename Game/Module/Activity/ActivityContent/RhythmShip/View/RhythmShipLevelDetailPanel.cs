using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064E9 RID: 25833
	[NullableContext(2)]
	[Nullable(0)]
	public class RhythmShipLevelDetailPanel : UiPanelBase
	{
		// Token: 0x06040B27 RID: 264999 RVA: 0x01096A48 File Offset: 0x01094C48
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUITexture)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUITexture)),
				new ValueTuple<int, Type>(14, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(15, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(9, new Action(this.OnClickRankingBtn)),
				new ValueTuple<int, Delegate>(10, new Action(this.OnClickStartBtn)),
				new ValueTuple<int, Delegate>(14, new Action(this.OnClickRoleBtn))
			};
		}

		// Token: 0x06040B28 RID: 265000 RVA: 0x01096C08 File Offset: 0x01094E08
		protected override UniTask OnBeforeStartAsync()
		{
			RhythmShipLevelDetailPanel.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RhythmShipLevelDetailPanel.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040B29 RID: 265001 RVA: 0x01096C4C File Offset: 0x01094E4C
		protected override void OnStart()
		{
			this.StarLayout = new GenericLayout<StarItem, bool>(base.GetHorizontalLayout(4), new Func<StarItem>(this.InitStarItem), base.GetItem(5).GetOwner() as AUIBaseActor, false, true);
			this.RefreshRolePanel();
			this.RefreshRoleRedDotItem();
			Singleton<EventSystem>.Instance.Add(EEventName.OnRhythmShipSelectRoleRefresh, new Action(this.RefreshRolePanel));
			Singleton<EventSystem>.Instance.Add(EEventName.OnRhythmShipRedDotRefresh, new Action<List<int>, List<int>, List<int>>(this.OnRhythmShipRedDotRefresh));
		}

		// Token: 0x06040B2A RID: 265002 RVA: 0x01096CCE File Offset: 0x01094ECE
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRhythmShipSelectRoleRefresh, new Action(this.RefreshRolePanel));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRhythmShipRedDotRefresh, new Action<List<int>, List<int>, List<int>>(this.OnRhythmShipRedDotRefresh));
		}

		// Token: 0x06040B2B RID: 265003 RVA: 0x01096D08 File Offset: 0x01094F08
		[NullableContext(1)]
		private StarItem InitStarItem()
		{
			return new StarItem();
		}

		// Token: 0x06040B2C RID: 265004 RVA: 0x01096D10 File Offset: 0x01094F10
		public void RefreshPanelByLevelId(int levelId, int? subLevelId = null)
		{
			this.LevelId = levelId;
			RhythmShipLevel? rhythmShipLevelById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipLevelById(levelId);
			if (rhythmShipLevelById == null)
			{
				return;
			}
			SongLevelDetailPanel songDetailPanelIns = this.SongDetailPanelIns;
			if (songDetailPanelIns != null)
			{
				songDetailPanelIns.RefreshPanelByLevelId(this.LevelId);
			}
			RhythmShipPlanet? rhythmShipPlanetById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipPlanetById(rhythmShipLevelById.Value.Planet);
			base.GetItem(11).SetUIActive(rhythmShipPlanetById == null || rhythmShipPlanetById.GetValueOrDefault().Type != 2);
			IReadOnlyList<RhythmSubLevel> rhythmShipSubLevelByLevelId = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipSubLevelByLevelId(this.LevelId);
			ControllerBase<RhythmShipController>.Instance.PlayLoopAudioEvent(rhythmShipLevelById.Value.BgmEvent);
			DifficultyItem easyItem = this.EasyItem;
			if (easyItem != null)
			{
				easyItem.RefreshPanel(this.FindSubLevelId(rhythmShipSubLevelByLevelId, ERhythmShipLevelDifficulty.Easy));
			}
			DifficultyItem middleItem = this.MiddleItem;
			if (middleItem != null)
			{
				middleItem.RefreshPanel(this.FindSubLevelId(rhythmShipSubLevelByLevelId, ERhythmShipLevelDifficulty.Middle));
			}
			DifficultyItem difficultyItemIns = this.DifficultyItemIns;
			if (difficultyItemIns != null)
			{
				difficultyItemIns.RefreshPanel(this.FindSubLevelId(rhythmShipSubLevelByLevelId, ERhythmShipLevelDifficulty.Difficulty));
			}
			this.SelectDifficultyToggleOnRefresh(rhythmShipSubLevelByLevelId, subLevelId);
		}

		// Token: 0x06040B2D RID: 265005 RVA: 0x01096E18 File Offset: 0x01095018
		private int FindSubLevelId(IReadOnlyList<RhythmSubLevel> subLevelList, ERhythmShipLevelDifficulty difficulty)
		{
			if (subLevelList == null)
			{
				return 0;
			}
			foreach (RhythmSubLevel rhythmSubLevel in subLevelList)
			{
				if (rhythmSubLevel.Difficulty == (int)difficulty)
				{
					return rhythmSubLevel.Id;
				}
			}
			return 0;
		}

		// Token: 0x06040B2E RID: 265006 RVA: 0x01096E78 File Offset: 0x01095078
		private void SelectDifficultyToggleOnRefresh(IReadOnlyList<RhythmSubLevel> subLevelList, int? subLevelId)
		{
			int num = 0;
			if (subLevelId != null && ModelBase<RhythmShipModel>.Instance.GetSubLevelIsUnlock(subLevelId.Value))
			{
				RhythmSubLevel? rhythmSubLevel;
				num = ((ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipSubLevelById(subLevelId.Value) != null) ? rhythmSubLevel.GetValueOrDefault().Difficulty : 0);
			}
			else if (subLevelList != null)
			{
				foreach (RhythmSubLevel rhythmSubLevel2 in subLevelList)
				{
					Dictionary<int, RhythmSubLevelPb> subLevelInfoMapBySubLevelId = ModelBase<RhythmShipModel>.Instance.GetSubLevelInfoMapBySubLevelId(rhythmSubLevel2.Id);
					RhythmSubLevelPb rhythmSubLevelPb = null;
					if (subLevelInfoMapBySubLevelId != null)
					{
						subLevelInfoMapBySubLevelId.TryGetValue(rhythmSubLevel2.Id, out rhythmSubLevelPb);
					}
					if (ModelBase<RhythmShipModel>.Instance.GetSubLevelIsUnlock(rhythmSubLevel2.Id) && (rhythmSubLevelPb == null || !rhythmSubLevelPb.Cleared) && num < rhythmSubLevel2.Difficulty)
					{
						num = rhythmSubLevel2.Difficulty;
					}
				}
			}
			switch (num)
			{
			case 1:
			{
				DifficultyItem easyItem = this.EasyItem;
				if (easyItem != null)
				{
					easyItem.SelectToggle();
				}
				break;
			}
			case 2:
			{
				DifficultyItem middleItem = this.MiddleItem;
				if (middleItem != null)
				{
					middleItem.SelectToggle();
				}
				break;
			}
			case 3:
			{
				DifficultyItem difficultyItemIns = this.DifficultyItemIns;
				if (difficultyItemIns != null)
				{
					difficultyItemIns.SelectToggle();
				}
				break;
			}
			default:
			{
				DifficultyItem easyItem2 = this.EasyItem;
				if (easyItem2 != null)
				{
					easyItem2.SelectToggle();
				}
				break;
			}
			}
			this.ReadAllSubLevelRedDot();
		}

		// Token: 0x06040B2F RID: 265007 RVA: 0x01096FD8 File Offset: 0x010951D8
		private void ReadAllSubLevelRedDot()
		{
			List<int> list = new List<int>();
			if (this.IsSubLevelNeedClearRedRot(this.EasyItem))
			{
				list.Add(this.EasyItem.SubLevelId);
			}
			if (this.IsSubLevelNeedClearRedRot(this.MiddleItem))
			{
				list.Add(this.MiddleItem.SubLevelId);
			}
			if (this.IsSubLevelNeedClearRedRot(this.DifficultyItemIns))
			{
				list.Add(this.DifficultyItemIns.SubLevelId);
			}
			if (list.Count <= 0)
			{
				return;
			}
			ControllerBase<RhythmShipController>.Instance.RhythmSetRedDotRequest(null, list, null);
		}

		// Token: 0x06040B30 RID: 265008 RVA: 0x0109705F File Offset: 0x0109525F
		private bool IsSubLevelNeedClearRedRot(DifficultyItem difficultyItem)
		{
			return difficultyItem != null && difficultyItem.IsUnLock && difficultyItem.HaveRedDotItem;
		}

		// Token: 0x06040B31 RID: 265009 RVA: 0x01097078 File Offset: 0x01095278
		private void RefreshPanelAboutDifficulty()
		{
			IEnumerable<RhythmSubLevel> enumerable = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipSubLevelByLevelId(this.LevelId) ?? new List<RhythmSubLevel>();
			int num = 0;
			foreach (RhythmSubLevel rhythmSubLevel in enumerable)
			{
				if (rhythmSubLevel.Id == this.SubLevelId)
				{
					num = rhythmSubLevel.StarLevel;
				}
			}
			List<bool> list = new List<bool>();
			for (int i = 1; i <= 9; i++)
			{
				if (i <= num)
				{
					list.Add(true);
				}
				else
				{
					list.Add(false);
				}
			}
			GenericLayout<StarItem, bool> starLayout = this.StarLayout;
			if (starLayout != null)
			{
				starLayout.RefreshByData(list, null, false);
			}
			RhythmSubLevel? rhythmShipSubLevelById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipSubLevelById(this.SubLevelId);
			base.GetButton(9).RootUIComp.Get().SetUIActive(rhythmShipSubLevelById != null && rhythmShipSubLevelById.GetValueOrDefault().Difficulty == 3);
			Dictionary<int, RhythmSubLevelPb> subLevelInfoMapBySubLevelId = ModelBase<RhythmShipModel>.Instance.GetSubLevelInfoMapBySubLevelId(this.SubLevelId);
			RhythmSubLevelPb rhythmSubLevelPb = null;
			if (subLevelInfoMapBySubLevelId != null)
			{
				subLevelInfoMapBySubLevelId.TryGetValue(this.SubLevelId, out rhythmSubLevelPb);
			}
			if (rhythmSubLevelPb == null || rhythmSubLevelPb.BestScore == 0)
			{
				base.GetText(6).SetText("----", true);
				base.GetText(7).SetText("----", true);
				base.GetTexture(8).SetUIActive(false);
				return;
			}
			base.GetText(6).SetText(rhythmSubLevelPb.BestScore.ToString(), true);
			base.GetText(7).SetText((rhythmSubLevelPb.BestAccuracy / 100).ToString() + "%", true);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(RhythmShipDefine.rhythmShipLevelRatingSettlementTexture[(int)rhythmSubLevelPb.BestRank]);
			base.GetTexture(8).SetUIActive(true);
			base.SetTextureByPath(resourcePath, base.GetTexture(8), null, null);
		}

		// Token: 0x06040B32 RID: 265010 RVA: 0x01097268 File Offset: 0x01095468
		private void RefreshRolePanel()
		{
			RhythmShipData activityData = ModelBase<RhythmShipModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return;
			}
			int currentRole = activityData.CurrentRole;
			if (currentRole == 0)
			{
				base.GetItem(11).SetUIActive(false);
				return;
			}
			RhythmRole? rhythmRoleById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmRoleById(currentRole);
			if (rhythmRoleById == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), rhythmRoleById.Value.RoleNameText, Array.Empty<object>());
			base.SetTextureByPath(rhythmRoleById.Value.RoleHeadTexture, base.GetTexture(13), null, null);
		}

		// Token: 0x06040B33 RID: 265011 RVA: 0x01097304 File Offset: 0x01095504
		private void OnClickRankingBtn()
		{
			RhythmShipRatingViewData param = new RhythmShipRatingViewData
			{
				LevelId = this.LevelId,
				SubLevelId = this.SubLevelId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RhythmShipRatingView, param, null);
		}

		// Token: 0x06040B34 RID: 265012 RVA: 0x01097340 File Offset: 0x01095540
		private void OnClickStartBtn()
		{
			if (!ModelBase<RhythmShipModel>.Instance.GetSubLevelIsUnlock(this.SubLevelId))
			{
				RhythmSubLevel? rhythmShipSubLevelById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipSubLevelById(this.SubLevelId);
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(((rhythmShipSubLevelById != null) ? rhythmShipSubLevelById.GetValueOrDefault().LockTips : null) ?? "RhythmShipLevelLockTips", Array.Empty<object>());
				return;
			}
			RhythmShipLevel? rhythmShipLevelById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipLevelById(this.LevelId);
			if (rhythmShipLevelById == null)
			{
				return;
			}
			RhythmShipPlanet? rhythmShipPlanetById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipPlanetById(rhythmShipLevelById.Value.Planet);
			ModelBase<LoadingModel>.Instance.SetSpecifiedLoadingConfigId((rhythmShipPlanetById != null) ? new int?(rhythmShipPlanetById.GetValueOrDefault().LoadingId) : null);
			ControllerBase<RhythmShipController>.Instance.StartRequest(this.SubLevelId, this.LevelId);
		}

		// Token: 0x06040B35 RID: 265013 RVA: 0x01097424 File Offset: 0x01095624
		private void OnClickRoleBtn()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RhythmShipChoseRoleView, null, null);
		}

		// Token: 0x06040B36 RID: 265014 RVA: 0x01097438 File Offset: 0x01095638
		[NullableContext(1)]
		private void OnClickDifficultyItem(int subLevel, UUIExtendToggle toggle)
		{
			if (this.SubLevelId == subLevel)
			{
				return;
			}
			this.SubLevelId = subLevel;
			if (toggle != this.CurrentSelectToggle)
			{
				UUIExtendToggle currentSelectToggle = this.CurrentSelectToggle;
				if (currentSelectToggle == null || currentSelectToggle.ToggleState != EToggleState.ETT_UnDetermined)
				{
					UUIExtendToggle currentSelectToggle2 = this.CurrentSelectToggle;
					if (currentSelectToggle2 != null)
					{
						currentSelectToggle2.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
					}
				}
			}
			this.CurrentSelectToggle = toggle;
			this.RefreshPanelAboutDifficulty();
		}

		// Token: 0x06040B37 RID: 265015 RVA: 0x0109749C File Offset: 0x0109569C
		private void RefreshRoleRedDotItem()
		{
			base.GetItem(15).SetUIActive(ModelBase<RhythmShipModel>.Instance.GetAnyRoleRedDotActive());
		}

		// Token: 0x06040B38 RID: 265016 RVA: 0x010974B5 File Offset: 0x010956B5
		private void OnRhythmShipRedDotRefresh(List<int> planet, List<int> subLevel, List<int> role)
		{
			if (role == null)
			{
				return;
			}
			this.RefreshRoleRedDotItem();
		}

		// Token: 0x04024421 RID: 148513
		private int LevelId;

		// Token: 0x04024422 RID: 148514
		private int SubLevelId;

		// Token: 0x04024423 RID: 148515
		private UUIExtendToggle CurrentSelectToggle;

		// Token: 0x04024424 RID: 148516
		private SongLevelDetailPanel SongDetailPanelIns;

		// Token: 0x04024425 RID: 148517
		private DifficultyItem EasyItem;

		// Token: 0x04024426 RID: 148518
		private DifficultyItem MiddleItem;

		// Token: 0x04024427 RID: 148519
		private DifficultyItem DifficultyItemIns;

		// Token: 0x04024428 RID: 148520
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<StarItem, bool> StarLayout;
	}
}
