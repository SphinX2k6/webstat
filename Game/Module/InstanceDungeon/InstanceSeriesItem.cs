using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Mowing;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonViewModel;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BB1 RID: 23473
	[NullableContext(2)]
	[Nullable(0)]
	public class InstanceSeriesItem : UiPanelBase
	{
		// Token: 0x0603B615 RID: 243221 RVA: 0x00F0A8D8 File Offset: 0x00F08AD8
		protected unsafe override void OnRegisterComponent()
		{
			this.ParentModel = (this.OpenParam as InstanceDungeonViewModelBase);
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickExtendToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B616 RID: 243222 RVA: 0x00F0AABC File Offset: 0x00F08CBC
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnChallengeInstanceRedDot, new Action<int>(this.OnChallengeInstanceRedDot));
			this.ExtendToggle = base.GetExtendToggle(0);
			this.ExtendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			this.ExtendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
			this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
			{
				this.OnTimer();
			}, (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
		}

		// Token: 0x0603B617 RID: 243223 RVA: 0x00F0AB4D File Offset: 0x00F08D4D
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnChallengeInstanceRedDot, new Action<int>(this.OnChallengeInstanceRedDot));
			if (this.TimerHandle != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
		}

		// Token: 0x0603B618 RID: 243224 RVA: 0x00F0AB8B File Offset: 0x00F08D8B
		private void OnTimer()
		{
			if (!this.NeedOnTimer)
			{
				return;
			}
			Action timerRefreshFunction = this.TimerRefreshFunction;
			if (timerRefreshFunction == null)
			{
				return;
			}
			timerRefreshFunction();
		}

		// Token: 0x0603B619 RID: 243225 RVA: 0x00F0ABA6 File Offset: 0x00F08DA6
		[NullableContext(1)]
		public UUIText GetTitleText()
		{
			return base.GetText(3);
		}

		// Token: 0x0603B61A RID: 243226 RVA: 0x00F0ABB0 File Offset: 0x00F08DB0
		[NullableContext(1)]
		private void RefreshSubTitle(Dictionary<int, string> subTitle)
		{
			int? num = null;
			string textStringId = null;
			foreach (KeyValuePair<int, string> keyValuePair in subTitle)
			{
				int num2;
				string text;
				keyValuePair.Deconstruct(out num2, out text);
				int value = num2;
				string text2 = text;
				num = new int?(value);
				textStringId = text2;
			}
			if (num.GetValueOrDefault() == 1)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), textStringId, Array.Empty<object>());
				return;
			}
			if (num.GetValueOrDefault() == 2)
			{
				int recommendLevel = ConfigBase<InstanceDungeonConfig>.Instance.GetRecommendLevel(this.TitleOrInstanceId, ModelBase<WorldLevelModel>.Instance.CurWorldLevel);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "RecommendLevel", new <>z__ReadOnlySingleElementList<object>(recommendLevel));
				return;
			}
			if (num.GetValueOrDefault() == 3 && !string.IsNullOrEmpty(this.SubtitleTextId))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), this.SubtitleTextId, this.SubtitleTextArgs ?? Array.Empty<string>());
			}
		}

		// Token: 0x0603B61B RID: 243227 RVA: 0x00F0ACC4 File Offset: 0x00F08EC4
		private void RefreshByTowerDefense()
		{
			if (ControllerBase<TowerDefenseController>.Instance.CheckIsInstanceUnlock(this.TitleOrInstanceId))
			{
				bool flag = ControllerBase<TowerDefenseController>.Instance.CheckInstancePassedByInstanceId(this.TitleOrInstanceId);
				if (ControllerBase<TowerDefenseController>.Instance.CheckIsChallengeInstanceByInstanceId(this.TitleOrInstanceId))
				{
					string passTimeContentByInstanceId = ControllerBase<TowerDefenseController>.Instance.GetPassTimeContentByInstanceId(this.TitleOrInstanceId);
					if (flag)
					{
						Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "TowerDefenceBestTime", new <>z__ReadOnlySingleElementList<object>(passTimeContentByInstanceId));
					}
					else
					{
						Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "Text_NotFinished_Text", Array.Empty<object>());
					}
				}
				else
				{
					int recordByInstanceId = ControllerBase<TowerDefenseController>.Instance.GetRecordByInstanceId(this.TitleOrInstanceId);
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "TowerDefence_GPint", new <>z__ReadOnlySingleElementList<object>(recordByInstanceId));
				}
				base.GetItem(6).SetUIActive(flag);
				base.GetItem(7).SetUIActive(false);
				return;
			}
			string text = ControllerBase<TowerDefenseController>.Instance.BuildInstanceCountDownText(this.TitleOrInstanceId);
			if (!string.IsNullOrEmpty(text))
			{
				UUIText text2 = base.GetText(8);
				if (text2 != null)
				{
					text2.SetText(text, true);
				}
			}
			base.GetItem(7).SetUIActive(true);
			base.GetItem(6).SetUIActive(false);
		}

		// Token: 0x0603B61C RID: 243228 RVA: 0x00F0ADEC File Offset: 0x00F08FEC
		private bool RefreshInOnlyOneGrid(bool isSelect)
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(this.TitleOrInstanceId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), config.Value.MapName, Array.Empty<object>());
			if (isSelect && this.OnClickCallbackOnlyOneGrid != null)
			{
				this.OnClickCallbackOnlyOneGrid(this.TitleOrInstanceId, this.ExtendToggle, this.CurrentData);
			}
			string difficultyIcon = config.Value.DifficultyIcon;
			UUISprite sprite = base.GetSprite(2);
			if (sprite != null)
			{
				sprite.SetUIActive(true);
			}
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			base.SetTextureByPath(difficultyIcon, base.GetTexture(2), null, null);
			UUIText text = base.GetText(8);
			if (text != null)
			{
				text.SetUIActive(true);
			}
			Dictionary<int, string> dictionary = config.Value.SubTitle();
			if (dictionary != null && dictionary.Count > 0)
			{
				this.RefreshSubTitle(dictionary);
			}
			else
			{
				if (ControllerBase<TowerDefenseController>.Instance.CheckInUiFlow())
				{
					this.RefreshByTowerDefense();
					return false;
				}
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(8), (config != null) ? config.GetValueOrDefault().SubInstanceTitle : null, Array.Empty<object>());
			}
			return true;
		}

		// Token: 0x0603B61D RID: 243229 RVA: 0x00F0AF24 File Offset: 0x00F09124
		private void RefreshNotOnlyOneGrid()
		{
			InstanceDungeonTitle? titleConfig = ConfigBase<InstanceDungeonConfig>.Instance.GetTitleConfig(this.TitleOrInstanceId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), titleConfig.Value.CommonText, Array.Empty<object>());
			UUIText text = base.GetText(8);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			string iconTexture = titleConfig.Value.IconTexture;
			if (!string.IsNullOrEmpty(iconTexture))
			{
				UUISprite sprite = base.GetSprite(2);
				if (sprite != null)
				{
					sprite.SetUIActive(true);
				}
				UUIItem item = base.GetItem(1);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				base.SetTextureByPath(iconTexture, base.GetTexture(2), null, null);
			}
		}

		// Token: 0x0603B61E RID: 243230 RVA: 0x00F0AFD0 File Offset: 0x00F091D0
		public void Update(int data, bool isSelect, bool isOnlyOneGrid = false)
		{
			this.TitleOrInstanceId = data;
			this.IsSelect = isSelect;
			this.IsOnlyOneGrid = isOnlyOneGrid;
			this.ExtendToggle.SetToggleStateForce(isSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(isSelect);
			}
			UUISprite sprite = base.GetSprite(2);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			base.TrySetTextureByPath(this.IconRightPath, base.GetTexture(10), null, null);
			UUIItem item2 = base.GetItem(1);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			this.RefreshRedDot();
			if (!isOnlyOneGrid)
			{
				this.RefreshNotOnlyOneGrid();
			}
			else if (!this.RefreshInOnlyOneGrid(isSelect))
			{
				return;
			}
			this.NeedOnTimer = this.CheckNeedOnTimer(this.TitleOrInstanceId);
			if (this.NeedOnTimer)
			{
				Action timerRefreshFunction = this.TimerRefreshFunction;
				if (timerRefreshFunction != null)
				{
					timerRefreshFunction();
				}
			}
			this.UpdateLockOrFirstReward(isOnlyOneGrid);
			this.UpdateFinishState();
		}

		// Token: 0x0603B61F RID: 243231 RVA: 0x00F0B0B1 File Offset: 0x00F092B1
		[NullableContext(1)]
		public void UpdateSubtitleByText(string text)
		{
			UUIText text2 = base.GetText(8);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(text, true);
		}

		// Token: 0x0603B620 RID: 243232 RVA: 0x00F0B0C6 File Offset: 0x00F092C6
		public void RefreshSubtitleByIdAndArgs()
		{
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(8), this.SubtitleTextId, this.SubtitleTextArgs ?? Array.Empty<string>());
		}

		// Token: 0x0603B621 RID: 243233 RVA: 0x00F0B0F0 File Offset: 0x00F092F0
		private bool CheckNeedOnTimer(int id)
		{
			if (!ControllerBase<ActivityMowingController>.Instance.IsMowingInstanceDungeon(id))
			{
				return false;
			}
			ActivityMowingData mowingActivityData = ControllerBase<ActivityMowingController>.Instance.GetMowingActivityData();
			if (mowingActivityData == null)
			{
				return false;
			}
			this.TimerRefreshFunction = new Action(this.RefreshMowingInstance);
			bool activityLevelUnlockState = mowingActivityData.GetActivityLevelUnlockState(id);
			if (activityLevelUnlockState)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "ActivityMowing_Point", new <>z__ReadOnlySingleElementList<object>(mowingActivityData.GetLevelMaxPoint(id)));
			}
			return !activityLevelUnlockState;
		}

		// Token: 0x0603B622 RID: 243234 RVA: 0x00F0B164 File Offset: 0x00F09364
		private void RefreshMowingInstance()
		{
			ActivityMowingData mowingActivityData = ControllerBase<ActivityMowingController>.Instance.GetMowingActivityData();
			if (mowingActivityData == null)
			{
				return;
			}
			string activityLevelCountdownText = mowingActivityData.GetActivityLevelCountdownText(this.TitleOrInstanceId);
			base.GetText(8).SetText(activityLevelCountdownText, true);
			if (string.IsNullOrEmpty(activityLevelCountdownText))
			{
				this.NeedOnTimer = false;
				this.Update(this.TitleOrInstanceId, this.IsSelect, this.IsOnlyOneGrid);
			}
		}

		// Token: 0x0603B623 RID: 243235 RVA: 0x00F0B1C2 File Offset: 0x00F093C2
		private void UpdateFinishState()
		{
			if (this.HasOverrideFinishState)
			{
				base.GetItem(6).SetUIActive(this.OverrideFinishState);
			}
		}

		// Token: 0x0603B624 RID: 243236 RVA: 0x00F0B1E0 File Offset: 0x00F093E0
		private void OnChallengeInstanceRedDot(int instanceId)
		{
			List<int> list;
			if (!this.ParentModel.InstanceByTitleMap.TryGetValue(this.TitleOrInstanceId, out list))
			{
				return;
			}
			if (!list.Contains(instanceId))
			{
				return;
			}
			this.RefreshRedDot();
		}

		// Token: 0x0603B625 RID: 243237 RVA: 0x00F0B218 File Offset: 0x00F09418
		[NullableContext(1)]
		public void BindClickCallback(Action<int, UUIExtendToggle, bool> onClickCallback)
		{
			this.OnClickCallback = onClickCallback;
		}

		// Token: 0x0603B626 RID: 243238 RVA: 0x00F0B221 File Offset: 0x00F09421
		public void BindClickCallbackOnlyOneGrid([Nullable(new byte[]
		{
			1,
			1,
			2
		})] Action<int, UUIExtendToggle, InstanceDetectionDynamicData> onClickCallback)
		{
			this.OnClickCallbackOnlyOneGrid = onClickCallback;
		}

		// Token: 0x0603B627 RID: 243239 RVA: 0x00F0B22A File Offset: 0x00F0942A
		[NullableContext(1)]
		public void BindCanShowRedDot(Func<int, bool> canShowRedDot)
		{
			this.CanShowRedDot = canShowRedDot;
		}

		// Token: 0x0603B628 RID: 243240 RVA: 0x00F0B234 File Offset: 0x00F09434
		private void OnClickExtendToggle(EToggleState state)
		{
			if (state != EToggleState.ETT_Checked)
			{
				return;
			}
			this.IsSelect = true;
			if (this.OnClickCallback != null)
			{
				this.OnClickCallback(this.TitleOrInstanceId, this.ExtendToggle, this.IsSelect);
			}
			if (this.OnClickCallbackOnlyOneGrid != null)
			{
				this.OnClickCallbackOnlyOneGrid(this.TitleOrInstanceId, this.ExtendToggle, this.CurrentData);
			}
		}

		// Token: 0x0603B629 RID: 243241 RVA: 0x00F0B298 File Offset: 0x00F09498
		private void UpdateLockOrFirstReward(bool isOnlyOneGrid)
		{
			bool instanceItemLockStateGetter = ControllerBase<InstanceDungeonEntranceController>.Instance.GetInstanceItemLockStateGetter(this.TitleOrInstanceId);
			base.GetItem(4).SetUIActive(!isOnlyOneGrid);
			if (!isOnlyOneGrid)
			{
				return;
			}
			if (instanceItemLockStateGetter)
			{
				base.GetItem(7).SetUIActive(true);
				base.GetItem(6).SetUIActive(false);
				return;
			}
			if (ModelBase<ExchangeRewardModel>.Instance.IsFinishInstance(this.TitleOrInstanceId))
			{
				base.GetItem(7).SetUIActive(false);
				base.GetItem(6).SetUIActive(true);
				return;
			}
			base.GetItem(7).SetUIActive(false);
			base.GetItem(6).SetUIActive(false);
		}

		// Token: 0x0603B62A RID: 243242 RVA: 0x00F0B330 File Offset: 0x00F09530
		private void OnToggleStateChange(EToggleState state)
		{
			bool flag = state == EToggleState.ETT_Checked;
			this.IsSelect = flag;
			UUIItem item = base.GetItem(5);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(flag);
		}

		// Token: 0x0603B62B RID: 243243 RVA: 0x00F0B35C File Offset: 0x00F0955C
		private void RefreshRedDot()
		{
			if (this.CanShowRedDot != null && this.CanShowRedDot(this.TitleOrInstanceId))
			{
				UUIItem item = base.GetItem(9);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(true);
				return;
			}
			else
			{
				UUIItem item2 = base.GetItem(9);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(false);
				return;
			}
		}

		// Token: 0x0402177E RID: 137086
		private UUIExtendToggle ExtendToggle;

		// Token: 0x0402177F RID: 137087
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<int, UUIExtendToggle, bool> OnClickCallback;

		// Token: 0x04021780 RID: 137088
		[Nullable(new byte[]
		{
			2,
			1,
			2
		})]
		private Action<int, UUIExtendToggle, InstanceDetectionDynamicData> OnClickCallbackOnlyOneGrid;

		// Token: 0x04021781 RID: 137089
		private Func<int, bool> CanShowRedDot;

		// Token: 0x04021782 RID: 137090
		private TimerHandle TimerHandle;

		// Token: 0x04021783 RID: 137091
		private int TitleOrInstanceId;

		// Token: 0x04021784 RID: 137092
		private bool IsSelect;

		// Token: 0x04021785 RID: 137093
		private bool IsOnlyOneGrid;

		// Token: 0x04021786 RID: 137094
		private Action TimerRefreshFunction;

		// Token: 0x04021787 RID: 137095
		private bool NeedOnTimer;

		// Token: 0x04021788 RID: 137096
		public InstanceDetectionDynamicData CurrentData;

		// Token: 0x04021789 RID: 137097
		public string SubtitleTextId;

		// Token: 0x0402178A RID: 137098
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] SubtitleTextArgs;

		// Token: 0x0402178B RID: 137099
		public bool HasOverrideFinishState;

		// Token: 0x0402178C RID: 137100
		public bool OverrideFinishState;

		// Token: 0x0402178D RID: 137101
		public string IconRightPath;

		// Token: 0x0402178E RID: 137102
		private InstanceDungeonViewModelBase ParentModel;
	}
}
