using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E6D RID: 20077
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseResultView : UiViewBase
	{
		// Token: 0x06033E23 RID: 212515 RVA: 0x00CFB0D1 File Offset: 0x00CF92D1
		public TrapDefenseResultView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06033E24 RID: 212516 RVA: 0x00CFB0DC File Offset: 0x00CF92DC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 23;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(15, new Action(this.OnClickLeave));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(16, new Action(this.OnClickShared));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033E25 RID: 212517 RVA: 0x00CFB46C File Offset: 0x00CF966C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnStartStar));
			Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseOnSystemInfoNotify, new Action(this.OnSystemNotify));
			Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseBdBuffAllUpdate, new Action(this.OnSystemNotify));
		}

		// Token: 0x06033E26 RID: 212518 RVA: 0x00CFB4D0 File Offset: 0x00CF96D0
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnStartStar));
			Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseOnSystemInfoNotify, new Action(this.OnSystemNotify));
			Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseBdBuffAllUpdate, new Action(this.OnSystemNotify));
		}

		// Token: 0x06033E27 RID: 212519 RVA: 0x00CFB534 File Offset: 0x00CF9734
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseResultView.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseResultView.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033E28 RID: 212520 RVA: 0x00CFB578 File Offset: 0x00CF9778
		protected override void OnStart()
		{
			this.BattleResultInfo = new GenericLayout<TrapDefenseResultInfoItem, ITrapDefensePauseInfo>(base.GetHorizontalLayout(7), new Func<TrapDefenseResultInfoItem>(this.CreateItem), base.GetItem(8).GetOwner() as AUIBaseActor, false, true);
			this.ExpLayout = new GenericLayout<TrapDefenseResultResultItem, ITrapDefenseResultInfo>(base.GetVerticalLayout(9), new Func<TrapDefenseResultResultItem>(this.CreateExpItem), null, false, true);
			this.UnlockLayout = new GenericLayout<TrapDefenseResultUnlockTab, ITrapDefenseResultUnlockTab>(base.GetVerticalLayout(11), new Func<TrapDefenseResultUnlockTab>(this.CreateAwardTab), null, false, true);
		}

		// Token: 0x06033E29 RID: 212521 RVA: 0x00CFB5FC File Offset: 0x00CF97FC
		protected override void OnBeforeShow()
		{
			this.BindRedDot();
			TrapDefenseLevelData curInstToLevelData = ModelBase<TrapDefenseModel>.Instance.GetCurInstToLevelData();
			string textStringId;
			switch (curInstToLevelData.Config.ModeType)
			{
			case 1:
				textStringId = "TowerDefense_Ending_MainTypeTitle_Text";
				break;
			case 2:
				textStringId = "TowerDefense_Ending_RougeTypeTitle_Text";
				break;
			case 3:
				textStringId = "TowerDefense_Ending_RougeTypeTitle_Text";
				break;
			default:
				textStringId = "TowerDefense_Ending_RougeTypeTitle_Text";
				break;
			}
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(curInstToLevelData.Config.Name, curInstToLevelData.Config.Name);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), textStringId, new <>z__ReadOnlySingleElementList<object>(multiTextByKey));
			this.OnSuccessResult(this.ResultData.Success || curInstToLevelData.Config.ModeType == 3);
			this.RefreshExpLayout();
			this.InitUnlockLayout();
			this.BtnContinue.SetUiActive(true);
			TrapDefenseLevelData nextLevelData = ModelBase<TrapDefenseModel>.Instance.GetNextLevelData(curInstToLevelData);
			if (nextLevelData != null && nextLevelData.IsUnlock && this.ResultData.Success)
			{
				this.BtnContinue.ShowText("TrapDefense_Result_Continue");
			}
			else
			{
				this.BtnContinue.ShowText("TrapDefense_Result_Retry");
			}
			List<ITrapDefensePauseInfo> list = new List<ITrapDefensePauseInfo>();
			list.Add(new TrapDefensePauseInfo
			{
				Type = ETrapDefensePauseInfoType.Health,
				Value = new int?(this.ResultData.Health)
			});
			list.Add(new TrapDefensePauseInfo
			{
				Type = ETrapDefensePauseInfoType.BatchPassed,
				Value = new int?(this.ResultData.Wave),
				MaxBatch = new int?(this.ResultData.MaxWave)
			});
			this.BattleResultInfo.RefreshByData(list, null, true);
		}

		// Token: 0x06033E2A RID: 212522 RVA: 0x00CFB798 File Offset: 0x00CF9998
		protected override void OnBeforeHide()
		{
			foreach (TrapDefenseResultResultItem trapDefenseResultResultItem in this.ExpLayout.GetLayoutItemList())
			{
				trapDefenseResultResultItem.EndStarAnim();
			}
			this.UnbindRedDot();
		}

		// Token: 0x06033E2B RID: 212523 RVA: 0x00CFB7F4 File Offset: 0x00CF99F4
		protected override void OnBeforeDestroy()
		{
			this.BtnSkill = null;
			this.BtnOrgan = null;
			this.BtnGain = null;
			this.BattleResultInfo = null;
			this.ExpLayout = null;
			this.UnlockLayout = null;
			this.ShareItem = null;
			this.ResultData = null;
		}

		// Token: 0x06033E2C RID: 212524 RVA: 0x00CFB830 File Offset: 0x00CF9A30
		protected void BindRedDot()
		{
			this.BtnSkill.BindRedDot(ERedDotName.TrapDefenseTalentTree, null);
		}

		// Token: 0x06033E2D RID: 212525 RVA: 0x00CFB856 File Offset: 0x00CF9A56
		protected void UnbindRedDot()
		{
			this.BtnSkill.UnBindRedDot();
		}

		// Token: 0x06033E2E RID: 212526 RVA: 0x00CFB864 File Offset: 0x00CF9A64
		protected void OnSuccessResult(bool isSuccess)
		{
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(isSuccess);
			}
			if (isSuccess)
			{
				string textStringId = (ModelBase<TrapDefenseModel>.Instance.GetCurInstToLevelData().Config.ModeType == 3) ? "TrapDefenseChallengeSuccess_Endless" : "TrapDefenseChallengeSuccess_Normal";
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(22), textStringId, Array.Empty<object>());
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(!isSuccess);
			}
			string resourceId = isSuccess ? "TrapDefenseResultSuccess1" : "TrapDefenseResultFail1";
			string resourceId2 = isSuccess ? "TrapDefenseResultSuccess2" : "TrapDefenseResultFail2";
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId2);
			base.SetTextureByPath(resourcePath, base.GetTexture(19), null, null);
			base.SetTextureByPath(resourcePath2, base.GetTexture(20), null, null);
			bool flag = ControllerBase<ChannelController>.Instance.CouldShare();
			UUIButtonComponent button = base.GetButton(16);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(isSuccess && flag);
			}
			bool flag2 = ModelBase<ChannelModel>.Instance.CouldGetShareReward(EShareActionId.TrapDefense);
			UUIItem item3 = base.GetItem(18);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(flag2 && isSuccess);
		}

		// Token: 0x06033E2F RID: 212527 RVA: 0x00CFB99C File Offset: 0x00CF9B9C
		private UniTask OpenShareView()
		{
			TrapDefenseResultView.<OpenShareView>d__24 <OpenShareView>d__;
			<OpenShareView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenShareView>d__.<>4__this = this;
			<OpenShareView>d__.<>1__state = -1;
			<OpenShareView>d__.<>t__builder.Start<TrapDefenseResultView.<OpenShareView>d__24>(ref <OpenShareView>d__);
			return <OpenShareView>d__.<>t__builder.Task;
		}

		// Token: 0x06033E30 RID: 212528 RVA: 0x00CFB9E0 File Offset: 0x00CF9BE0
		private UniTask WaitFrame()
		{
			TrapDefenseResultView.<WaitFrame>d__25 <WaitFrame>d__;
			<WaitFrame>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitFrame>d__.<>1__state = -1;
			<WaitFrame>d__.<>t__builder.Start<TrapDefenseResultView.<WaitFrame>d__25>(ref <WaitFrame>d__);
			return <WaitFrame>d__.<>t__builder.Task;
		}

		// Token: 0x06033E31 RID: 212529 RVA: 0x00CFBA1C File Offset: 0x00CF9C1C
		private void SetShareState(bool state)
		{
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(state);
			}
			UUIItem item2 = base.GetItem(13);
			if (item2 != null)
			{
				item2.SetUIActive(state);
			}
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(9);
			if (verticalLayout != null)
			{
				verticalLayout.RootUIComp.Get().SetUIActive(state);
			}
			UUIItem item3 = base.GetItem(18);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			this.RefreshUnlockLayout(state);
		}

		// Token: 0x06033E32 RID: 212530 RVA: 0x00CFBA8C File Offset: 0x00CF9C8C
		private void RefreshExpLayout()
		{
			List<ITrapDefenseResultInfo> list = new List<ITrapDefenseResultInfo>();
			int starRatingConditionsLength = ModelBase<TrapDefenseModel>.Instance.GetCurInstToLevelData().Config.StarRatingConditionsLength;
			int value = this.NeedShowViewAnim ? this.ResultData.FinalTarget.Count : this.ResultData.PreTarget.Count;
			TrapDefenseResultInfo item = new TrapDefenseResultInfo
			{
				Type = ETrapDefenseResultType.Star,
				Value = starRatingConditionsLength,
				History = new int?(value),
				Total = new int?(this.ResultData.FinalTarget.Count)
			};
			list.Add(item);
			if (this.ResultData.RewardLevelUpPoint > 0)
			{
				TrapDefenseResultInfo item2 = new TrapDefenseResultInfo
				{
					Type = ETrapDefenseResultType.Coin,
					Value = this.ResultData.RewardLevelUpPoint
				};
				list.Add(item2);
			}
			GenericLayout<TrapDefenseResultResultItem, ITrapDefenseResultInfo> expLayout = this.ExpLayout;
			if (expLayout == null)
			{
				return;
			}
			expLayout.RefreshByData(list, null, true);
		}

		// Token: 0x06033E33 RID: 212531 RVA: 0x00CFBB6C File Offset: 0x00CF9D6C
		private void InitUnlockLayout()
		{
			List<ITrapDefenseResultUnlockTab> unlockList = this.GetUnlockList();
			List<ITrapDefenseResultUnlockTab> sharedList = this.GetSharedList();
			List<ITrapDefenseResultUnlockTab> list = new List<ITrapDefenseResultUnlockTab>();
			list.AddRange(unlockList);
			list.AddRange(sharedList);
			GenericLayout<TrapDefenseResultUnlockTab, ITrapDefenseResultUnlockTab> unlockLayout = this.UnlockLayout;
			if (unlockLayout == null)
			{
				return;
			}
			unlockLayout.RefreshByData(list, delegate
			{
				this.RefreshUnlockLayout(true);
			}, true);
		}

		// Token: 0x06033E34 RID: 212532 RVA: 0x00CFBBBC File Offset: 0x00CF9DBC
		private List<ITrapDefenseResultUnlockTab> GetUnlockList()
		{
			List<ITrapDefenseResultUnlockTab> list = new List<ITrapDefenseResultUnlockTab>();
			List<ITrapDefenseResultUnlockInfo> list2 = new List<ITrapDefenseResultUnlockInfo>();
			List<ITrapDefenseResultUnlockInfo> list3 = new List<ITrapDefenseResultUnlockInfo>();
			bool? isNewUnlock = this.NeedShowViewAnim ? null : new bool?(true);
			foreach (int dataType in this.ResultData.UnlockAuxiliary)
			{
				ITrapDefenseMachineIdInfo info = new ITrapDefenseMachineIdInfo
				{
					MachineType = ETrapDefenseMachineType.Auxiliary,
					DataType = dataType,
					Level = 1,
					Branch = 0
				};
				TrapDefenseResultUnlockInfo item = new TrapDefenseResultUnlockInfo
				{
					Type = ETrapDefenseResultUnlockType.Organ,
					Id = ModelBase<TrapDefenseModel>.Instance.ComposeMachineId(info),
					IsNewUnlock = isNewUnlock
				};
				list2.Add(item);
			}
			foreach (int dataType2 in this.ResultData.UnlockBuilding)
			{
				ITrapDefenseMachineIdInfo info2 = new ITrapDefenseMachineIdInfo
				{
					MachineType = ETrapDefenseMachineType.Building,
					DataType = dataType2,
					Level = 1,
					Branch = 0
				};
				TrapDefenseResultUnlockInfo item2 = new TrapDefenseResultUnlockInfo
				{
					Type = ETrapDefenseResultUnlockType.Organ,
					Id = ModelBase<TrapDefenseModel>.Instance.ComposeMachineId(info2),
					IsNewUnlock = isNewUnlock
				};
				list2.Add(item2);
			}
			if (list2.Count > 0)
			{
				ITrapDefenseResultUnlockTab item3 = new ITrapDefenseResultUnlockTab
				{
					Type = ETrapDefenseResultUnlockType.Organ,
					DataList = list2
				};
				list.Add(item3);
			}
			foreach (int id in this.ResultData.UnlockBds)
			{
				TrapDefenseResultUnlockInfo item4 = new TrapDefenseResultUnlockInfo
				{
					Type = ETrapDefenseResultUnlockType.Bd,
					Id = id,
					IsNewUnlock = isNewUnlock
				};
				list3.Add(item4);
			}
			if (list3.Count > 0)
			{
				ITrapDefenseResultUnlockTab item5 = new ITrapDefenseResultUnlockTab
				{
					Type = ETrapDefenseResultUnlockType.Bd,
					DataList = list3
				};
				list.Add(item5);
			}
			return list;
		}

		// Token: 0x06033E35 RID: 212533 RVA: 0x00CFBDD4 File Offset: 0x00CF9FD4
		private List<ITrapDefenseResultUnlockTab> GetSharedList()
		{
			List<ITrapDefenseResultUnlockTab> list = new List<ITrapDefenseResultUnlockTab>();
			List<ITrapDefenseResultUnlockInfo> list2 = new List<ITrapDefenseResultUnlockInfo>();
			List<ITrapDefenseResultUnlockInfo> list3 = new List<ITrapDefenseResultUnlockInfo>();
			foreach (TrapDefenseBuildingSlotData trapDefenseBuildingSlotData in ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.GetSlotData())
			{
				TrapDefenseBuildingDevelopItemData slotData = trapDefenseBuildingSlotData.GetSlotData();
				if (slotData != null)
				{
					ITrapDefenseMachineIdInfo info = new ITrapDefenseMachineIdInfo
					{
						MachineType = (slotData.IsBuilding ? ETrapDefenseMachineType.Building : ETrapDefenseMachineType.Auxiliary),
						DataType = slotData.GetDataType(),
						Level = slotData.GetLevel(),
						Branch = slotData.GetBranch()
					};
					TrapDefenseResultUnlockInfo item = new TrapDefenseResultUnlockInfo
					{
						Type = ETrapDefenseResultUnlockType.OrganShare,
						Id = ModelBase<TrapDefenseModel>.Instance.ComposeMachineId(info)
					};
					list2.Add(item);
				}
			}
			if (list2.Count > 0)
			{
				ITrapDefenseResultUnlockTab item2 = new ITrapDefenseResultUnlockTab
				{
					Type = ETrapDefenseResultUnlockType.OrganShare,
					DataList = list2
				};
				list.Add(item2);
			}
			foreach (KeyValuePair<int, TrapDefenseBdData> keyValuePair in ModelBase<TrapDefenseModel>.Instance.RougeModeData.BdDataMap)
			{
				int num;
				TrapDefenseBdData trapDefenseBdData;
				keyValuePair.Deconstruct(out num, out trapDefenseBdData);
				int id = num;
				TrapDefenseBdData trapDefenseBdData2 = trapDefenseBdData;
				if (trapDefenseBdData2.GetCurrentActiveProgressNum() != 0 && !trapDefenseBdData2.IsZeroBdType())
				{
					TrapDefenseResultUnlockInfo item3 = new TrapDefenseResultUnlockInfo
					{
						Type = ETrapDefenseResultUnlockType.BdShare,
						Id = id,
						NeedUnlockBar = new bool?(false),
						ForShare = new bool?(true)
					};
					list3.Add(item3);
					if (list3.Count >= 4)
					{
						break;
					}
				}
			}
			if (list3.Count > 0)
			{
				ITrapDefenseResultUnlockTab item4 = new ITrapDefenseResultUnlockTab
				{
					Type = ETrapDefenseResultUnlockType.BdShare,
					DataList = list3
				};
				list.Add(item4);
			}
			return list;
		}

		// Token: 0x06033E36 RID: 212534 RVA: 0x00CFBFAC File Offset: 0x00CFA1AC
		private void RefreshUnlockLayout(bool isUnlock)
		{
			foreach (TrapDefenseResultUnlockTab trapDefenseResultUnlockTab in this.UnlockLayout.GetLayoutItemList())
			{
				trapDefenseResultUnlockTab.SetUiActive(trapDefenseResultUnlockTab.IsShared != isUnlock);
			}
		}

		// Token: 0x06033E37 RID: 212535 RVA: 0x00CFC010 File Offset: 0x00CFA210
		private void OnClickSkill()
		{
			ModelBase<TrapDefenseModel>.Instance.OpenViewTalentTree(null);
		}

		// Token: 0x06033E38 RID: 212536 RVA: 0x00CFC01D File Offset: 0x00CFA21D
		private void OnClickOrgan()
		{
			ControllerBase<TrapDefenseController>.Instance.OpenOrganDevelop(false, this, 0, null);
		}

		// Token: 0x06033E39 RID: 212537 RVA: 0x00CFC030 File Offset: 0x00CFA230
		private void OnClickGain()
		{
			ModelBase<TrapDefenseModel>.Instance.OpenViewBdSum(null, null, null);
		}

		// Token: 0x06033E3A RID: 212538 RVA: 0x00CFC064 File Offset: 0x00CFA264
		private void OnClickContinue()
		{
			TrapDefenseResultView.<>c__DisplayClass35_0 CS$<>8__locals1 = new TrapDefenseResultView.<>c__DisplayClass35_0();
			Singleton<AudioSystem>.Instance.ExecuteAction("play_2_6_tower_defence_music_ingame", EAudioActionType.Stop, null);
			CS$<>8__locals1.levelData = ModelBase<TrapDefenseModel>.Instance.GetCurInstToLevelData();
			if (CS$<>8__locals1.levelData == null)
			{
				return;
			}
			TrapDefenseLevelData nextLevelData = ModelBase<TrapDefenseModel>.Instance.GetNextLevelData(CS$<>8__locals1.levelData);
			if (!this.ResultData.Success || nextLevelData == null || !nextLevelData.IsUnlock)
			{
				if (!ModelBase<TrapDefenseModel>.Instance.CheckNextLevelThreshold(CS$<>8__locals1.levelData, new Action(CS$<>8__locals1.<OnClickContinue>g__cb|0), this))
				{
					ControllerBase<TrapDefenseController>.Instance.RequestChallenge(CS$<>8__locals1.levelData, false).Forget<bool>();
				}
				return;
			}
			if (nextLevelData.Config.ModeType == 1)
			{
				ModelBase<TrapDefenseModel>.Instance.OpenViewMainLevelMode(new int?(nextLevelData.Id), new ETrapDefenseDifficultyLevel?((ETrapDefenseDifficultyLevel)nextLevelData.Config.Difficulty), new bool?(false));
				return;
			}
			ModelBase<TrapDefenseModel>.Instance.OpenViewRougeLevelMode(new int?(nextLevelData.Id), new bool?(false));
		}

		// Token: 0x06033E3B RID: 212539 RVA: 0x00CFC160 File Offset: 0x00CFA360
		private void OnClickLeave()
		{
			Singleton<AudioSystem>.Instance.ExecuteAction("play_2_6_tower_defence_music_ingame", EAudioActionType.Stop, null);
			ModelBase<TrapDefenseModel>.Instance.NeedOpenMainView = true;
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeonRequest(LeaveInstWay.Default).Forget<bool>();
		}

		// Token: 0x06033E3C RID: 212540 RVA: 0x00CFC1A1 File Offset: 0x00CFA3A1
		private void OnClickShared()
		{
			this.OpenShareView().Forget();
		}

		// Token: 0x06033E3D RID: 212541 RVA: 0x00CFC1AE File Offset: 0x00CFA3AE
		private TrapDefenseResultInfoItem CreateItem()
		{
			return new TrapDefenseResultInfoItem();
		}

		// Token: 0x06033E3E RID: 212542 RVA: 0x00CFC1B5 File Offset: 0x00CFA3B5
		private TrapDefenseResultResultItem CreateExpItem()
		{
			return new TrapDefenseResultResultItem();
		}

		// Token: 0x06033E3F RID: 212543 RVA: 0x00CFC1BC File Offset: 0x00CFA3BC
		private TrapDefenseResultUnlockTab CreateAwardTab()
		{
			return new TrapDefenseResultUnlockTab();
		}

		// Token: 0x06033E40 RID: 212544 RVA: 0x00CFC1C4 File Offset: 0x00CFA3C4
		private void OnStartStar(string name)
		{
			if (name != "Start")
			{
				return;
			}
			foreach (TrapDefenseResultResultItem trapDefenseResultResultItem in this.ExpLayout.GetLayoutItemList())
			{
				trapDefenseResultResultItem.PlayStarIn();
			}
			TimerSystem.Instance.Delay(delegate(float _)
			{
				foreach (TrapDefenseResultUnlockTab trapDefenseResultUnlockTab in this.UnlockLayout.GetLayoutItemList())
				{
					trapDefenseResultUnlockTab.PlayUnlockAnim();
				}
			}, 500f, null, null, true, 1f);
		}

		// Token: 0x06033E41 RID: 212545 RVA: 0x00CFC24C File Offset: 0x00CFA44C
		private void OnSystemNotify()
		{
			this.InitUnlockLayout();
		}

		// Token: 0x06033E42 RID: 212546 RVA: 0x00CFC254 File Offset: 0x00CFA454
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			if (!(configParams[0] == "HighestRecord"))
			{
				return null;
			}
			GenericLayout<TrapDefenseResultResultItem, ITrapDefenseResultInfo> expLayout = this.ExpLayout;
			UUIItem uuiitem = (expLayout != null) ? expLayout.GetItemByIndex(0) : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x0401E021 RID: 122913
		protected TrapDefenseResultButton BtnSkill;

		// Token: 0x0401E022 RID: 122914
		protected TrapDefenseResultButton BtnOrgan;

		// Token: 0x0401E023 RID: 122915
		protected TrapDefenseResultButton BtnGain;

		// Token: 0x0401E024 RID: 122916
		protected TrapDefenseResultContinueButton BtnContinue;

		// Token: 0x0401E025 RID: 122917
		protected GenericLayout<TrapDefenseResultInfoItem, ITrapDefensePauseInfo> BattleResultInfo;

		// Token: 0x0401E026 RID: 122918
		protected TrapDefenseShareTips ShareItem;

		// Token: 0x0401E027 RID: 122919
		protected GenericLayout<TrapDefenseResultResultItem, ITrapDefenseResultInfo> ExpLayout;

		// Token: 0x0401E028 RID: 122920
		protected GenericLayout<TrapDefenseResultUnlockTab, ITrapDefenseResultUnlockTab> UnlockLayout;

		// Token: 0x0401E029 RID: 122921
		protected string PassTime;

		// Token: 0x0401E02A RID: 122922
		protected TrapDefenseResultInfo ResultData;

		// Token: 0x0401E02B RID: 122923
		protected bool NeedShowViewAnim;

		// Token: 0x0200AE23 RID: 44579
		[NullableContext(0)]
		private class EMainDefine
		{
			// Token: 0x0403613E RID: 221502
			public const int GainItemLayout = 0;

			// Token: 0x0403613F RID: 221503
			public const int BtnSkill = 1;

			// Token: 0x04036140 RID: 221504
			public const int BtnOrgan = 2;

			// Token: 0x04036141 RID: 221505
			public const int BtnGain = 3;

			// Token: 0x04036142 RID: 221506
			public const int PanelSuccess = 4;

			// Token: 0x04036143 RID: 221507
			public const int PanelFail = 5;

			// Token: 0x04036144 RID: 221508
			public const int TxtSubTitle = 6;

			// Token: 0x04036145 RID: 221509
			public const int BaseInfoLayout = 7;

			// Token: 0x04036146 RID: 221510
			public const int BaseInfoItem = 8;

			// Token: 0x04036147 RID: 221511
			public const int PanelExpResult = 9;

			// Token: 0x04036148 RID: 221512
			public const int ExpResultItem = 10;

			// Token: 0x04036149 RID: 221513
			public const int PanelBuffItemLayout = 11;

			// Token: 0x0403614A RID: 221514
			public const int BuffItemGroup = 12;

			// Token: 0x0403614B RID: 221515
			public const int PanelBottomBtn = 13;

			// Token: 0x0403614C RID: 221516
			public const int BtnConfirmContinue = 14;

			// Token: 0x0403614D RID: 221517
			public const int BtnConfirmLeave = 15;

			// Token: 0x0403614E RID: 221518
			public const int BtnShare = 16;

			// Token: 0x0403614F RID: 221519
			public const int ShareItemContent = 17;

			// Token: 0x04036150 RID: 221520
			public const int PanelShareTips = 18;

			// Token: 0x04036151 RID: 221521
			public const int BgTexture1 = 19;

			// Token: 0x04036152 RID: 221522
			public const int BgTexture2 = 20;

			// Token: 0x04036153 RID: 221523
			public const int BgLevel = 21;

			// Token: 0x04036154 RID: 221524
			public const int TxtSuccess = 22;
		}
	}
}
