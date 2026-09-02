using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoleTrial
{
	// Token: 0x02006478 RID: 25720
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivitySubViewRoleTrial : ActivitySubViewBase
	{
		// Token: 0x17009E48 RID: 40520
		// (get) Token: 0x06040825 RID: 264229 RVA: 0x01088315 File Offset: 0x01086515
		protected new ActivityRoleTrialData ActivityBaseData
		{
			get
			{
				return this.ActivityBaseData as ActivityRoleTrialData;
			}
		}

		// Token: 0x17009E49 RID: 40521
		// (get) Token: 0x06040826 RID: 264230 RVA: 0x01088322 File Offset: 0x01086522
		// (set) Token: 0x06040827 RID: 264231 RVA: 0x0108832A File Offset: 0x0108652A
		private ActivityTitleTypeA TitleComponent { get; set; }

		// Token: 0x17009E4A RID: 40522
		// (get) Token: 0x06040828 RID: 264232 RVA: 0x01088333 File Offset: 0x01086533
		// (set) Token: 0x06040829 RID: 264233 RVA: 0x0108833B File Offset: 0x0108653B
		private ActivityDescriptionTypeB DescriptionComponent { get; set; }

		// Token: 0x17009E4B RID: 40523
		// (get) Token: 0x0604082A RID: 264234 RVA: 0x01088344 File Offset: 0x01086544
		// (set) Token: 0x0604082B RID: 264235 RVA: 0x0108834C File Offset: 0x0108654C
		private ActivityRoleDescribeComponent RoleDescribeComponent { get; set; }

		// Token: 0x17009E4C RID: 40524
		// (get) Token: 0x0604082C RID: 264236 RVA: 0x01088355 File Offset: 0x01086555
		// (set) Token: 0x0604082D RID: 264237 RVA: 0x0108835D File Offset: 0x0108655D
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private ActivityRewardList<ActivitySmallItemGrid, IItemGridData> RewardListComponent { [return: Nullable(new byte[]
		{
			2,
			1,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			1
		})] set; }

		// Token: 0x17009E4D RID: 40525
		// (get) Token: 0x0604082E RID: 264238 RVA: 0x01088366 File Offset: 0x01086566
		// (set) Token: 0x0604082F RID: 264239 RVA: 0x0108836E File Offset: 0x0108656E
		private ActivityFunctionalTypeA FunctionalComponent { get; set; }

		// Token: 0x17009E4E RID: 40526
		// (get) Token: 0x06040830 RID: 264240 RVA: 0x01088377 File Offset: 0x01086577
		// (set) Token: 0x06040831 RID: 264241 RVA: 0x0108837F File Offset: 0x0108657F
		protected int CurrentRoleId { get; set; }

		// Token: 0x17009E4F RID: 40527
		// (get) Token: 0x06040832 RID: 264242 RVA: 0x01088388 File Offset: 0x01086588
		// (set) Token: 0x06040833 RID: 264243 RVA: 0x01088390 File Offset: 0x01086590
		private LevelSequencePlayer LevelSequenceSwitchPlayer { get; set; }

		// Token: 0x06040834 RID: 264244 RVA: 0x0108839C File Offset: 0x0108659C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 27;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 7;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.ButtonRolePreviewClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.ButtonRewardClaimedClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(19, new Action(this.ButtonSkipGachaClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(23, new Action(this.ButtonRedPointLeftClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(24, new Action(this.ButtonRedPointRightClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(25, new Action(this.ButtonNewPointLeftClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(26, new Action(this.ButtonNewPointRightClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06040835 RID: 264245 RVA: 0x01088866 File Offset: 0x01086A66
		protected override void OnSetData()
		{
		}

		// Token: 0x06040836 RID: 264246 RVA: 0x01088868 File Offset: 0x01086A68
		protected override UniTask OnBeforeStartAsync()
		{
			ActivitySubViewRoleTrial.<OnBeforeStartAsync>d__41 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySubViewRoleTrial.<OnBeforeStartAsync>d__41>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040837 RID: 264247 RVA: 0x010888AC File Offset: 0x01086AAC
		protected override void OnStart()
		{
			Activity? localConfig = this.ActivityBaseData.LocalConfig;
			this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
			this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
			this.TitleComponent.SetSubTitleVisible(!StringUtils.IsEmpty((localConfig != null) ? localConfig.GetValueOrDefault().DescTheme : null));
			if (!string.IsNullOrEmpty((localConfig != null) ? localConfig.GetValueOrDefault().DescTheme : null))
			{
				this.TitleComponent.SetSubTitleByTextId(localConfig.Value.DescTheme, Array.Empty<string>());
			}
			this.RefreshTimerText();
			this.RewardListComponent.SetTitleByTextId("CollectActivity_reward");
			this.RewardListComponent.InitGridLayout(new Func<ActivitySmallItemGrid>(this.InitGridItem));
			this.FunctionalComponent.FunctionButton.SetFunction(new Action(this.ButtonInstanceEnterClick));
			List<int> roleIdList = this.ActivityBaseData.RoleIdList;
			if (roleIdList.Count == 0)
			{
				return;
			}
			int roleId = roleIdList[0];
			if (this.OpenParam != null)
			{
				roleId = (int)this.OpenParam;
			}
			else if (this.ActivityBaseData.CurrentRoleId != 0 && roleIdList.Contains(this.ActivityBaseData.CurrentRoleId))
			{
				roleId = this.ActivityBaseData.CurrentRoleId;
			}
			this.HasSelectedNewRole = this.ActivityBaseData.GetIsNewByRoleId(roleId);
			this.RefreshScrollWidth(roleIdList.Count);
			this.RoleScroll.RefreshByData(roleIdList, delegate
			{
				this.SelectRoleToggle(roleId);
				this.RefreshIndexPair();
				this.OnRoleScrollValueChange();
			}, false);
		}

		// Token: 0x06040838 RID: 264248 RVA: 0x01088A5C File Offset: 0x01086C5C
		private void RefreshScrollWidth(int roleCount)
		{
			ULGUIBehaviour scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(20);
			UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(2);
			float width = Math.Min((base.GetItem(21).GetWidth() + horizontalLayout.GetSpacing()) * (float)roleCount, this.ScrollDefaultWidth);
			scrollViewWithScrollbar.RootUIComp.Get().SetWidth(width);
		}

		// Token: 0x06040839 RID: 264249 RVA: 0x01088AB0 File Offset: 0x01086CB0
		protected override void OnBeforeShow()
		{
			this.RoleScroll.BindScrollValueChange(delegate(FVector2D progress)
			{
				this.OnRoleScrollValueChange();
			});
			if (!this.HasSelectedNewRole)
			{
				List<int> roleIdList = this.ActivityBaseData.RoleIdList;
				foreach (int num in roleIdList)
				{
					if (this.ActivityBaseData.GetIsNewByRoleId(num))
					{
						int index = roleIdList.IndexOf(num);
						UUIItem itemByIndex = this.RoleScroll.GetItemByIndex(index);
						GenericScrollViewNew<RoleItem, int> roleScroll = this.RoleScroll;
						if (roleScroll != null)
						{
							roleScroll.ScrollTo(itemByIndex, false);
						}
						this.SelectRoleToggle(num);
						break;
					}
				}
			}
			this.HasSelectedNewRole = false;
		}

		// Token: 0x0604083A RID: 264250 RVA: 0x01088B6C File Offset: 0x01086D6C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnStateChange));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnTrialRoleDataChanged, new Action<int>(this.OnStateChange));
		}

		// Token: 0x0604083B RID: 264251 RVA: 0x01088BA6 File Offset: 0x01086DA6
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnStateChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnTrialRoleDataChanged, new Action<int>(this.OnStateChange));
		}

		// Token: 0x0604083C RID: 264252 RVA: 0x01088BE0 File Offset: 0x01086DE0
		protected override void OnBeforeHide()
		{
			if (!this.ActivityBaseData.IsRoleInstanceOn())
			{
				this.ActivityBaseData.SetRoleTrialState(ERoleTrialFlowState.ActivityOff);
			}
		}

		// Token: 0x0604083D RID: 264253 RVA: 0x01088BFB File Offset: 0x01086DFB
		protected override void OnBeforeDestroy()
		{
			if (!this.ActivityBaseData.IsRoleInstanceOn())
			{
				this.ActivityBaseData.SetRoleTrialState(ERoleTrialFlowState.ActivityOff);
				this.SetRoleId(0);
			}
			LevelSequencePlayer levelSequenceSwitchPlayer = this.LevelSequenceSwitchPlayer;
			if (levelSequenceSwitchPlayer == null)
			{
				return;
			}
			levelSequenceSwitchPlayer.Clear();
		}

		// Token: 0x0604083E RID: 264254 RVA: 0x01088C30 File Offset: 0x01086E30
		protected override void OnRefreshView()
		{
			this.RefreshCondition();
			this.RefreshTimerText();
			this.ActivityBaseData.SetRoleTrialState(ERoleTrialFlowState.ActivityOn);
			if (this.ActivityBaseData.CurrentRoleId != this.CurrentRoleId)
			{
				this.SelectRoleToggle(this.ActivityBaseData.CurrentRoleId);
				return;
			}
			this.PlaySwitchSequence();
		}

		// Token: 0x0604083F RID: 264255 RVA: 0x01088C80 File Offset: 0x01086E80
		private void RefreshCondition()
		{
			bool flag = this.ActivityBaseData.IsUnLock();
			this.FunctionalComponent.SetPanelConditionVisible(!flag);
			this.FunctionalComponent.FunctionButton.SetUiActive(flag);
			if (!flag)
			{
				this.FunctionalComponent.SetPerformanceConditionLock(this.ActivityBaseData.ConditionGroupId, this.ActivityBaseData.Id);
			}
		}

		// Token: 0x06040840 RID: 264256 RVA: 0x01088CDD File Offset: 0x01086EDD
		protected override void OnTimer(float gap)
		{
			this.RefreshTimerText();
		}

		// Token: 0x06040841 RID: 264257 RVA: 0x01088CE8 File Offset: 0x01086EE8
		private void RefreshTimerText()
		{
			ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
			bool item = timeVisibleAndRemainTime.Item1;
			string item2 = timeVisibleAndRemainTime.Item2;
			this.TitleComponent.SetTimeTextVisible(item);
			if (item)
			{
				this.TitleComponent.SetTimeTextByText(item2);
			}
		}

		// Token: 0x06040842 RID: 264258 RVA: 0x01088D28 File Offset: 0x01086F28
		private void OnStateChange(int id)
		{
			if (id != this.ActivityBaseData.Id)
			{
				return;
			}
			List<int> roleIdList = this.ActivityBaseData.RoleIdList;
			this.RefreshScrollWidth(roleIdList.Count);
			int roleId = this.CurrentRoleId;
			bool needFallback = roleIdList.Count > 0 && !roleIdList.Contains(roleId);
			if (needFallback)
			{
				roleId = roleIdList[0];
			}
			this.RoleScroll.RefreshByData(roleIdList, delegate
			{
				this.MarkSelectRoleToggle(roleId, needFallback);
				this.RefreshRole(roleId);
				this.RefreshIndexPair();
				this.OnRoleScrollValueChange();
			}, false);
		}

		// Token: 0x06040843 RID: 264259 RVA: 0x01088DC4 File Offset: 0x01086FC4
		private void OnRoleScrollValueChange()
		{
			bool flag = false;
			bool flag2 = false;
			if (this.RedDotItemPair == null || !this.RedDotItemPair.Item1.IsValid() || !this.RedDotItemPair.Item2.IsValid())
			{
				this.RedDotButtonPair.Item1.SetUIActive(false);
				this.RedDotButtonPair.Item2.SetUIActive(false);
			}
			else
			{
				flag = (this.RoleScroll.IsItemFullyOutOfViewport(this.RedDotItemPair.Item1, this.SCROLL_TOLERANCE) == EOutOfBoundsType.OutOfBegin);
				flag2 = (this.RoleScroll.IsItemInViewport(this.RedDotItemPair.Item2, this.SCROLL_TOLERANCE) == EOutOfBoundsType.OutOfEnd);
				this.RedDotButtonPair.Item1.SetUIActive(flag);
				this.RedDotButtonPair.Item2.SetUIActive(flag2);
			}
			if (this.NewItemPair == null || !this.NewItemPair.Item1.IsValid() || !this.NewItemPair.Item2.IsValid())
			{
				this.NewButtonPair.Item1.SetUIActive(false);
				this.NewButtonPair.Item2.SetUIActive(false);
				return;
			}
			bool uiactive = this.RoleScroll.IsItemFullyOutOfViewport(this.NewItemPair.Item1, this.SCROLL_TOLERANCE) == EOutOfBoundsType.OutOfBegin && !flag;
			bool uiactive2 = this.RoleScroll.IsItemInViewport(this.NewItemPair.Item2, this.SCROLL_TOLERANCE) == EOutOfBoundsType.OutOfEnd && !flag2;
			this.NewButtonPair.Item1.SetUIActive(uiactive);
			this.NewButtonPair.Item2.SetUIActive(uiactive2);
		}

		// Token: 0x06040844 RID: 264260 RVA: 0x01088F48 File Offset: 0x01087148
		private void RefreshIndexPair()
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			List<int> roleIdList = this.ActivityBaseData.RoleIdList;
			for (int i = 0; i < roleIdList.Count; i++)
			{
				int roleId = roleIdList[i];
				if (this.ActivityBaseData.GetRewardStateByRoleId(roleId) == ERoleTrialRewardState.FinishedAndUnClaimed)
				{
					list.Add(i);
				}
				if (this.ActivityBaseData.GetIsNewByRoleId(roleId))
				{
					list2.Add(i);
				}
			}
			if (list.Count > 0)
			{
				UUIItem itemByIndex = this.RoleScroll.GetItemByIndex(list[0]);
				GenericScrollViewNew<RoleItem, int> roleScroll = this.RoleScroll;
				List<int> list3 = list;
				this.RedDotItemPair = new Tuple<UUIItem, UUIItem>(itemByIndex, roleScroll.GetItemByIndex(list3[list3.Count - 1]));
			}
			else
			{
				this.RedDotItemPair = null;
			}
			if (list2.Count > 0)
			{
				UUIItem itemByIndex2 = this.RoleScroll.GetItemByIndex(list2[0]);
				GenericScrollViewNew<RoleItem, int> roleScroll2 = this.RoleScroll;
				List<int> list4 = list2;
				this.NewItemPair = new Tuple<UUIItem, UUIItem>(itemByIndex2, roleScroll2.GetItemByIndex(list4[list4.Count - 1]));
				return;
			}
			this.NewItemPair = null;
		}

		// Token: 0x06040845 RID: 264261 RVA: 0x01089044 File Offset: 0x01087244
		private void MarkRoleIdAsOld(int roleId)
		{
			if (this.ActivityBaseData.GetIsNewByRoleId(roleId))
			{
				this.ActivityBaseData.SaveRemindTime(roleId);
				int index = this.ActivityBaseData.RoleIdList.IndexOf(roleId);
				RoleItem scrollItemByIndex = this.RoleScroll.GetScrollItemByIndex(index);
				if (scrollItemByIndex != null)
				{
					scrollItemByIndex.MarkAsOld();
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityBaseData.Id);
			}
		}

		// Token: 0x06040846 RID: 264262 RVA: 0x010890AF File Offset: 0x010872AF
		private void SetRoleId(int roleId)
		{
			this.CurrentRoleId = roleId;
			this.ActivityBaseData.CurrentRoleId = roleId;
		}

		// Token: 0x06040847 RID: 264263 RVA: 0x010890C4 File Offset: 0x010872C4
		private void RefreshRole(int roleId)
		{
			this.SetRoleId(roleId);
			RoleTrialInfo? roleTrialInfoConfigByRoleId = ConfigBase<ActivityRoleTrialConfig>.Instance.GetRoleTrialInfoConfigByRoleId(roleId);
			RoleTrialRoleConfig? roleTrialRoleConfigByRoleId = ConfigBase<ActivityRoleTrialConfig>.Instance.GetRoleTrialRoleConfigByRoleId(roleTrialInfoConfigByRoleId.Value.RoleId);
			string text = roleTrialRoleConfigByRoleId.Value.Introduction;
			if (StringUtils.IsEmpty(text))
			{
				text = this.ActivityBaseData.LocalConfig.Value.Desc;
			}
			bool flag = !StringUtils.IsEmpty(text);
			this.DescriptionComponent.SetContentVisible(flag);
			if (flag)
			{
				this.DescriptionComponent.SetContentByTextId(text, Array.Empty<string>());
			}
			this.RoleDescribeComponent.Update(roleTrialInfoConfigByRoleId.Value.RoleId);
			UUIItem roleItem = base.GetItem(22);
			USpineSkeletonAnimationComponent roleSpine = base.GetSpine(1);
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleTrialInfoConfigByRoleId.Value.RoleId);
			roleItem.SetUIActive(false);
			float[] param = roleTrialRoleConfigByRoleId.Value.SpineParam();
			base.SetSpineAssetByPath(roleTrialRoleConfigByRoleId.Value.FormationSpineAtlas, roleTrialRoleConfigByRoleId.Value.FormationSpineSkeletonData, roleSpine).Then(delegate()
			{
				roleItem.SetAnchorOffsetX(param[0]);
				roleItem.SetAnchorOffsetY(param[1]);
				roleItem.SetUIItemScale(new FVector(param[2], param[2], param[2]));
				roleItem.SetUIActive(true);
				roleSpine.SetAnimation(0, ESpineAnimation.Idle.ToString(), true);
			});
			UUITexture texture = base.GetTexture(12);
			UUITexture texture2 = base.GetTexture(13);
			if (!string.IsNullOrEmpty(roleTrialRoleConfigByRoleId.Value.RoleStand2))
			{
				base.SetTextureShowUntilLoaded(roleTrialRoleConfigByRoleId.Value.RoleStand2, texture, null);
				base.SetTextureShowUntilLoaded(roleTrialRoleConfigByRoleId.Value.RoleStand2, texture2, null);
			}
			this.RefreshUiConfigPerformance(roleTrialRoleConfigByRoleId.Value.UiConfigId);
			if (roleConfig != null)
			{
				int partyId = roleConfig.Value.PartyId;
				Influence? influenceConfig = ConfigBase<InfluenceConfig>.Instance.GetInfluenceConfig(partyId);
				if (!StringUtils.IsEmpty((influenceConfig != null) ? influenceConfig.GetValueOrDefault().Logo : null))
				{
					UUITexture texture3 = base.GetTexture(0);
					base.SetTextureByPath(influenceConfig.Value.Logo, texture3, null, null);
				}
			}
			UUIButtonComponent button = base.GetButton(19);
			bool flag2 = ModelBase<FunctionModel>.Instance.IsOpen(10009);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(roleTrialInfoConfigByRoleId.Value.GachaId > 0 && flag2);
			}
			this.RefreshReward(roleId);
		}

		// Token: 0x06040848 RID: 264264 RVA: 0x01089354 File Offset: 0x01087554
		private void PlaySwitchSequence()
		{
			if (this.LevelSequenceSwitchPlayer.GetCurrentSequence() == "Switch")
			{
				this.LevelSequenceSwitchPlayer.ReplaySequenceByKey("Switch");
				return;
			}
			this.LevelSequenceSwitchPlayer.PlayLevelSequenceByName("Switch", false, null, false);
		}

		// Token: 0x06040849 RID: 264265 RVA: 0x010893A4 File Offset: 0x010875A4
		private void RefreshUiConfigPerformance(int uiConfigId)
		{
			RoleTrialUiConfig? roleTrialUiConfigById = ConfigBase<ActivityRoleTrialConfig>.Instance.GetRoleTrialUiConfigById(uiConfigId);
			base.GetTexture(14).SetColor(FColor.FromHex(((roleTrialUiConfigById != null) ? roleTrialUiConfigById.GetValueOrDefault().Color1 : null) ?? ""));
			base.GetTexture(15).SetColor(FColor.FromHex(((roleTrialUiConfigById != null) ? roleTrialUiConfigById.GetValueOrDefault().Color2 : null) ?? ""));
			base.GetTexture(16).SetColor(FColor.FromHex(((roleTrialUiConfigById != null) ? roleTrialUiConfigById.GetValueOrDefault().Color3 : null) ?? ""));
			base.GetTexture(17).SetColor(FColor.FromHex(((roleTrialUiConfigById != null) ? roleTrialUiConfigById.GetValueOrDefault().Color4 : null) ?? ""));
			base.GetTexture(18).SetColor(FColor.FromHex(((roleTrialUiConfigById != null) ? roleTrialUiConfigById.GetValueOrDefault().Color5 : null) ?? ""));
		}

		// Token: 0x0604084A RID: 264266 RVA: 0x010894CC File Offset: 0x010876CC
		private void RefreshReward(int roleId)
		{
			List<IItemGridData> rewardDataByRoleId = this.ActivityBaseData.GetRewardDataByRoleId(roleId);
			this.RewardListComponent.SetItemLayoutVisible(rewardDataByRoleId != null && rewardDataByRoleId.Count > 0);
			ERoleTrialRewardState rewardStateByRoleId = this.ActivityBaseData.GetRewardStateByRoleId(roleId);
			if (rewardDataByRoleId != null && rewardDataByRoleId.Count > 0)
			{
				this.RewardListComponent.RefreshItemLayout(rewardDataByRoleId, null);
			}
			base.GetItem(9).SetUIActive(rewardStateByRoleId == ERoleTrialRewardState.FinishedAndClaimed);
			base.GetItem(10).SetUIActive(rewardStateByRoleId == ERoleTrialRewardState.InActive);
			base.GetButton(11).RootUIComp.Get().SetUIActive(rewardStateByRoleId == ERoleTrialRewardState.FinishedAndUnClaimed);
		}

		// Token: 0x0604084B RID: 264267 RVA: 0x01089568 File Offset: 0x01087768
		private void SelectRoleToggle(int roleId)
		{
			int num = this.ActivityBaseData.RoleIdList.IndexOf(roleId);
			if (num >= 0)
			{
				RoleItem scrollItemByIndex = this.RoleScroll.GetScrollItemByIndex(num);
				if (scrollItemByIndex == null)
				{
					return;
				}
				scrollItemByIndex.SetToggleState(true, true);
			}
		}

		// Token: 0x0604084C RID: 264268 RVA: 0x010895A4 File Offset: 0x010877A4
		private void MarkSelectRoleToggle(int roleId, bool fireEvent)
		{
			List<int> roleIdList = this.ActivityBaseData.RoleIdList;
			int num = roleIdList.IndexOf(roleId);
			for (int i = 0; i < roleIdList.Count; i++)
			{
				RoleItem scrollItemByIndex = this.RoleScroll.GetScrollItemByIndex(i);
				if (scrollItemByIndex != null)
				{
					bool flag = scrollItemByIndex.IsToggleChecked();
					if (i == num)
					{
						if (!flag)
						{
							scrollItemByIndex.SetToggleState(true, fireEvent);
						}
					}
					else if (flag)
					{
						scrollItemByIndex.SetToggleState(false, false);
					}
				}
			}
		}

		// Token: 0x0604084D RID: 264269 RVA: 0x0108960C File Offset: 0x0108780C
		[NullableContext(1)]
		private ActivitySmallItemGrid InitGridItem()
		{
			return new ActivitySmallItemGrid();
		}

		// Token: 0x0604084E RID: 264270 RVA: 0x01089613 File Offset: 0x01087813
		[NullableContext(1)]
		private RoleItem InitRoleItem()
		{
			return new RoleItem(this.ActivityBaseData)
			{
				ToggleCallBack = new Action<int, bool>(this.ToggleCallBack)
			};
		}

		// Token: 0x0604084F RID: 264271 RVA: 0x01089634 File Offset: 0x01087834
		private void ToggleCallBack(int roleId, bool state)
		{
			int index = this.ActivityBaseData.RoleIdList.IndexOf(this.CurrentRoleId);
			RoleItem scrollItemByIndex = this.RoleScroll.GetScrollItemByIndex(index);
			if (scrollItemByIndex != null)
			{
				scrollItemByIndex.SetToggleState(false, false);
			}
			this.RefreshRole(roleId);
			this.MarkRoleIdAsOld(roleId);
			this.RefreshIndexPair();
			this.OnRoleScrollValueChange();
			this.PlaySwitchSequence();
		}

		// Token: 0x06040850 RID: 264272 RVA: 0x01089694 File Offset: 0x01087894
		private void ButtonRolePreviewClick()
		{
			RoleTrialInfo? roleTrialInfoConfigByRoleId = ConfigBase<ActivityRoleTrialConfig>.Instance.GetRoleTrialInfoConfigByRoleId(this.CurrentRoleId);
			int selectRoleId = (roleTrialInfoConfigByRoleId != null) ? roleTrialInfoConfigByRoleId.GetValueOrDefault().TrialRoleId : 0;
			List<int> roleTrialIdList = this.ActivityBaseData.RoleTrialIdList;
			ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Preview, selectRoleId, roleTrialIdList, null, delegate(bool _, int _)
			{
				this.ActivityBaseData.SetRoleTrialState(ERoleTrialFlowState.RolePreview);
			});
		}

		// Token: 0x06040851 RID: 264273 RVA: 0x010896FD File Offset: 0x010878FD
		private void ButtonRewardClaimedClick()
		{
			ControllerBase<ActivityRoleTrialController>.Instance.RequestRoleInstanceReward(this.CurrentRoleId, this.ActivityBaseData.Id);
		}

		// Token: 0x06040852 RID: 264274 RVA: 0x0108971C File Offset: 0x0108791C
		private void ButtonInstanceEnterClick()
		{
			if (ControllerBase<RoleController>.Instance.IsInRoleTrial())
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleDungeonsLimit", Array.Empty<object>());
				return;
			}
			int? instanceIdByRoleId = this.ActivityBaseData.GetInstanceIdByRoleId(this.CurrentRoleId);
			if (instanceIdByRoleId == null)
			{
				return;
			}
			this.ActivityBaseData.SetRoleTrialState(ERoleTrialFlowState.RoleInstance);
			ControllerBase<ActivityRoleTrialController>.Instance.EnterRoleTrialDungeonDirectly(instanceIdByRoleId.Value, this.ActivityBaseData.Id, this.CurrentRoleId).ContinueWith(delegate(bool success)
			{
				if (!success)
				{
					this.ActivityBaseData.SetRoleTrialState(ERoleTrialFlowState.ActivityOn);
				}
			});
		}

		// Token: 0x06040853 RID: 264275 RVA: 0x010897A8 File Offset: 0x010879A8
		private void ButtonSkipGachaClick()
		{
			RoleTrialInfo? roleTrialInfoConfigByRoleId = ConfigBase<ActivityRoleTrialConfig>.Instance.GetRoleTrialInfoConfigByRoleId(this.CurrentRoleId);
			if (!ModelBase<GachaModel>.Instance.CheckGachaValidByGachaId(roleTrialInfoConfigByRoleId.Value.GachaId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_1400017_Text", Array.Empty<object>());
				return;
			}
			ControllerBase<GachaController>.Instance.OpenGachaView(roleTrialInfoConfigByRoleId.Value.GachaId);
		}

		// Token: 0x06040854 RID: 264276 RVA: 0x0108980F File Offset: 0x01087A0F
		private void ButtonRedPointLeftClick()
		{
			if (this.RedDotItemPair != null && this.RedDotItemPair.Item1.IsValid())
			{
				this.RoleScroll.ScrollTo(this.RedDotItemPair.Item1, false);
			}
		}

		// Token: 0x06040855 RID: 264277 RVA: 0x01089842 File Offset: 0x01087A42
		private void ButtonRedPointRightClick()
		{
			if (this.RedDotItemPair != null && this.RedDotItemPair.Item2.IsValid())
			{
				this.RoleScroll.ScrollToLeftByItem(this.RedDotItemPair.Item1);
			}
		}

		// Token: 0x06040856 RID: 264278 RVA: 0x01089874 File Offset: 0x01087A74
		private void ButtonNewPointLeftClick()
		{
			if (this.NewItemPair != null && this.NewItemPair.Item1.IsValid())
			{
				this.RoleScroll.ScrollTo(this.NewItemPair.Item1, false);
			}
		}

		// Token: 0x06040857 RID: 264279 RVA: 0x010898A7 File Offset: 0x01087AA7
		private void ButtonNewPointRightClick()
		{
			if (this.NewItemPair != null && this.NewItemPair.Item2.IsValid())
			{
				this.RoleScroll.ScrollToLeftByItem(this.NewItemPair.Item1);
			}
		}

		// Token: 0x040241B9 RID: 147897
		public float SCROLL_TOLERANCE = 0.1f;

		// Token: 0x040241BF RID: 147903
		[Nullable(1)]
		private GenericScrollViewNew<RoleItem, int> RoleScroll;

		// Token: 0x040241C0 RID: 147904
		protected float ScrollDefaultWidth;

		// Token: 0x040241C1 RID: 147905
		[Nullable(1)]
		private Tuple<UUIItem, UUIItem> RedDotItemPair;

		// Token: 0x040241C2 RID: 147906
		[Nullable(1)]
		private Tuple<UUIItem, UUIItem> NewItemPair;

		// Token: 0x040241C3 RID: 147907
		[Nullable(1)]
		private Tuple<UUIItem, UUIItem> RedDotButtonPair;

		// Token: 0x040241C4 RID: 147908
		[Nullable(1)]
		private Tuple<UUIItem, UUIItem> NewButtonPair;

		// Token: 0x040241C5 RID: 147909
		private bool HasSelectedNewRole;

		// Token: 0x0200C4CF RID: 50383
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C95F RID: 248159
			public const int TexInfluence = 0;

			// Token: 0x0403C960 RID: 248160
			public const int TexRoleSpine = 1;

			// Token: 0x0403C961 RID: 248161
			public const int PanelRole = 2;

			// Token: 0x0403C962 RID: 248162
			public const int TitleItem = 3;

			// Token: 0x0403C963 RID: 248163
			public const int DescriptionItem = 4;

			// Token: 0x0403C964 RID: 248164
			public const int RoleAttribute = 5;

			// Token: 0x0403C965 RID: 248165
			public const int BtnRolePreview = 6;

			// Token: 0x0403C966 RID: 248166
			public const int RewardListItem = 7;

			// Token: 0x0403C967 RID: 248167
			public const int FunctionArea = 8;

			// Token: 0x0403C968 RID: 248168
			public const int PanelDone = 9;

			// Token: 0x0403C969 RID: 248169
			public const int PanelOngoing = 10;

			// Token: 0x0403C96A RID: 248170
			public const int BtnReward = 11;

			// Token: 0x0403C96B RID: 248171
			public const int TexRoleBackground1 = 12;

			// Token: 0x0403C96C RID: 248172
			public const int TexRoleBackground2 = 13;

			// Token: 0x0403C96D RID: 248173
			public const int TexColor1 = 14;

			// Token: 0x0403C96E RID: 248174
			public const int TexColor2 = 15;

			// Token: 0x0403C96F RID: 248175
			public const int TexColor3 = 16;

			// Token: 0x0403C970 RID: 248176
			public const int TexColor4 = 17;

			// Token: 0x0403C971 RID: 248177
			public const int TexColor5 = 18;

			// Token: 0x0403C972 RID: 248178
			public const int SkipGachaButton = 19;

			// Token: 0x0403C973 RID: 248179
			public const int ScrollView = 20;

			// Token: 0x0403C974 RID: 248180
			public const int LayoutRoleItem = 21;

			// Token: 0x0403C975 RID: 248181
			public const int RoleSpineItem = 22;

			// Token: 0x0403C976 RID: 248182
			public const int BtnRedPointL = 23;

			// Token: 0x0403C977 RID: 248183
			public const int BtnRedPointR = 24;

			// Token: 0x0403C978 RID: 248184
			public const int BtnNewPointL = 25;

			// Token: 0x0403C979 RID: 248185
			public const int BtnNewPointR = 26;
		}
	}
}
