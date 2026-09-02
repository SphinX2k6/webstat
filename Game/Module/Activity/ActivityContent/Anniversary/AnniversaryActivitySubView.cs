using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Anniversary
{
	// Token: 0x020069D4 RID: 27092
	[NullableContext(1)]
	[Nullable(0)]
	public class AnniversaryActivitySubView : ActivitySubViewBase
	{
		// Token: 0x060432A4 RID: 275108 RVA: 0x01141764 File Offset: 0x0113F964
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUITexture)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(14, typeof(UUIText)),
				new ValueTuple<int, Type>(15, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(16, typeof(UUIItem)),
				new ValueTuple<int, Type>(17, typeof(UUIItem)),
				new ValueTuple<int, Type>(18, typeof(UUITexture)),
				new ValueTuple<int, Type>(19, typeof(UUITexture)),
				new ValueTuple<int, Type>(20, typeof(UUITexture)),
				new ValueTuple<int, Type>(21, typeof(UUIItem)),
				new ValueTuple<int, Type>(22, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(23, typeof(UUIItem)),
				new ValueTuple<int, Type>(24, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(25, typeof(UUIItem)),
				new ValueTuple<int, Type>(26, typeof(UUIItem)),
				new ValueTuple<int, Type>(27, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(13, new Action(this.OnClickTimeMachine)),
				new ValueTuple<int, Delegate>(22, new Action(this.OnClickPersonalRewardDisplay)),
				new ValueTuple<int, Delegate>(27, new Action(this.OnClickPersonalRewardDisplay))
			};
		}

		// Token: 0x060432A5 RID: 275109 RVA: 0x01141A50 File Offset: 0x0113FC50
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnAnniversaryActivityRewardUpdate, new Action(this.RefreshAnniversaryActivityReward));
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshActivityRedDot));
			Singleton<EventSystem>.Instance.Add(EEventName.CrossDay, new Action(this.RefreshCrossDay));
		}

		// Token: 0x060432A6 RID: 275110 RVA: 0x01141AD0 File Offset: 0x0113FCD0
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnAnniversaryActivityRewardUpdate, new Action(this.RefreshAnniversaryActivityReward));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshActivityRedDot));
			Singleton<EventSystem>.Instance.Remove(EEventName.CrossDay, new Action(this.RefreshCrossDay));
		}

		// Token: 0x060432A7 RID: 275111 RVA: 0x01141B4D File Offset: 0x0113FD4D
		protected override void OnSetData()
		{
			this.AnniversaryData = (this.ActivityBaseData as AnniversaryActivityData);
			ControllerBase<AnniversaryActivityController>.Instance.SetCheckedOpenActivity(false);
		}

		// Token: 0x060432A8 RID: 275112 RVA: 0x01141B6B File Offset: 0x0113FD6B
		protected override void OnStart()
		{
			this.RefreshTitleDeco();
		}

		// Token: 0x060432A9 RID: 275113 RVA: 0x01141B74 File Offset: 0x0113FD74
		protected override UniTask OnBeforeShowSelfAsync()
		{
			AnniversaryActivitySubView.<OnBeforeShowSelfAsync>d__23 <OnBeforeShowSelfAsync>d__;
			<OnBeforeShowSelfAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowSelfAsync>d__.<>4__this = this;
			<OnBeforeShowSelfAsync>d__.<>1__state = -1;
			<OnBeforeShowSelfAsync>d__.<>t__builder.Start<AnniversaryActivitySubView.<OnBeforeShowSelfAsync>d__23>(ref <OnBeforeShowSelfAsync>d__);
			return <OnBeforeShowSelfAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060432AA RID: 275114 RVA: 0x01141BB8 File Offset: 0x0113FDB8
		protected override UniTask OnBeforeHideSelfAsync()
		{
			AnniversaryActivitySubView.<OnBeforeHideSelfAsync>d__24 <OnBeforeHideSelfAsync>d__;
			<OnBeforeHideSelfAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideSelfAsync>d__.<>4__this = this;
			<OnBeforeHideSelfAsync>d__.<>1__state = -1;
			<OnBeforeHideSelfAsync>d__.<>t__builder.Start<AnniversaryActivitySubView.<OnBeforeHideSelfAsync>d__24>(ref <OnBeforeHideSelfAsync>d__);
			return <OnBeforeHideSelfAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060432AB RID: 275115 RVA: 0x01141BFB File Offset: 0x0113FDFB
		protected override void OnBeforeDestroy()
		{
			this.WorldProgressTextTween.Destroy();
		}

		// Token: 0x060432AC RID: 275116 RVA: 0x01141C08 File Offset: 0x0113FE08
		protected override UniTask OnBeforeStartAsync()
		{
			AnniversaryActivitySubView.<OnBeforeStartAsync>d__26 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<AnniversaryActivitySubView.<OnBeforeStartAsync>d__26>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060432AD RID: 275117 RVA: 0x01141C4C File Offset: 0x0113FE4C
		protected override void OnSequenceStart(string sequenceName)
		{
			if (sequenceName != "Start")
			{
				return;
			}
			IReadOnlyList<AnniversaryEntrance> anniversaryEntranceAll = ConfigBase<AnniversaryActivityConfig>.Instance.GetAnniversaryEntranceAll();
			if (anniversaryEntranceAll != null)
			{
				foreach (AnniversaryEntrance anniversaryEntrance in anniversaryEntranceAll)
				{
					AnniversaryActivityData anniversaryData = this.AnniversaryData;
					AnniversarySubActivityDataBase anniversarySubActivityDataBase = (anniversaryData != null) ? anniversaryData.GetTargetSubActivityData((EAnniversarySubId)anniversaryEntrance.Id) : null;
					AnniversaryActivityEnterItem anniversaryActivityEnterItem;
					if (anniversarySubActivityDataBase != null && anniversarySubActivityDataBase.NeedPlayUnlockSequence() && this.ActivityEnterItemMap.TryGetValue((EAnniversarySubId)anniversaryEntrance.Id, out anniversaryActivityEnterItem))
					{
						anniversaryActivityEnterItem.PlayUnlockSequence().Forget();
					}
				}
			}
		}

		// Token: 0x060432AE RID: 275118 RVA: 0x01141CF0 File Offset: 0x0113FEF0
		protected override void OnSequenceClose(string sequenceName)
		{
			if (sequenceName != "Start")
			{
				return;
			}
			this.WorldProgressStartSequenceClosed = true;
			this.TryPlayPendingWorldProgressTextTween();
		}

		// Token: 0x060432AF RID: 275119 RVA: 0x01141D0D File Offset: 0x0113FF0D
		private AnniversaryPersonalRewardItem CreateRewardItem()
		{
			AnniversaryPersonalRewardItem anniversaryPersonalRewardItem = new AnniversaryPersonalRewardItem();
			anniversaryPersonalRewardItem.SetClickCallback(new Action<int>(this.OnClickRewardItem));
			return anniversaryPersonalRewardItem;
		}

		// Token: 0x060432B0 RID: 275120 RVA: 0x01141D26 File Offset: 0x0113FF26
		private AnniversaryEnterRewardProgressItem CreateTaskItem()
		{
			return new AnniversaryEnterRewardProgressItem();
		}

		// Token: 0x060432B1 RID: 275121 RVA: 0x01141D30 File Offset: 0x0113FF30
		private UniTask InitActivityEnterItemsAsync(int subId, int compId)
		{
			AnniversaryActivitySubView.<InitActivityEnterItemsAsync>d__31 <InitActivityEnterItemsAsync>d__;
			<InitActivityEnterItemsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitActivityEnterItemsAsync>d__.<>4__this = this;
			<InitActivityEnterItemsAsync>d__.subId = subId;
			<InitActivityEnterItemsAsync>d__.compId = compId;
			<InitActivityEnterItemsAsync>d__.<>1__state = -1;
			<InitActivityEnterItemsAsync>d__.<>t__builder.Start<AnniversaryActivitySubView.<InitActivityEnterItemsAsync>d__31>(ref <InitActivityEnterItemsAsync>d__);
			return <InitActivityEnterItemsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060432B2 RID: 275122 RVA: 0x01141D84 File Offset: 0x0113FF84
		private AnniversaryActivityEnterItem GetAnniversaryActivityEnterItem(int subId)
		{
			switch (subId)
			{
			case 1:
				return new AnniversarySubActivityAnniversaryGiftUiItem();
			case 2:
				return new AnniversarySubActivityPinballUiItem();
			case 3:
				return new AnniversarySubActivityWuWuPackUiItem();
			case 4:
				return new AnniversarySubActivityDangoRunUiItem();
			default:
				return new AnniversaryActivityEnterItem();
			}
		}

		// Token: 0x060432B3 RID: 275123 RVA: 0x01141DCC File Offset: 0x0113FFCC
		private UniTask InitAnniversaryWorldRewardItemsAsync(int cfgId, int compId)
		{
			AnniversaryActivitySubView.<InitAnniversaryWorldRewardItemsAsync>d__33 <InitAnniversaryWorldRewardItemsAsync>d__;
			<InitAnniversaryWorldRewardItemsAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAnniversaryWorldRewardItemsAsync>d__.<>4__this = this;
			<InitAnniversaryWorldRewardItemsAsync>d__.cfgId = cfgId;
			<InitAnniversaryWorldRewardItemsAsync>d__.compId = compId;
			<InitAnniversaryWorldRewardItemsAsync>d__.<>1__state = -1;
			<InitAnniversaryWorldRewardItemsAsync>d__.<>t__builder.Start<AnniversaryActivitySubView.<InitAnniversaryWorldRewardItemsAsync>d__33>(ref <InitAnniversaryWorldRewardItemsAsync>d__);
			return <InitAnniversaryWorldRewardItemsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060432B4 RID: 275124 RVA: 0x01141E20 File Offset: 0x01140020
		private UniTask InitPersonRewardItemAsync()
		{
			AnniversaryActivitySubView.<InitPersonRewardItemAsync>d__34 <InitPersonRewardItemAsync>d__;
			<InitPersonRewardItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitPersonRewardItemAsync>d__.<>4__this = this;
			<InitPersonRewardItemAsync>d__.<>1__state = -1;
			<InitPersonRewardItemAsync>d__.<>t__builder.Start<AnniversaryActivitySubView.<InitPersonRewardItemAsync>d__34>(ref <InitPersonRewardItemAsync>d__);
			return <InitPersonRewardItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060432B5 RID: 275125 RVA: 0x01141E63 File Offset: 0x01140063
		protected override void OnRefreshView()
		{
			if (this.AnniversaryData == null)
			{
				return;
			}
			this.RefreshActivityTime();
			this.RefreshWorldProgress();
			this.RefreshPersonalProgress();
			this.RefreshWorldProgressRewards();
			this.RefreshPersonalRewards();
			this.RefreshSubActivityButtons();
		}

		// Token: 0x060432B6 RID: 275126 RVA: 0x01141E94 File Offset: 0x01140094
		private void RefreshTitleDeco()
		{
			string packageLanguage = Singleton<LanguageSystem>.Instance.PackageLanguage;
			string resourceId = "T_AnniversaryCelebrationLogo_EN";
			if (!(packageLanguage == "zh-Hans"))
			{
				if (packageLanguage == "en")
				{
					resourceId = "T_AnniversaryCelebrationLogo_EN";
				}
			}
			else
			{
				resourceId = "T_AnniversaryCelebrationLogo_CN";
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			base.TrySetTextureByPath(resourcePath, base.GetTexture(0), null, null);
		}

		// Token: 0x060432B7 RID: 275127 RVA: 0x01141F00 File Offset: 0x01140100
		protected override void OnTimer(float gap)
		{
			this.RefreshActivityTime();
			this.RefreshSubActivityTips();
		}

		// Token: 0x060432B8 RID: 275128 RVA: 0x01141F10 File Offset: 0x01140110
		private void OnClickRewardItem(int cfgId)
		{
			if (this.AnniversaryData == null)
			{
				return;
			}
			if (this.AnniversaryData.TargetPersonalCanReceive(cfgId))
			{
				ControllerBase<AnniversaryActivityController>.Instance.RequestThemePersonalScore(this.AnniversaryData);
				return;
			}
			PersonProgressCurve? personProgressCurveById = ConfigBase<AnniversaryActivityConfig>.Instance.GetPersonProgressCurveById(cfgId);
			if (personProgressCurveById == null)
			{
				return;
			}
			this.OpenRewardPreviewView(personProgressCurveById.Value.MotorPreviewId, personProgressCurveById.Value.DropId);
		}

		// Token: 0x060432B9 RID: 275129 RVA: 0x01141F80 File Offset: 0x01140180
		private void OpenDropRewardItemTips(int dropId)
		{
			Dictionary<int, int> dropPackagePreview = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreview(dropId);
			if (dropPackagePreview == null || dropPackagePreview.Count == 0)
			{
				return;
			}
			using (Dictionary<int, int>.Enumerator enumerator = dropPackagePreview.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					KeyValuePair<int, int> keyValuePair = enumerator.Current;
					int key = keyValuePair.Key;
					CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(key);
					if (itemConfigData != null && itemConfigData.ItemType.GetValueOrDefault() == InventoryDefine.EItemType.Ornament)
					{
						ControllerBase<RoleController>.Instance.OpenOrnamentPreviewView(key, null);
					}
					else
					{
						ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(key, true, null);
					}
				}
			}
		}

		// Token: 0x060432BA RID: 275130 RVA: 0x01142030 File Offset: 0x01140230
		private void RefreshActivityTime()
		{
			if (this.ActivityBaseData == null)
			{
				return;
			}
			ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(this.ActivityBaseData, null);
			bool item = timeVisibleAndRemainTime.Item1;
			string item2 = timeVisibleAndRemainTime.Item2;
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetUIActive(item);
			text.SetText(item2, true);
		}

		// Token: 0x060432BB RID: 275131 RVA: 0x0114207F File Offset: 0x0114027F
		private void BindWorldProgressTextTween()
		{
			this.WorldProgressTextTween.BindUpdateTween(new Action<float>(this.OnWorldProgressTextTweenUpdate));
			this.WorldProgressTextTween.BindCompleteTween(new Action(this.OnWorldProgressTextTweenComplete));
		}

		// Token: 0x060432BC RID: 275132 RVA: 0x011420AF File Offset: 0x011402AF
		private void OnWorldProgressTextTweenUpdate(float value)
		{
			this.SetWorldProgressTextPercentRaw(value);
		}

		// Token: 0x060432BD RID: 275133 RVA: 0x011420B8 File Offset: 0x011402B8
		private void OnWorldProgressTextTweenComplete()
		{
			AnniversaryActivityData anniversaryData = this.AnniversaryData;
			if (anniversaryData == null)
			{
				return;
			}
			anniversaryData.MarkWorldProgressNumberTweenPlayedToday();
		}

		// Token: 0x060432BE RID: 275134 RVA: 0x011420CC File Offset: 0x011402CC
		private void SetWorldProgressTextPercentRaw(float percentRaw)
		{
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			string str = (percentRaw / 100f).ToString("F1");
			text.SetText(str + "%", true);
		}

		// Token: 0x060432BF RID: 275135 RVA: 0x0114210C File Offset: 0x0114030C
		private float GetPreviousWorldProgressPercent(int worldProgressId)
		{
			if (worldProgressId <= 0)
			{
				return 0f;
			}
			IReadOnlyList<WorldProgressCurve> worldProgressCurveAll = ConfigBase<AnniversaryActivityConfig>.Instance.GetWorldProgressCurveAll();
			if (worldProgressCurveAll == null)
			{
				return 0f;
			}
			int num = -1;
			int num2 = 0;
			foreach (WorldProgressCurve worldProgressCurve in worldProgressCurveAll)
			{
				if (worldProgressCurve.Id < worldProgressId && worldProgressCurve.Id > num)
				{
					num = worldProgressCurve.Id;
					num2 = worldProgressCurve.Percent;
				}
			}
			return (float)num2;
		}

		// Token: 0x060432C0 RID: 275136 RVA: 0x01142198 File Offset: 0x01140398
		private void TryPlayPendingWorldProgressTextTween()
		{
			if (this.PendingWorldProgressTextTween == null || !this.WorldProgressStartSequenceClosed)
			{
				return;
			}
			if (this.AnniversaryData == null || !this.AnniversaryData.NeedPlayWorldProgressNumberTweenToday())
			{
				float item = this.PendingWorldProgressTextTween.Value.Item2;
				this.PendingWorldProgressTextTween = null;
				this.SetWorldProgressTextPercentRaw(item);
				return;
			}
			float item2 = this.PendingWorldProgressTextTween.Value.Item1;
			float item3 = this.PendingWorldProgressTextTween.Value.Item2;
			this.PendingWorldProgressTextTween = null;
			if (item2 == item3)
			{
				return;
			}
			this.WorldProgressTextTween.PlayTween(item2, item3, 1.25f, null);
		}

		// Token: 0x060432C1 RID: 275137 RVA: 0x0114223C File Offset: 0x0114043C
		private void RefreshWorldProgress()
		{
			if (this.AnniversaryData == null)
			{
				return;
			}
			if (base.GetText(2) == null)
			{
				return;
			}
			int worldCurProgressId = this.AnniversaryData.GetWorldCurProgressId();
			WorldProgressCurve? worldProgressCurveById = ConfigBase<AnniversaryActivityConfig>.Instance.GetWorldProgressCurveById(worldCurProgressId);
			int num = (worldProgressCurveById != null) ? worldProgressCurveById.Value.Percent : 0;
			float previousWorldProgressPercent = this.GetPreviousWorldProgressPercent(worldCurProgressId);
			this.WorldProgressTextTween.KillTween();
			bool flag = this.AnniversaryData.NeedPlayWorldProgressNumberTweenToday();
			bool flag2 = this.AnniversaryData.IsPreviousProgressFull();
			if (!flag || previousWorldProgressPercent == (float)num || flag2)
			{
				this.PendingWorldProgressTextTween = null;
				this.SetWorldProgressTextPercentRaw((float)num);
				if (flag2 && flag)
				{
					this.AnniversaryData.MarkWorldProgressNumberTweenPlayedToday();
				}
			}
			else
			{
				this.SetWorldProgressTextPercentRaw(previousWorldProgressPercent);
				this.PendingWorldProgressTextTween = new ValueTuple<float, float>?(new ValueTuple<float, float>(previousWorldProgressPercent, (float)num));
				this.TryPlayPendingWorldProgressTextTween();
			}
			IReadOnlyList<WorldProgressCurve> worldProgressCurveHadReward = ConfigBase<AnniversaryActivityConfig>.Instance.GetWorldProgressCurveHadReward();
			if (worldProgressCurveHadReward == null || worldProgressCurveHadReward.Count == 0)
			{
				return;
			}
			int num2 = num;
			int num3 = 0;
			for (int i = 0; i < 3; i++)
			{
				int num4 = 10000;
				if (i < worldProgressCurveHadReward.Count)
				{
					num4 = worldProgressCurveHadReward[i].Percent;
				}
				float val = 0f;
				if (num2 >= num4)
				{
					val = 1f;
				}
				else if (num4 > num3)
				{
					val = (float)(num2 - num3) / (float)(num4 - num3);
				}
				float num5 = Math.Max(0f, Math.Min(val, 1f));
				UUITexture texture = base.GetTexture(3 + i);
				if (texture != null)
				{
					texture.SetFillAmount(num5);
				}
				UUITexture texture2 = base.GetTexture(18 + i);
				if (texture2 != null)
				{
					texture2.SetCustomMaterialScalarParameter(this.ParameterName, num5);
				}
				num3 = num4;
			}
		}

		// Token: 0x060432C2 RID: 275138 RVA: 0x011423F0 File Offset: 0x011405F0
		private void RefreshPersonalProgress()
		{
			AnniversaryActivityData anniversaryData = this.AnniversaryData;
			int num = (anniversaryData != null) ? anniversaryData.GetPersonalCurProgress() : 0;
			UUIText text = base.GetText(14);
			if (text == null)
			{
				return;
			}
			text.SetText(num.ToString(), true);
		}

		// Token: 0x060432C3 RID: 275139 RVA: 0x0114242C File Offset: 0x0114062C
		private void RefreshWorldProgressRewards()
		{
			if (this.AnniversaryData == null)
			{
				return;
			}
			IReadOnlyList<WorldProgressCurve> readOnlyList = ConfigBase<AnniversaryActivityConfig>.Instance.GetWorldProgressCurveHadReward() ?? new List<WorldProgressCurve>();
			int worldCurProgressId = this.AnniversaryData.GetWorldCurProgressId();
			List<int> worldRewardIds = this.AnniversaryData.GetWorldRewardIds();
			for (int i = 0; i < this.WorldRewardItems.Count; i++)
			{
				GridProxyAbstract<AnniversaryWorldRewardItemData> gridProxyAbstract = this.WorldRewardItems[i];
				WorldProgressCurve worldProgressCurve = readOnlyList[i];
				bool flag = worldCurProgressId >= worldProgressCurve.Id;
				bool flag2 = worldRewardIds.Contains(worldProgressCurve.Id);
				EAnniversaryProgressRewardState value = (!flag) ? EAnniversaryProgressRewardState.Lock : (flag2 ? EAnniversaryProgressRewardState.Rewarded : EAnniversaryProgressRewardState.CanReceive);
				AnniversaryWorldRewardItemData data = new AnniversaryWorldRewardItemData
				{
					CfgId = worldProgressCurve.Id,
					State = new EAnniversaryProgressRewardState?(value)
				};
				gridProxyAbstract.Refresh(data, false, i);
			}
		}

		// Token: 0x060432C4 RID: 275140 RVA: 0x011424F0 File Offset: 0x011406F0
		private void RefreshPersonalRewards()
		{
			if (this.AnniversaryData == null)
			{
				return;
			}
			IReadOnlyList<PersonProgressCurve> personProgressCurveAll = ConfigBase<AnniversaryActivityConfig>.Instance.GetPersonProgressCurveAll();
			if (personProgressCurveAll == null || personProgressCurveAll.Count == 0)
			{
				return;
			}
			List<int> personalRewardIds = this.AnniversaryData.GetPersonalRewardIds();
			int personalCurProgress = this.AnniversaryData.GetPersonalCurProgress();
			int num = 0;
			List<AnniversaryPersonalRewardItemData> list = new List<AnniversaryPersonalRewardItemData>();
			for (int i = 0; i < personProgressCurveAll.Count; i++)
			{
				PersonProgressCurve personProgressCurve = personProgressCurveAll[i];
				PersonProgressCurve? personProgressCurveById = ConfigBase<AnniversaryActivityConfig>.Instance.GetPersonProgressCurveById(personProgressCurve.Id);
				if (personProgressCurveById != null)
				{
					bool flag = personalRewardIds.Contains(personProgressCurve.Id);
					EAnniversaryProgressRewardState value = EAnniversaryProgressRewardState.Lock;
					if (flag)
					{
						value = EAnniversaryProgressRewardState.Rewarded;
					}
					else if (personalCurProgress >= personProgressCurveById.Value.Progress)
					{
						value = EAnniversaryProgressRewardState.CanReceive;
					}
					float curProgress;
					if (personalCurProgress >= personProgressCurveById.Value.Progress)
					{
						curProgress = 1f;
					}
					else
					{
						curProgress = (float)(personalCurProgress - num) / (float)(personProgressCurveById.Value.Progress - num);
					}
					AnniversaryPersonalRewardItemData anniversaryPersonalRewardItemData = new AnniversaryPersonalRewardItemData
					{
						CfgId = personProgressCurve.Id,
						State = new EAnniversaryProgressRewardState?(value),
						CurProgress = curProgress
					};
					if (i == personProgressCurveAll.Count - 1)
					{
						AnniversaryPersonalRewardItem lastPersonalRewardDisplay = this.LastPersonalRewardDisplay;
						if (lastPersonalRewardDisplay == null)
						{
							break;
						}
						lastPersonalRewardDisplay.Refresh(anniversaryPersonalRewardItemData, false, i);
						break;
					}
					else
					{
						list.Add(anniversaryPersonalRewardItemData);
						num = personProgressCurveById.Value.Progress;
					}
				}
			}
			GenericLayout<AnniversaryPersonalRewardItem, AnniversaryPersonalRewardItemData> personalRewardLayout = this.PersonalRewardLayout;
			if (personalRewardLayout == null)
			{
				return;
			}
			personalRewardLayout.RefreshByData(list, null, false);
		}

		// Token: 0x060432C5 RID: 275141 RVA: 0x01142660 File Offset: 0x01140860
		private void RefreshSubActivityButtons()
		{
			if (this.AnniversaryData == null)
			{
				return;
			}
			foreach (KeyValuePair<EAnniversarySubId, AnniversaryActivityEnterItem> keyValuePair in this.ActivityEnterItemMap)
			{
				AnniversarySubActivityDataBase targetSubActivityData = this.AnniversaryData.GetTargetSubActivityData(keyValuePair.Key);
				if (targetSubActivityData != null)
				{
					keyValuePair.Value.Refresh(targetSubActivityData);
				}
			}
		}

		// Token: 0x060432C6 RID: 275142 RVA: 0x011426D8 File Offset: 0x011408D8
		private void RefreshSubActivityTips()
		{
			if (this.AnniversaryData == null)
			{
				return;
			}
			foreach (KeyValuePair<EAnniversarySubId, AnniversaryActivityEnterItem> keyValuePair in this.ActivityEnterItemMap)
			{
				AnniversaryActivityEnterItem value = keyValuePair.Value;
				if (value != null)
				{
					value.OnTipsTimerTick();
				}
			}
		}

		// Token: 0x060432C7 RID: 275143 RVA: 0x01142740 File Offset: 0x01140940
		private void OnClickTimeMachine()
		{
			ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(108400002);
			if (activityById == null || !activityById.IsUnLock())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Activity_Anniversary2_Lock", Array.Empty<object>());
				return;
			}
			ControllerBase<ActivityController>.Instance.OpenActivityById(108400002, EActivityViewOpenType.Other, null, null);
		}

		// Token: 0x060432C8 RID: 275144 RVA: 0x01142790 File Offset: 0x01140990
		private void OnClickPersonalRewardDisplay()
		{
			this.ShowRewardProgressDisplay = !this.ShowRewardProgressDisplay;
			this.SetVisibleRewardProgressDisplay(this.ShowRewardProgressDisplay);
		}

		// Token: 0x060432C9 RID: 275145 RVA: 0x011427B0 File Offset: 0x011409B0
		private void SetVisibleRewardProgressDisplay(bool visible)
		{
			UUIItem item = base.GetItem(23);
			if (item != null)
			{
				item.SetUIActive(visible);
			}
			FRotator frotator = visible ? this.OpenRotation : this.CloseRotation;
			UUIButtonComponent button = base.GetButton(22);
			if (button != null)
			{
				UUIItem uuiitem = button.RootUIComp.Get();
				if (uuiitem != null)
				{
					uuiitem.SetUIRelativeRotation(frotator);
				}
			}
			if (visible)
			{
				this.RefreshTaskItemLayout();
			}
		}

		// Token: 0x060432CA RID: 275146 RVA: 0x01142814 File Offset: 0x01140A14
		private void RefreshCrossDay()
		{
			if (this.AnniversaryData != null && !this.AnniversaryData.IsPreviousProgressFull() && !this.AnniversaryData.IsCurrentProgressFull())
			{
				ControllerBase<ActivityController>.Instance.ShowActivityRefreshAndBackToBattleView();
				return;
			}
			this.RefreshWorldProgress();
			this.RefreshWorldProgressRewards();
			this.RefreshPersonalRewards();
			this.RefreshPersonalProgress();
		}

		// Token: 0x060432CB RID: 275147 RVA: 0x01142866 File Offset: 0x01140A66
		private void RefreshAnniversaryActivityReward()
		{
			this.RefreshWorldProgressRewards();
			this.RefreshPersonalRewards();
			this.RefreshPersonalProgress();
		}

		// Token: 0x060432CC RID: 275148 RVA: 0x0114287A File Offset: 0x01140A7A
		private void OnCommonItemCountAnyChange(int configId, int count)
		{
			this.RefreshAnniversaryActivityReward();
		}

		// Token: 0x060432CD RID: 275149 RVA: 0x01142884 File Offset: 0x01140A84
		private void OnRefreshActivityRedDot(int id)
		{
			if (id == 108400002)
			{
				this.RefreshTimeMachineRedDot();
				return;
			}
			foreach (KeyValuePair<EAnniversarySubId, AnniversaryActivityEnterItem> keyValuePair in this.ActivityEnterItemMap)
			{
				AnniversaryEntrance? anniversaryEntranceById = ConfigBase<AnniversaryActivityConfig>.Instance.GetAnniversaryEntranceById((int)keyValuePair.Key);
				if (anniversaryEntranceById != null && anniversaryEntranceById.Value.ActivityId == id)
				{
					AnniversaryActivityEnterItem value = keyValuePair.Value;
					if (value != null)
					{
						value.RefreshRedDotItem();
					}
					AnniversaryActivityEnterItem value2 = keyValuePair.Value;
					if (value2 != null)
					{
						value2.RefreshFinished();
					}
				}
			}
		}

		// Token: 0x060432CE RID: 275150 RVA: 0x01142930 File Offset: 0x01140B30
		private void ClickWorldRewardItem(int id)
		{
			AnniversaryActivityData anniversaryData = this.AnniversaryData;
			List<int> list = (anniversaryData != null) ? anniversaryData.GetWorldCanReceiveRewardIds() : null;
			if (list != null && list.Contains(id))
			{
				if (this.AnniversaryData != null)
				{
					ControllerBase<AnniversaryActivityController>.Instance.RequestThemeWorldScore(this.AnniversaryData);
					return;
				}
			}
			else
			{
				WorldProgressCurve? worldProgressCurveById = ConfigBase<AnniversaryActivityConfig>.Instance.GetWorldProgressCurveById(id);
				if (worldProgressCurveById != null)
				{
					this.OpenRewardPreviewView(worldProgressCurveById.Value.MotorPreviewId, worldProgressCurveById.Value.DropId);
				}
			}
		}

		// Token: 0x060432CF RID: 275151 RVA: 0x011429AE File Offset: 0x01140BAE
		private void OpenRewardPreviewView(int motorPreviewId, int dropId)
		{
			if (motorPreviewId <= 0)
			{
				if (dropId > 0)
				{
					this.OpenDropRewardItemTips(dropId);
				}
				return;
			}
			MotorcycleDiyController instance = ControllerBase<MotorcycleDiyController>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.OpenMotorGeneralPreviewView(motorPreviewId);
		}

		// Token: 0x060432D0 RID: 275152 RVA: 0x011429D0 File Offset: 0x01140BD0
		private void ClickSubEnter(EAnniversarySubId id)
		{
			if (this.AnniversaryData == null)
			{
				return;
			}
			AnniversarySubActivityDataBase targetSubActivityData = this.AnniversaryData.GetTargetSubActivityData(id);
			if (targetSubActivityData == null)
			{
				return;
			}
			EAnniversaryActivityState currentState = targetSubActivityData.GetCurrentState();
			if (currentState == EAnniversaryActivityState.Lock)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Activity_Anniversary2_Lock", Array.Empty<object>());
				return;
			}
			if (currentState == EAnniversaryActivityState.Close)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Activity_Anniversary2_Finish", Array.Empty<object>());
				return;
			}
			targetSubActivityData.FirstClickOpenView();
		}

		// Token: 0x060432D1 RID: 275153 RVA: 0x01142A38 File Offset: 0x01140C38
		private void RefreshTaskItemLayout()
		{
			if (this.AnniversaryData == null)
			{
				return;
			}
			List<AnniversarySubActivityDataBase> list = new List<AnniversarySubActivityDataBase>();
			for (int i = 1; i <= 4; i++)
			{
				AnniversarySubActivityDataBase targetSubActivityData = this.AnniversaryData.GetTargetSubActivityData((EAnniversarySubId)i);
				if (targetSubActivityData != null)
				{
					list.Add(targetSubActivityData);
				}
			}
			GenericLayout<AnniversaryEnterRewardProgressItem, AnniversarySubActivityDataBase> rewardProgressItemLayout = this.RewardProgressItemLayout;
			if (rewardProgressItemLayout == null)
			{
				return;
			}
			rewardProgressItemLayout.RefreshByData(list, null, false);
		}

		// Token: 0x060432D2 RID: 275154 RVA: 0x01142A8C File Offset: 0x01140C8C
		private void RefreshTimeMachineRedDot()
		{
			ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(108400002);
			UUIItem item = base.GetItem(26);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(activityById != null && activityById.RedPointShowState);
		}

		// Token: 0x040256CF RID: 153295
		private const int MAX_WORLD_REWARD_COUNT = 3;

		// Token: 0x040256D0 RID: 153296
		private const int MAX_SUB_ACTIVITY_ENTER_COUNT = 4;

		// Token: 0x040256D1 RID: 153297
		private const string LOOP_ANNIVERSARY_ACTIVITY_BGM = "map_huodong_2ndanni_main";

		// Token: 0x040256D2 RID: 153298
		private const float WORLD_PROGRESS_TEXT_TWEEN_DURATION = 1.25f;

		// Token: 0x040256D3 RID: 153299
		[Nullable(2)]
		protected AnniversaryActivityData AnniversaryData;

		// Token: 0x040256D4 RID: 153300
		private readonly List<AnniversaryWorldRewardItem> WorldRewardItems = new List<AnniversaryWorldRewardItem>();

		// Token: 0x040256D5 RID: 153301
		private readonly Dictionary<EAnniversarySubId, AnniversaryActivityEnterItem> ActivityEnterItemMap = new Dictionary<EAnniversarySubId, AnniversaryActivityEnterItem>();

		// Token: 0x040256D6 RID: 153302
		private readonly FName ParameterName = new FName("percent");

		// Token: 0x040256D7 RID: 153303
		private readonly FRotator OpenRotation = new FRotator(0f, 180f, 0f);

		// Token: 0x040256D8 RID: 153304
		private readonly FRotator CloseRotation = new FRotator(0f, 0f, 0f);

		// Token: 0x040256D9 RID: 153305
		private bool ShowRewardProgressDisplay;

		// Token: 0x040256DA RID: 153306
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<AnniversaryPersonalRewardItem, AnniversaryPersonalRewardItemData> PersonalRewardLayout;

		// Token: 0x040256DB RID: 153307
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<AnniversaryEnterRewardProgressItem, AnniversarySubActivityDataBase> RewardProgressItemLayout;

		// Token: 0x040256DC RID: 153308
		[Nullable(2)]
		private AnniversaryPersonalRewardItem LastPersonalRewardDisplay;

		// Token: 0x040256DD RID: 153309
		private readonly LguiFloatTween WorldProgressTextTween = new LguiFloatTween();

		// Token: 0x040256DE RID: 153310
		private bool WorldProgressStartSequenceClosed;

		// Token: 0x040256DF RID: 153311
		[TupleElementNames(new string[]
		{
			"StartPercent",
			"EndPercent"
		})]
		[Nullable(0)]
		private ValueTuple<float, float>? PendingWorldProgressTextTween;

		// Token: 0x040256E0 RID: 153312
		private int LoopBgmHandle;
	}
}
