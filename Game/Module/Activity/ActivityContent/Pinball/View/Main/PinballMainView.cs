using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Main
{
	// Token: 0x020065FD RID: 26109
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballMainView : PinballMainChildViewBase<PinballMainViewModel>
	{
		// Token: 0x060413AD RID: 267181 RVA: 0x010BB3B8 File Offset: 0x010B95B8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnBtnDailyLevelClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnBtnNewTowerLevelClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060413AE RID: 267182 RVA: 0x010BB5F4 File Offset: 0x010B97F4
		protected override UniTask OnBeforeStartAsync()
		{
			PinballMainView.<OnBeforeStartAsync>d__41 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballMainView.<OnBeforeStartAsync>d__41>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060413AF RID: 267183 RVA: 0x010BB637 File Offset: 0x010B9837
		protected override void OnBeforeShow()
		{
			this.LastGamepadChapterIndex = -1;
			this.SetCaptionInfo();
			this.RefreshAllChapterItems();
			this.RefreshNormalButtonStates();
			this.InitChapterScrollTween();
			UUIInturnAnimController scrollAnimController = this.ScrollAnimController;
			if (scrollAnimController != null)
			{
				scrollAnimController.Play("", -1, false);
			}
			this.StartScrollTick();
		}

		// Token: 0x060413B0 RID: 267184 RVA: 0x010BB676 File Offset: 0x010B9876
		protected override void OnBeforeHide()
		{
			this.StopScrollTick();
			this.ScrollProgressTween.KillTween();
		}

		// Token: 0x060413B1 RID: 267185 RVA: 0x010BB68C File Offset: 0x010B988C
		protected override void OnBeforeDestroy()
		{
			this.RemoveScrollTick();
			this.ScrollProgressTween.Destroy();
			foreach (PinballMainButtonItem pinballMainButtonItem in this.ButtonItems.Values)
			{
				pinballMainButtonItem.Clear();
			}
			this.ButtonItems.Clear();
			this.ButtonConfigList = new List<IPinballMainButtonConfig>();
		}

		// Token: 0x060413B2 RID: 267186 RVA: 0x010BB708 File Offset: 0x010B9908
		private void InitButtonConfigs()
		{
			if (this.ButtonConfigList.Count > 0)
			{
				return;
			}
			this.ButtonConfigList = new List<IPinballMainButtonConfig>();
			PinballMainButtonConfig item = new PinballMainButtonConfig
			{
				Type = EPinballMainButtonFunctionType.PermanentReward,
				UiRegisterId = 3,
				OnClickCallback = new Action(this.OnBtnPermanentReward),
				SetTextCallback = new Action<UUIText>(this.OnBtnPermanentRewardProgress),
				ShowRedDot = new Func<bool>(this.OnShowPermanentRewardRedDot)
			};
			PinballMainButtonConfig item2 = new PinballMainButtonConfig
			{
				Type = EPinballMainButtonFunctionType.LimitReward,
				UiRegisterId = 4,
				OnClickCallback = new Action(this.OnBtnLimitReward),
				SetTextCallback = new Action<UUIText>(this.OnBtnLimitRewardProgress),
				ShowRedDot = new Func<bool>(this.OnShowLimitRewardRedDot),
				ShowCallback = new Func<bool>(this.OnShowLimitRewardButton)
			};
			PinballMainButtonConfig item3 = new PinballMainButtonConfig
			{
				FunctionId = new int?(10153),
				Type = EPinballMainButtonFunctionType.Shop,
				UiRegisterId = 5,
				OnClickCallback = new Action(this.OnBtnShop),
				ShowRedDot = new Func<bool>(this.OnShowShopRedDot)
			};
			PinballMainButtonConfig item4 = new PinballMainButtonConfig
			{
				FunctionId = new int?(10152),
				Type = EPinballMainButtonFunctionType.Role,
				UiRegisterId = 6,
				OnClickCallback = new Action(this.OnBtnRole),
				RedDotName = new ERedDotName?(ERedDotName.RedDotPinballRoleFunction)
			};
			this.ButtonConfigList.Add(item);
			this.ButtonConfigList.Add(item2);
			this.ButtonConfigList.Add(item3);
			this.ButtonConfigList.Add(item4);
		}

		// Token: 0x060413B3 RID: 267187 RVA: 0x010BB894 File Offset: 0x010B9A94
		private UniTask LoadCurveResource()
		{
			PinballMainView.<LoadCurveResource>d__46 <LoadCurveResource>d__;
			<LoadCurveResource>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadCurveResource>d__.<>4__this = this;
			<LoadCurveResource>d__.<>1__state = -1;
			<LoadCurveResource>d__.<>t__builder.Start<PinballMainView.<LoadCurveResource>d__46>(ref <LoadCurveResource>d__);
			return <LoadCurveResource>d__.<>t__builder.Task;
		}

		// Token: 0x060413B4 RID: 267188 RVA: 0x010BB8D8 File Offset: 0x010B9AD8
		private UniTask CreateButtons()
		{
			PinballMainView.<CreateButtons>d__47 <CreateButtons>d__;
			<CreateButtons>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateButtons>d__.<>4__this = this;
			<CreateButtons>d__.<>1__state = -1;
			<CreateButtons>d__.<>t__builder.Start<PinballMainView.<CreateButtons>d__47>(ref <CreateButtons>d__);
			return <CreateButtons>d__.<>t__builder.Task;
		}

		// Token: 0x060413B5 RID: 267189 RVA: 0x010BB91C File Offset: 0x010B9B1C
		private UUIItem CreateChapterUiItem(bool isTower = false)
		{
			UUIItem item = isTower ? base.GetItem(2) : base.GetItem(1);
			UUIItem uiitem = base.GetScrollViewWithScrollbar(0).Content.Get().GetUIItem();
			return Singleton<LguiUtil>.Instance.CopyItem(item, uiitem);
		}

		// Token: 0x060413B6 RID: 267190 RVA: 0x010BB964 File Offset: 0x010B9B64
		private UniTask CreateAllChapterItems()
		{
			PinballMainView.<CreateAllChapterItems>d__49 <CreateAllChapterItems>d__;
			<CreateAllChapterItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateAllChapterItems>d__.<>4__this = this;
			<CreateAllChapterItems>d__.<>1__state = -1;
			<CreateAllChapterItems>d__.<>t__builder.Start<PinballMainView.<CreateAllChapterItems>d__49>(ref <CreateAllChapterItems>d__);
			return <CreateAllChapterItems>d__.<>t__builder.Task;
		}

		// Token: 0x060413B7 RID: 267191 RVA: 0x010BB9A8 File Offset: 0x010B9BA8
		private void SetChapterItemOffset(UUIItem item, int index, int totalCount, float stepOffset = 0f, float contentOffsetX = 0f)
		{
			int num = totalCount - 1;
			float num2 = 0.79999995f / (float)num;
			float num3 = this.HorizontalOffsetOriX + 95f;
			float num4 = 0.1f + ((float)index - stepOffset) * num2;
			float num5 = (num > 0 && index == num) ? (num2 * 0.125f) : 0f;
			float num6 = num4 + num5;
			float floatValue = this.ChapterScrollCurve.GetFloatValue(num4);
			float num7 = num6 * this.TotalCurveWidth * 1f;
			float num8 = num3 + num7 - contentOffsetX;
			float num9 = this.ContentHeight * floatValue - this.HorizontalOffsetOriY - 100f;
			this.UiOffset.Set((double)num8, (double)num9);
			item.SetAnchorOffset(this.UiOffset.ToUeVector2D(false));
		}

		// Token: 0x060413B8 RID: 267192 RVA: 0x010BBA5C File Offset: 0x010B9C5C
		private void SetCaptionInfo()
		{
			if (base.ViewModel != null)
			{
				Action<string> setViewTitle = base.ViewModel.SetViewTitle;
				if (setViewTitle != null)
				{
					setViewTitle("Pinball_Main_Ttile");
				}
				Action<int> setViewHelpId = base.ViewModel.SetViewHelpId;
				if (setViewHelpId != null)
				{
					setViewHelpId(555);
				}
				base.ViewModel.SetOverrideCloseFunc(new Action(this.OnBtnBackClick));
			}
		}

		// Token: 0x060413B9 RID: 267193 RVA: 0x010BBAC0 File Offset: 0x010B9CC0
		private void RefreshLimitRewardMainButton()
		{
			PinballMainButtonItem pinballMainButtonItem;
			this.ButtonItems.TryGetValue(EPinballMainButtonFunctionType.LimitReward, out pinballMainButtonItem);
			if (pinballMainButtonItem != null)
			{
				pinballMainButtonItem.SetButtonState();
			}
			if (pinballMainButtonItem != null)
			{
				pinballMainButtonItem.SetProgressText();
			}
			if (pinballMainButtonItem != null)
			{
				pinballMainButtonItem.SetRedDot();
			}
		}

		// Token: 0x060413BA RID: 267194 RVA: 0x010BBAF8 File Offset: 0x010B9CF8
		private void RefreshNormalButtonStates()
		{
			foreach (PinballMainButtonItem pinballMainButtonItem in this.ButtonItems.Values)
			{
				pinballMainButtonItem.SetButtonState();
				pinballMainButtonItem.SetProgressText();
				pinballMainButtonItem.SetRedDot();
			}
			PinballActivity? pinballActivityConfigByActivityId = ConfigBase<PinballConfig>.Instance.GetPinballActivityConfigByActivityId(this.ActivityData.Id);
			bool uiactive = ModelBase<FunctionModel>.Instance.IsOpen(pinballActivityConfigByActivityId.Value.DailyLevelFuncId);
			base.GetItem(11).SetUIActive(uiactive);
			base.GetItem(9).SetUIActive(false);
			base.GetText(10).SetUIActive(false);
			PinballChapterData dailyChapterData = this.ActivityData.GetDailyChapterData();
			if (dailyChapterData != null)
			{
				PinballChapterConfig? pinballChapterConfigById = ConfigBase<PinballConfig>.Instance.GetPinballChapterConfigById(dailyChapterData.ChapterId);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), pinballChapterConfigById.Value.Name, Array.Empty<object>());
			}
		}

		// Token: 0x060413BB RID: 267195 RVA: 0x010BBBFC File Offset: 0x010B9DFC
		private void BindAllButtonRedDot()
		{
			foreach (PinballMainButtonItem pinballMainButtonItem in this.ButtonItems.Values)
			{
				pinballMainButtonItem.BindRedDot();
			}
		}

		// Token: 0x060413BC RID: 267196 RVA: 0x010BBC54 File Offset: 0x010B9E54
		private void RefreshAllChapterItems()
		{
			this.NeedPlayTweenChapterItemMap.Clear();
			List<PinballChapterData> mainChapterList = this.ActivityData.GetMainChapterList();
			for (int i = 0; i < mainChapterList.Count; i++)
			{
				PinballChapterData pinballChapterData = mainChapterList[i];
				PinballMainChapterItem pinballMainChapterItem = this.ChapterItemList[i];
				bool flag = this.ActivityData.IsNewChapterUnlocked(pinballChapterData.ChapterId);
				pinballMainChapterItem.Refresh(pinballChapterData, flag);
				if (flag)
				{
					this.NeedPlayTweenChapterItemMap[pinballMainChapterItem] = pinballChapterData;
				}
			}
			PinballChapterData towerChapterData = this.ActivityData.GetTowerChapterData();
			if (towerChapterData != null)
			{
				bool flag2 = this.ActivityData.IsNewChapterUnlocked(towerChapterData.ChapterId);
				this.TowerChapterItem.Refresh(towerChapterData, flag2);
				if (flag2)
				{
					this.NeedPlayTweenChapterItemMap[this.TowerChapterItem] = towerChapterData;
				}
				bool flag3 = false;
				if (this.ActivityData.GetChapterLockStatus(towerChapterData.ChapterId) == EPinballChapterLevelLockStatus.Activated)
				{
					foreach (int levelId in towerChapterData.LevelIds)
					{
						int num = this.ActivityData.IsLevelPassed(levelId) ? 1 : 0;
						bool flag4 = this.ActivityData.GetLevelLockStatus(levelId) == EPinballChapterLevelLockStatus.Activated;
						if (num == 0 && flag4)
						{
							flag3 = true;
							break;
						}
					}
				}
				base.GetButton(12).RootUIComp.Get().SetUIActive(flag3);
				if (flag3)
				{
					Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "PinballNewTowerLevelBtn");
				}
			}
		}

		// Token: 0x060413BD RID: 267197 RVA: 0x010BBDB4 File Offset: 0x010B9FB4
		private void InitChapterScrollTween()
		{
			if (this.IsInitialChapterScroll || this.ChapterUiItemList.Count <= 0)
			{
				return;
			}
			if (base.GetScrollViewWithScrollbar(0) == null)
			{
				return;
			}
			int targetIndex = this.GetLatestUnlockedChapterIndex();
			float scrollProgressByIndex = this.GetScrollProgressByIndex(targetIndex);
			float entranceProgress = this.GetEntranceProgress();
			this.DisplayScrollProgress = entranceProgress;
			this.SyncScrollProgress(entranceProgress);
			this.UpdateChapterItemsByCurve(entranceProgress);
			this.PlayScrollProgressTween(entranceProgress, scrollProgressByIndex, 1f, delegate
			{
				if (Singleton<Info>.Instance.IsInGamepad())
				{
					UUIItem uuiitem = (targetIndex == this.ChapterUiItemList.Count - 1) ? this.TowerChapterItem.GetChapterButtonUiItem() : this.ChapterItemList[targetIndex].GetChapterButtonUiItem();
					if (uuiitem != null)
					{
						ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(uuiitem, false, false, false);
					}
				}
				this.PlayChapterUnlockTween();
			});
		}

		// Token: 0x060413BE RID: 267198 RVA: 0x010BBE40 File Offset: 0x010BA040
		private void PlayChapterUnlockTween()
		{
			if (this.NeedPlayTweenChapterItemMap.Count <= 0)
			{
				return;
			}
			List<UniTask> list = new List<UniTask>();
			foreach (KeyValuePair<IPinballChapterItem, PinballChapterData> keyValuePair in this.NeedPlayTweenChapterItemMap)
			{
				IPinballChapterItem pinballChapterItem;
				PinballChapterData pinballChapterData;
				keyValuePair.Deconstruct(out pinballChapterItem, out pinballChapterData);
				IPinballChapterItem pinballChapterItem2 = pinballChapterItem;
				PinballChapterData data = pinballChapterData;
				pinballChapterItem2.Refresh(data);
				list.Add(pinballChapterItem2.PlayUnlockTweenAsync());
			}
			UniTask.WhenAll(list.ToArray()).Forget();
		}

		// Token: 0x060413BF RID: 267199 RVA: 0x010BBED8 File Offset: 0x010BA0D8
		private void AddScrollTick()
		{
			this.ScrollTickId = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnScrollTick), "PinballMainViewChapterScroll", ETickingGroup.TG_PrePhysics, true, 0, true).Id;
		}

		// Token: 0x060413C0 RID: 267200 RVA: 0x010BBF04 File Offset: 0x010BA104
		private void StartScrollTick()
		{
			if (this.ScrollTickId != -1)
			{
				Singleton<TickSystem>.Instance.Resume(this.ScrollTickId);
			}
		}

		// Token: 0x060413C1 RID: 267201 RVA: 0x010BBF20 File Offset: 0x010BA120
		private void StopScrollTick()
		{
			if (this.ScrollTickId != -1)
			{
				Singleton<TickSystem>.Instance.Pause(this.ScrollTickId);
			}
		}

		// Token: 0x060413C2 RID: 267202 RVA: 0x010BBF3C File Offset: 0x010BA13C
		private void RemoveScrollTick()
		{
			if (this.ScrollTickId != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.ScrollTickId);
				this.ScrollTickId = -1;
			}
		}

		// Token: 0x060413C3 RID: 267203 RVA: 0x010BBF60 File Offset: 0x010BA160
		private void OnScrollTick(float deltaTime)
		{
			this.LimitRewardButtonRefreshTime += deltaTime;
			if (this.LimitRewardButtonRefreshTime >= 1000f)
			{
				this.LimitRewardButtonRefreshTime = 0f;
				this.RefreshLimitRewardMainButton();
			}
			if (!this.IsInitialChapterScroll || this.ChapterUiItemList.Count <= 0)
			{
				return;
			}
			this.OnRefreshAllChapterItemsTick(deltaTime);
		}

		// Token: 0x060413C4 RID: 267204 RVA: 0x010BBFB7 File Offset: 0x010BA1B7
		private void OnRefreshAllChapterItemsTick(float deltaTime)
		{
			this.AllChaptersRefreshTime += deltaTime;
			if (this.AllChaptersRefreshTime >= 1000f)
			{
				this.AllChaptersRefreshTime = 0f;
				this.RefreshAllChapterItems();
				this.PlayChapterUnlockTween();
			}
		}

		// Token: 0x060413C5 RID: 267205 RVA: 0x010BBFEC File Offset: 0x010BA1EC
		private int GetLatestUnlockedChapterIndex()
		{
			List<PinballChapterData> mainChapterList = this.ActivityData.GetMainChapterList();
			PinballActivityData activityData = this.ActivityData;
			int result = 0;
			bool flag = true;
			for (int i = 0; i < mainChapterList.Count; i++)
			{
				if (activityData.GetChapterLockStatus(mainChapterList[i].ChapterId) == EPinballChapterLevelLockStatus.Activated)
				{
					result = i;
				}
				if (!activityData.IsChapterPassed(mainChapterList[i].ChapterId))
				{
					flag = false;
				}
			}
			if (flag)
			{
				PinballChapterData towerChapterData = activityData.GetTowerChapterData();
				if (activityData.GetChapterLockStatus(towerChapterData.ChapterId) == EPinballChapterLevelLockStatus.Activated)
				{
					result = this.ChapterUiItemList.Count - 1;
				}
			}
			return result;
		}

		// Token: 0x060413C6 RID: 267206 RVA: 0x010BC080 File Offset: 0x010BA280
		private float GetEntranceProgress()
		{
			int num = this.ChapterUiItemList.Count - 1;
			if (num <= 0)
			{
				return 0f;
			}
			float maxStepOffset = this.GetMaxStepOffset(num);
			float num2 = this.HorizontalOffsetOriX + 95f;
			UUIItem uuiitem = this.ChapterUiItemList[0];
			float num3 = (uuiitem != null) ? (uuiitem.GetWidth() / 2f) : 0f;
			float num4 = this.ViewportWidth / 2f + num3;
			float num5 = this.TotalCurveWidth * 1f;
			float num6 = (num4 - num2) / num5;
			return (float)(-(float)num) * num6 / maxStepOffset;
		}

		// Token: 0x060413C7 RID: 267207 RVA: 0x010BC10C File Offset: 0x010BA30C
		private float GetScrollProgressByIndex(int targetIndex)
		{
			int num = this.ChapterUiItemList.Count - 1;
			float num2 = this.HorizontalOffsetOriX + 95f;
			float num3 = this.TotalCurveWidth * 1f;
			float num4 = -num2 / num3;
			float num5 = (float)targetIndex - (float)num * num4;
			float maxStepOffset = this.GetMaxStepOffset(num);
			return Singleton<MathUtils>.Instance.Clamp(num5 / maxStepOffset, 0f, 1f);
		}

		// Token: 0x060413C8 RID: 267208 RVA: 0x010BC170 File Offset: 0x010BA370
		private float GetMaxStepOffset(int totalStepCount)
		{
			float num = 0.79999995f / (float)totalStepCount;
			float num2 = this.HorizontalOffsetOriX + 95f;
			float num3 = this.TotalCurveWidth * 1f;
			float num4 = this.ChapterUiItemList[this.ChapterUiItemList.Count - 1].GetWidth() / 2f;
			float num5 = Math.Max(0f, (this.ContentWidth - this.ViewportWidth) / 2f);
			float currentValue = (this.ViewportWidth / 2f - num4 + 80f + num5 - num2) / num3;
			float num6 = Singleton<MathUtils>.Instance.Clamp(currentValue, 0.1f, 1f);
			float num7 = (totalStepCount > 0) ? (num * 0.125f) : 0f;
			float num8 = num6 - num7;
			float currentValue2 = (float)totalStepCount - (num8 - 0.1f) / num;
			return Singleton<MathUtils>.Instance.Clamp(currentValue2, 0f, (float)totalStepCount);
		}

		// Token: 0x060413C9 RID: 267209 RVA: 0x010BC251 File Offset: 0x010BA451
		[NullableContext(2)]
		private void PlayScrollProgressTween(float startProgress, float endProgress, float duration, Action finishedCallBack = null)
		{
			this.ScrollProgressTween.PlayTween(startProgress, endProgress, duration, null);
			this.ScrollTweenCallback = finishedCallBack;
		}

		// Token: 0x060413CA RID: 267210 RVA: 0x010BC26C File Offset: 0x010BA46C
		private void BindScrollProgressTween()
		{
			this.ScrollProgressTween.BindStartTween(new Action(this.OnScrollProgressTweenStart));
			this.ScrollProgressTween.BindUpdateTween(new Action<float>(this.OnScrollProgressTweenUpdate));
			this.ScrollProgressTween.BindCompleteTween(new Action(this.OnScrollProgressTweenComplete));
		}

		// Token: 0x060413CB RID: 267211 RVA: 0x010BC2BE File Offset: 0x010BA4BE
		private void OnScrollProgressTweenStart()
		{
			this.IsScrollAnimating = true;
			this.ViewMask.SetMask("PinballMainScrollMoveTween", true);
		}

		// Token: 0x060413CC RID: 267212 RVA: 0x010BC2D8 File Offset: 0x010BA4D8
		private void OnScrollProgressTweenUpdate(float value)
		{
			this.DisplayScrollProgress = value;
			if (this.IsScrollAnimating)
			{
				this.SyncScrollProgress(value);
			}
			this.UpdateChapterItemsByCurve(this.DisplayScrollProgress);
		}

		// Token: 0x060413CD RID: 267213 RVA: 0x010BC2FC File Offset: 0x010BA4FC
		private void OnScrollProgressTweenComplete()
		{
			this.IsScrollAnimating = false;
			this.ViewMask.SetMask("PinballMainScrollMoveTween", false);
			this.IsInitialChapterScroll = true;
			Action scrollTweenCallback = this.ScrollTweenCallback;
			if (scrollTweenCallback == null)
			{
				return;
			}
			scrollTweenCallback();
		}

		// Token: 0x060413CE RID: 267214 RVA: 0x010BC330 File Offset: 0x010BA530
		private void SyncScrollProgress(float scrollProgress)
		{
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(0);
			if (scrollViewWithScrollbar == null)
			{
				return;
			}
			float num = Singleton<MathUtils>.Instance.Clamp(scrollProgress, 0f, 1f);
			float scrollProgress2 = scrollViewWithScrollbar.Horizontal ? (1f - num) : num;
			scrollViewWithScrollbar.SetScrollProgress(scrollProgress2);
		}

		// Token: 0x060413CF RID: 267215 RVA: 0x010BC37C File Offset: 0x010BA57C
		private void OnScrollValueChange(FVector2D progress)
		{
			if (this.ChapterScrollCurve == null || this.ChapterUiItemList.Count <= 0)
			{
				return;
			}
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(0);
			if (scrollViewWithScrollbar == null)
			{
				return;
			}
			float num = Singleton<MathUtils>.Instance.Clamp(scrollViewWithScrollbar.Horizontal ? progress.X : progress.Y, 0f, 1f);
			float num2 = 1f - num;
			this.DisplayScrollProgress = num2;
			this.UpdateChapterItemsByCurve(num2);
		}

		// Token: 0x060413D0 RID: 267216 RVA: 0x010BC3FC File Offset: 0x010BA5FC
		private void UpdateChapterItemsByCurve(float scrollProgress)
		{
			int totalStepCount = this.ChapterUiItemList.Count - 1;
			float maxStepOffset = this.GetMaxStepOffset(totalStepCount);
			float stepOffset = scrollProgress * Math.Max(maxStepOffset, 0f);
			float anchorOffsetX = this.ContentItem.GetAnchorOffsetX();
			for (int i = 0; i < this.ChapterUiItemList.Count; i++)
			{
				UUIItem item = this.ChapterUiItemList[i];
				this.SetChapterItemOffset(item, i, this.ChapterUiItemList.Count, stepOffset, anchorOffsetX);
			}
		}

		// Token: 0x060413D1 RID: 267217 RVA: 0x010BC479 File Offset: 0x010BA679
		private void OnBtnPermanentReward()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballPermanentRewardView, this.ActivityData, null);
		}

		// Token: 0x060413D2 RID: 267218 RVA: 0x010BC491 File Offset: 0x010BA691
		private void OnBtnLimitReward()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballLimitedRewardView, this.ActivityData, null);
		}

		// Token: 0x060413D3 RID: 267219 RVA: 0x010BC4A9 File Offset: 0x010BA6A9
		private void OnBtnShop()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballShopView, null, null);
		}

		// Token: 0x060413D4 RID: 267220 RVA: 0x010BC4BC File Offset: 0x010BA6BC
		private void OnBtnRole()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballRoleView, null, null);
		}

		// Token: 0x060413D5 RID: 267221 RVA: 0x010BC4D0 File Offset: 0x010BA6D0
		[NullableContext(2)]
		private void OnBtnPermanentRewardProgress(UUIText item)
		{
			ValueTuple<int, int> permanentTaskProgress = this.ActivityData.GetPermanentTaskProgress();
			int item2 = permanentTaskProgress.Item1;
			int item3 = permanentTaskProgress.Item2;
			if (item != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(item3);
				item.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
		}

		// Token: 0x060413D6 RID: 267222 RVA: 0x010BC52C File Offset: 0x010BA72C
		[NullableContext(2)]
		private void OnBtnLimitRewardProgress(UUIText item)
		{
			ValueTuple<int, int> timeLimitTaskProgress = this.ActivityData.GetTimeLimitTaskProgress();
			int item2 = timeLimitTaskProgress.Item1;
			int item3 = timeLimitTaskProgress.Item2;
			if (item != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(item3);
				item.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
		}

		// Token: 0x060413D7 RID: 267223 RVA: 0x010BC588 File Offset: 0x010BA788
		private bool OnShowPermanentRewardRedDot()
		{
			using (List<PinballTaskData>.Enumerator enumerator = this.ActivityData.GetPermanentTaskList().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsUnclaimed)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060413D8 RID: 267224 RVA: 0x010BC5E8 File Offset: 0x010BA7E8
		private bool OnShowLimitRewardRedDot()
		{
			if (!this.ActivityData.CheckIfInRewardTime())
			{
				return false;
			}
			using (List<PinballTaskData>.Enumerator enumerator = this.ActivityData.GetTimeLimitTaskList().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsUnclaimed)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060413D9 RID: 267225 RVA: 0x010BC658 File Offset: 0x010BA858
		private bool OnShowLimitRewardButton()
		{
			PinballActivityData activityData = this.ActivityData;
			return activityData != null && activityData.CheckIfInRewardTime();
		}

		// Token: 0x060413DA RID: 267226 RVA: 0x010BC66B File Offset: 0x010BA86B
		private bool OnShowShopRedDot()
		{
			PinballActivityData activityData = this.ActivityData;
			return activityData != null && activityData.IsShopEntranceHasRedDot();
		}

		// Token: 0x060413DB RID: 267227 RVA: 0x010BC67E File Offset: 0x010BA87E
		private void OnClickChapterBack(PinballChapterData chapterData, List<PinballLevelRecordData> levelDataList)
		{
			PinballActivityData activityData = this.ActivityData;
			if (activityData != null)
			{
				activityData.CheckToSetChapterRedDotAsRead(chapterData.ChapterId);
			}
			base.ViewModel.SetLevelDataList(levelDataList);
			base.ViewModel.SetChapterData(chapterData);
			base.OpenChildView("PinballLevelView");
		}

		// Token: 0x060413DC RID: 267228 RVA: 0x010BC6BB File Offset: 0x010BA8BB
		private void OnClickTowerBack(PinballChapterData chapterData, List<PinballLevelRecordData> levelDataList)
		{
			PinballActivityData activityData = this.ActivityData;
			if (activityData != null)
			{
				activityData.CheckToSetChapterRedDotAsRead(chapterData.ChapterId);
			}
			base.ViewModel.SetLevelDataList(levelDataList);
			base.ViewModel.SetChapterData(chapterData);
			base.OpenChildView("PinballTowerLevelView");
		}

		// Token: 0x060413DD RID: 267229 RVA: 0x010BC6F8 File Offset: 0x010BA8F8
		private void OnPointEnterChapterBack(string planetPath, string planetMaskPath, int chapterId)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				this.OnGamepadEnterChapter(chapterId);
			}
			if (this.OldPlanetPath == planetPath)
			{
				return;
			}
			Action<string> changePlanetTexture = base.ViewModel.ChangePlanetTexture;
			if (changePlanetTexture != null)
			{
				changePlanetTexture(planetPath);
			}
			Action<string> changePlanetMaskTexture = base.ViewModel.ChangePlanetMaskTexture;
			if (changePlanetMaskTexture != null)
			{
				changePlanetMaskTexture(planetMaskPath);
			}
			Action<string> changePlanetSwitchTexture = base.ViewModel.ChangePlanetSwitchTexture;
			if (changePlanetSwitchTexture != null)
			{
				changePlanetSwitchTexture(planetPath);
			}
			base.PlayRootSequence("Switch");
			this.OldPlanetPath = planetPath;
		}

		// Token: 0x060413DE RID: 267230 RVA: 0x010BC780 File Offset: 0x010BA980
		private void OnGamepadEnterChapter(int chapterId)
		{
			if (!this.IsInitialChapterScroll || this.ActivityData == null)
			{
				return;
			}
			int chapterIndexById = this.GetChapterIndexById(chapterId);
			if (chapterIndexById < 0 || chapterIndexById == this.LastGamepadChapterIndex)
			{
				return;
			}
			this.LastGamepadChapterIndex = chapterIndexById;
			float scrollProgressByIndex = this.GetScrollProgressByIndex(chapterIndexById);
			this.PlayScrollProgressTween(this.DisplayScrollProgress, scrollProgressByIndex, 0.3f, null);
		}

		// Token: 0x060413DF RID: 267231 RVA: 0x010BC7D8 File Offset: 0x010BA9D8
		private int GetChapterIndexById(int chapterId)
		{
			List<PinballChapterData> mainChapterList = this.ActivityData.GetMainChapterList();
			for (int i = 0; i < mainChapterList.Count; i++)
			{
				if (mainChapterList[i].ChapterId == chapterId)
				{
					return i;
				}
			}
			PinballChapterData towerChapterData = this.ActivityData.GetTowerChapterData();
			if (towerChapterData != null && towerChapterData.ChapterId == chapterId)
			{
				return this.ChapterUiItemList.Count - 1;
			}
			return -1;
		}

		// Token: 0x060413E0 RID: 267232 RVA: 0x010BC83A File Offset: 0x010BAA3A
		private void OnBtnDailyLevelClick()
		{
			base.OpenChildView("PinballDailyLevelView");
		}

		// Token: 0x060413E1 RID: 267233 RVA: 0x010BC847 File Offset: 0x010BAA47
		private void OnBtnNewTowerLevelClick()
		{
			this.PlayScrollProgressTween(this.DisplayScrollProgress, 1f, 1f, delegate
			{
				if (Singleton<Info>.Instance.IsInGamepad())
				{
					UUIItem chapterButtonUiItem = this.TowerChapterItem.GetChapterButtonUiItem();
					if (chapterButtonUiItem != null)
					{
						ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(chapterButtonUiItem, false, false, false);
					}
				}
				PinballChapterData towerChapterData = this.ActivityData.GetTowerChapterData();
				List<PinballLevelRecordData> list = new List<PinballLevelRecordData>();
				foreach (int levelId in towerChapterData.LevelIds)
				{
					list.Add(this.ActivityData.GetLevelData(levelId));
				}
				base.ViewModel.SetLevelDataList(list);
				base.ViewModel.SetChapterData(towerChapterData);
				PinballActivityData activityData = this.ActivityData;
				if (activityData != null)
				{
					activityData.CheckToSetChapterRedDotAsRead(towerChapterData.ChapterId);
				}
				base.OpenChildView("PinballTowerLevelView");
			});
		}

		// Token: 0x060413E2 RID: 267234 RVA: 0x010BC86B File Offset: 0x010BAA6B
		private void OnBtnBackClick()
		{
			base.BackToLastView();
		}

		// Token: 0x060413E3 RID: 267235 RVA: 0x010BC874 File Offset: 0x010BAA74
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams[0] != "ChapterBtn")
			{
				return null;
			}
			if (configParams.Length < 2)
			{
				return null;
			}
			int num;
			if (!int.TryParse(configParams[1], out num))
			{
				return null;
			}
			if (num < 0 || num >= this.ChapterItemList.Count)
			{
				return null;
			}
			PinballMainChapterItem pinballMainChapterItem = this.ChapterItemList[num];
			UUIItem uuiitem = (pinballMainChapterItem != null) ? pinballMainChapterItem.GetChapterButtonUiItem() : null;
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

		// Token: 0x04024831 RID: 149553
		private const int ITEM_OFFSET_X = 95;

		// Token: 0x04024832 RID: 149554
		private const int ITEM_OFFSET_Y = 100;

		// Token: 0x04024833 RID: 149555
		private const float CHAPTER_CURVE_PROGRESS_MIN = 0.1f;

		// Token: 0x04024834 RID: 149556
		private const float CHAPTER_CURVE_PROGRESS_MAX = 0.9f;

		// Token: 0x04024835 RID: 149557
		private const float CHAPTER_ITEM_X_SPACING_SCALE = 1f;

		// Token: 0x04024836 RID: 149558
		private const float CHAPTER_LAST_ITEM_X_GAP_RATIO = 1.125f;

		// Token: 0x04024837 RID: 149559
		private const float CHAPTER_INITIAL_SCROLL_TWEEN_DURATION = 1f;

		// Token: 0x04024838 RID: 149560
		private const float CHAPTER_GAMEPAD_SCROLL_TWEEN_DURATION = 0.3f;

		// Token: 0x04024839 RID: 149561
		private const int CHAPTER_LAST_ITEM_RIGHT_MARGIN = 80;

		// Token: 0x0402483A RID: 149562
		private const int AUTO_REFRESH_CHAPTER_ITEMS_INTERVAL = 1000;

		// Token: 0x0402483B RID: 149563
		[Nullable(2)]
		private PinballActivityData ActivityData;

		// Token: 0x0402483C RID: 149564
		private List<IPinballMainButtonConfig> ButtonConfigList = new List<IPinballMainButtonConfig>();

		// Token: 0x0402483D RID: 149565
		private readonly Dictionary<EPinballMainButtonFunctionType, PinballMainButtonItem> ButtonItems = new Dictionary<EPinballMainButtonFunctionType, PinballMainButtonItem>();

		// Token: 0x0402483E RID: 149566
		private readonly List<PinballMainChapterItem> ChapterItemList = new List<PinballMainChapterItem>();

		// Token: 0x0402483F RID: 149567
		private readonly Dictionary<IPinballChapterItem, PinballChapterData> NeedPlayTweenChapterItemMap = new Dictionary<IPinballChapterItem, PinballChapterData>();

		// Token: 0x04024840 RID: 149568
		[Nullable(2)]
		private PinballTowerChapterItem TowerChapterItem;

		// Token: 0x04024841 RID: 149569
		private readonly List<UUIItem> ChapterUiItemList = new List<UUIItem>();

		// Token: 0x04024842 RID: 149570
		[Nullable(2)]
		private UUIItem ContentItem;

		// Token: 0x04024843 RID: 149571
		private readonly Vector2D UiOffset = Vector2D.Create();

		// Token: 0x04024844 RID: 149572
		[Nullable(2)]
		private UCurveFloat ChapterScrollCurve;

		// Token: 0x04024845 RID: 149573
		[Nullable(2)]
		private UUIInturnAnimController ScrollAnimController;

		// Token: 0x04024846 RID: 149574
		private readonly LguiFloatTween ScrollProgressTween = new LguiFloatTween();

		// Token: 0x04024847 RID: 149575
		protected UiMask ViewMask = new UiMask();

		// Token: 0x04024848 RID: 149576
		[Nullable(2)]
		private Action ScrollTweenCallback;

		// Token: 0x04024849 RID: 149577
		private float ViewPortStretchLeft;

		// Token: 0x0402484A RID: 149578
		private float ContentWidth;

		// Token: 0x0402484B RID: 149579
		private float ContentHeight;

		// Token: 0x0402484C RID: 149580
		private float ViewportWidth;

		// Token: 0x0402484D RID: 149581
		private float TotalCurveWidth;

		// Token: 0x0402484E RID: 149582
		private float HorizontalOffsetOriX;

		// Token: 0x0402484F RID: 149583
		private float HorizontalOffsetOriY;

		// Token: 0x04024850 RID: 149584
		private bool IsInitialChapterScroll;

		// Token: 0x04024851 RID: 149585
		private bool IsScrollAnimating;

		// Token: 0x04024852 RID: 149586
		private float DisplayScrollProgress;

		// Token: 0x04024853 RID: 149587
		private int LastGamepadChapterIndex;

		// Token: 0x04024854 RID: 149588
		private int ScrollTickId;

		// Token: 0x04024855 RID: 149589
		private float AllChaptersRefreshTime;

		// Token: 0x04024856 RID: 149590
		private float LimitRewardButtonRefreshTime;

		// Token: 0x04024857 RID: 149591
		private string OldPlanetPath = "";

		// Token: 0x0200C613 RID: 50707
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403CF7D RID: 249725
			ChapterScroll,
			// Token: 0x0403CF7E RID: 249726
			ChapterItem,
			// Token: 0x0403CF7F RID: 249727
			TowerChapterItem,
			// Token: 0x0403CF80 RID: 249728
			PermanentRewardItem,
			// Token: 0x0403CF81 RID: 249729
			LimitRewardItem,
			// Token: 0x0403CF82 RID: 249730
			ShopItem,
			// Token: 0x0403CF83 RID: 249731
			RoleItem,
			// Token: 0x0403CF84 RID: 249732
			BtnDailyLevel,
			// Token: 0x0403CF85 RID: 249733
			DailyRewardProgressLayout,
			// Token: 0x0403CF86 RID: 249734
			DailyRewardCheckMarkItem,
			// Token: 0x0403CF87 RID: 249735
			TxtDailyRewardProgress,
			// Token: 0x0403CF88 RID: 249736
			DailyRewardItem,
			// Token: 0x0403CF89 RID: 249737
			BtnNewTowerLevel,
			// Token: 0x0403CF8A RID: 249738
			TxtDailyTitle
		}
	}
}
