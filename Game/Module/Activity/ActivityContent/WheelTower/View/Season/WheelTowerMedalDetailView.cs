using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower.View.Season
{
	// Token: 0x0200622C RID: 25132
	[NullableContext(1)]
	[Nullable(0)]
	public class WheelTowerMedalDetailView : UiViewBase
	{
		// Token: 0x0603F662 RID: 259682 RVA: 0x0103F417 File Offset: 0x0103D617
		public WheelTowerMedalDetailView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603F663 RID: 259683 RVA: 0x0103F420 File Offset: 0x0103D620
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.OnLookBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(14, new Action(this.OnSkipBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603F664 RID: 259684 RVA: 0x0103F6C4 File Offset: 0x0103D8C4
		protected override UniTask OnBeforeStartAsync()
		{
			WheelTowerMedalDetailView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerMedalDetailView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F665 RID: 259685 RVA: 0x0103F708 File Offset: 0x0103D908
		private void RefreshTitle(IWheelTowerMedalGroupData groupData)
		{
			int id = (groupData.CurrentMedalId != 0) ? groupData.CurrentMedalId : groupData.NextMedalId;
			NewTowerMedal? medalConfigById = ConfigBase<WheelTowerConfig>.Instance.GetMedalConfigById(id);
			if (medalConfigById == null)
			{
				return;
			}
			UUIText text = base.GetText(3);
			if (groupData.CycleId == 0)
			{
				LguiUtil instance = Singleton<LguiUtil>.Instance;
				UUIText uiText = text;
				string name = medalConfigById.Value.Name;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("S");
				defaultInterpolatedStringHandler.AppendFormatted<int>(groupData.SeasonId);
				instance.SetLocalTextNew(uiText, name, new <>z__ReadOnlySingleElementList<object>(defaultInterpolatedStringHandler.ToStringAndClear()));
			}
			else if (text != null)
			{
				text.ShowTextNew(medalConfigById.Value.Name);
			}
			UUIText text2 = base.GetText(4);
			if (text2 == null)
			{
				return;
			}
			text2.ShowTextNew(medalConfigById.Value.Desc);
		}

		// Token: 0x0603F666 RID: 259686 RVA: 0x0103F7D4 File Offset: 0x0103D9D4
		private void RefreshDetail(IWheelTowerMedalGroupData groupData)
		{
			bool flag = groupData.CycleId == 0;
			bool flag2 = this.IsCurrentSeason(groupData);
			long completeTime = groupData.CompleteTime;
			if (completeTime != 0L)
			{
				UUIText text = base.GetText(8);
				if (text != null)
				{
					text.SetText(Singleton<TimeUtil>.Instance.DateFormat4String((double)completeTime), true);
				}
			}
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(completeTime != 0L);
			}
			bool flag3 = flag;
			bool flag4 = !flag;
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(flag3);
			}
			UUIItem item3 = base.GetItem(11);
			if (item3 != null)
			{
				item3.SetUIActive(flag4);
			}
			UUIItem item4 = base.GetItem(9);
			if (item4 != null)
			{
				item4.SetUIActive(false);
			}
			if (!flag3)
			{
				if (flag4)
				{
					int progress = groupData.Progress;
					string newText;
					if (!flag2)
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
						defaultInterpolatedStringHandler.AppendLiteral("<color=#fff2bc>");
						defaultInterpolatedStringHandler.AppendFormatted<int>(progress);
						defaultInterpolatedStringHandler.AppendLiteral("</color>");
						newText = defaultInterpolatedStringHandler.ToStringAndClear();
					}
					else
					{
						string text2;
						if (!groupData.IsMaxLevel)
						{
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 2);
							defaultInterpolatedStringHandler.AppendLiteral("<color=#fff2bc>");
							defaultInterpolatedStringHandler.AppendFormatted<int>(progress);
							defaultInterpolatedStringHandler.AppendLiteral("</color>/");
							defaultInterpolatedStringHandler.AppendFormatted<int>(groupData.CurrentTarget);
							text2 = defaultInterpolatedStringHandler.ToStringAndClear();
						}
						else
						{
							text2 = progress.ToString();
						}
						newText = text2;
					}
					UUIText text3 = base.GetText(12);
					if (text3 == null)
					{
						return;
					}
					text3.SetText(newText, true);
				}
				return;
			}
			int progress2 = groupData.Progress;
			int currentTarget = groupData.CurrentTarget;
			string newText2;
			if (!flag2)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
				defaultInterpolatedStringHandler.AppendLiteral("<color=#fff2bc>");
				defaultInterpolatedStringHandler.AppendFormatted<int>(progress2);
				defaultInterpolatedStringHandler.AppendLiteral("</color>");
				newText2 = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else
			{
				string text4;
				if (progress2 < currentTarget)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 2);
					defaultInterpolatedStringHandler.AppendLiteral("<color=#fff2bc>");
					defaultInterpolatedStringHandler.AppendFormatted<int>(progress2);
					defaultInterpolatedStringHandler.AppendLiteral("</color>/");
					defaultInterpolatedStringHandler.AppendFormatted<int>(currentTarget);
					text4 = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				else
				{
					text4 = progress2.ToString();
				}
				newText2 = text4;
			}
			UUIText text5 = base.GetText(6);
			if (text5 == null)
			{
				return;
			}
			text5.SetText(newText2, true);
		}

		// Token: 0x0603F667 RID: 259687 RVA: 0x0103F9D4 File Offset: 0x0103DBD4
		private void RefreshButtons(IWheelTowerMedalGroupData groupData)
		{
			bool uiactive = this.IsCurrentSeason(groupData);
			UUIButtonComponent button = base.GetButton(13);
			if (button != null)
			{
				UUIItem uuiitem = button.RootUIComp.Get();
				if (uuiitem != null)
				{
					uuiitem.SetUIActive(uiactive);
				}
			}
			UUIButtonComponent button2 = base.GetButton(14);
			if (button2 == null)
			{
				return;
			}
			UUIItem uuiitem2 = button2.RootUIComp.Get();
			if (uuiitem2 == null)
			{
				return;
			}
			uuiitem2.SetUIActive(this.IsCurrentMedal(groupData) && !groupData.IsMaxLevel);
		}

		// Token: 0x0603F668 RID: 259688 RVA: 0x0103FA4C File Offset: 0x0103DC4C
		private UniTask CreateMedalItem(IWheelTowerMedalGroupData groupData)
		{
			WheelTowerMedalDetailView.<CreateMedalItem>d__9 <CreateMedalItem>d__;
			<CreateMedalItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateMedalItem>d__.<>4__this = this;
			<CreateMedalItem>d__.<>1__state = -1;
			<CreateMedalItem>d__.<>t__builder.Start<WheelTowerMedalDetailView.<CreateMedalItem>d__9>(ref <CreateMedalItem>d__);
			return <CreateMedalItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603F669 RID: 259689 RVA: 0x0103FA90 File Offset: 0x0103DC90
		private bool IsCurrentSeason(IWheelTowerMedalGroupData groupData)
		{
			WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
			int num = (activityData != null) ? activityData.SeasonId : 0;
			return groupData.SeasonId == num;
		}

		// Token: 0x0603F66A RID: 259690 RVA: 0x0103FAC0 File Offset: 0x0103DCC0
		private bool IsCurrentCycle(IWheelTowerMedalGroupData groupData)
		{
			int cycleId = groupData.CycleId;
			WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
			int? num = (activityData != null) ? new int?(activityData.CycleId) : null;
			return cycleId == num.GetValueOrDefault() & num != null;
		}

		// Token: 0x0603F66B RID: 259691 RVA: 0x0103FB08 File Offset: 0x0103DD08
		private bool IsCurrentMedal(IWheelTowerMedalGroupData groupData)
		{
			if (groupData.CycleId == 0)
			{
				return this.IsCurrentSeason(groupData);
			}
			return this.IsCurrentSeason(groupData) && this.IsCurrentCycle(groupData);
		}

		// Token: 0x0603F66C RID: 259692 RVA: 0x0103FB2C File Offset: 0x0103DD2C
		private void ReportEnterMedalEvent(IWheelTowerMedalGroupData groupData)
		{
			NewTowerClickMedalEvent newTowerClickMedalEvent = new NewTowerClickMedalEvent();
			newTowerClickMedalEvent.i_activity_id = ModelBase<WheelTowerModel>.Instance.ActivityData.Id;
			newTowerClickMedalEvent.i_season_id = groupData.SeasonId;
			newTowerClickMedalEvent.i_item_id = ((groupData.CurrentMedalId != 0) ? groupData.CurrentMedalId : groupData.NextMedalId);
			ControllerBase<LogReportController>.Instance.LogReport(newTowerClickMedalEvent);
		}

		// Token: 0x0603F66D RID: 259693 RVA: 0x0103FB88 File Offset: 0x0103DD88
		private void ReportMedalSkipEvent(IWheelTowerMedalGroupData groupData)
		{
			NewTowerClickMedalSkipEvent newTowerClickMedalSkipEvent = new NewTowerClickMedalSkipEvent();
			newTowerClickMedalSkipEvent.i_activity_id = ModelBase<WheelTowerModel>.Instance.ActivityData.Id;
			newTowerClickMedalSkipEvent.i_season_id = groupData.SeasonId;
			newTowerClickMedalSkipEvent.i_item_id = ((groupData.CurrentMedalId != 0) ? groupData.CurrentMedalId : groupData.NextMedalId);
			ControllerBase<LogReportController>.Instance.LogReport(newTowerClickMedalSkipEvent);
		}

		// Token: 0x0603F66E RID: 259694 RVA: 0x0103FBE3 File Offset: 0x0103DDE3
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603F66F RID: 259695 RVA: 0x0103FBEC File Offset: 0x0103DDEC
		private void OnLookBtnClick()
		{
			WheelTowerMedalDetailViewData wheelTowerMedalDetailViewData = this.OpenParam as WheelTowerMedalDetailViewData;
			if (wheelTowerMedalDetailViewData == null)
			{
				return;
			}
			WheelTowerMedalRuleViewData param = new WheelTowerMedalRuleViewData
			{
				GroupId = wheelTowerMedalDetailViewData.GroupId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerMedalRuleView, param, null);
		}

		// Token: 0x0603F670 RID: 259696 RVA: 0x0103FC2C File Offset: 0x0103DE2C
		private void OnSkipBtnClick()
		{
			WheelTowerMedalDetailViewData wheelTowerMedalDetailViewData = this.OpenParam as WheelTowerMedalDetailViewData;
			if (wheelTowerMedalDetailViewData == null)
			{
				return;
			}
			IWheelTowerMedalGroupData medalGroupData = ModelBase<WheelTowerModel>.Instance.GetMedalGroupData(wheelTowerMedalDetailViewData.GroupId);
			if (medalGroupData == null)
			{
				return;
			}
			if (medalGroupData.CycleId == 0)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerSeasonRewardView, null, null);
			}
			else
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerPrepareView, null, null);
			}
			this.ReportMedalSkipEvent(medalGroupData);
			base.CloseMe(null);
		}

		// Token: 0x04023905 RID: 145669
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04023906 RID: 145670
		[Nullable(2)]
		private WheelTowerSeasonMedalDetailItem SeasonMedalItem;

		// Token: 0x04023907 RID: 145671
		[Nullable(2)]
		private WheelTowerStageMedalDetailItem StageMedalItem;
	}
}
