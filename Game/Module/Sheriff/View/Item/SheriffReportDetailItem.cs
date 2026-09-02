using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Item
{
	// Token: 0x02004FEE RID: 20462
	[NullableContext(2)]
	[Nullable(0)]
	public class SheriffReportDetailItem : UiTabViewBase
	{
		// Token: 0x06034C0D RID: 216077 RVA: 0x00D3CEFC File Offset: 0x00D3B0FC
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
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
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.OnClickBtnFunctionA));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034C0E RID: 216078 RVA: 0x00D3D17C File Offset: 0x00D3B37C
		protected override void OnBeforeShow()
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlayOrReplaySequenceByName("Start", false, null);
		}

		// Token: 0x06034C0F RID: 216079 RVA: 0x00D3D1A8 File Offset: 0x00D3B3A8
		protected override void OnStart()
		{
			ISheriffReportPopParam sheriffReportPopParam = this.ExtraParams as ISheriffReportPopParam;
			int criminalId = sheriffReportPopParam.CriminalId;
			this.CloseViewCallback = sheriffReportPopParam.CloseCallback;
			this.CriminalInfo = ModelBase<SheriffModel>.Instance.GetCriminalInfo(criminalId);
			this.AnomalyInfo = ModelBase<SheriffModel>.Instance.GetAnomalyInfo(this.CriminalInfo.AnomalyId);
			this.ConfirmBtn = new ButtonItem(base.GetItem(14));
			this.ConfirmBtn.SetFunction(new Action<int>(this.OnClickBtnConfirmB));
			this.RefreshPanelRole();
			this.RewardList = new LoopScrollView<CommonItemSmallItemGrid, TItem>(base.GetLoopScrollViewComponent(5), base.GetItem(6).GetOwner() as AUIBaseActor, new Func<CommonItemSmallItemGrid>(this.CreateGrid), false);
			this.ProgressScroll = new GenericScrollViewNew<SheriffReportDetailItemProgress, ISheriffProgressPopInfo>(base.GetScrollViewWithScrollbar(7), new Func<SheriffReportDetailItemProgress>(this.CreateProgressGrid), null, false, null);
			this.RefreshRewardList();
			this.RefreshProgressScroll();
		}

		// Token: 0x06034C10 RID: 216080 RVA: 0x00D3D290 File Offset: 0x00D3B490
		private void OnClickBtnFunctionA()
		{
			SheriffShowClueViewPopInfo param = new SheriffShowClueViewPopInfo
			{
				AnomalyId = this.AnomalyInfo.AnomalyId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SheriffShowClueViewPop, param, null);
		}

		// Token: 0x06034C11 RID: 216081 RVA: 0x00D3D2C8 File Offset: 0x00D3B4C8
		private void OnClickBtnConfirmB(int id)
		{
			if (!ModelBase<SheriffModel>.Instance.CheckGameplayActivated(this.AnomalyInfo.AnomalyId))
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnGotoAnomaly, this.AnomalyInfo.AnomalyId);
				Action closeViewCallback = this.CloseViewCallback;
				if (closeViewCallback == null)
				{
					return;
				}
				closeViewCallback();
				return;
			}
			else if (!ModelBase<SheriffModel>.Instance.CheckInBehaviorTreeRange(this.AnomalyInfo.AnomalyId))
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnGotoAnomaly, this.AnomalyInfo.AnomalyId);
				Action closeViewCallback2 = this.CloseViewCallback;
				if (closeViewCallback2 == null)
				{
					return;
				}
				closeViewCallback2();
				return;
			}
			else if (ModelBase<SheriffModel>.Instance.CheckInReasoningNode(this.AnomalyInfo.AnomalyId))
			{
				SheriffAnomaly value = ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigById(this.AnomalyInfo.AnomalyId).Value;
				ControllerBase<SheriffController>.Instance.OpenAnalysisClueView(value.QuestionId);
				Action closeViewCallback3 = this.CloseViewCallback;
				if (closeViewCallback3 == null)
				{
					return;
				}
				closeViewCallback3();
				return;
			}
			else
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnGotoAnomaly, this.AnomalyInfo.AnomalyId);
				Action closeViewCallback4 = this.CloseViewCallback;
				if (closeViewCallback4 == null)
				{
					return;
				}
				closeViewCallback4();
				return;
			}
		}

		// Token: 0x06034C12 RID: 216082 RVA: 0x00D3D3E0 File Offset: 0x00D3B5E0
		private void RefreshPanelRole()
		{
			ESheriffCriminalState state = this.CriminalInfo.State;
			bool flag = state == ESheriffCriminalState.Unconfirmed;
			SheriffIdentity value = ConfigBase<SheriffConfig>.Instance.GetIdentityConfigById(this.CriminalInfo.Identity).Value;
			bool flag2 = flag;
			bool uiactive = state == ESheriffCriminalState.Arrested;
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(flag2);
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 != null)
			{
				item2.SetUIActive(!flag2);
			}
			UUIItem item3 = base.GetItem(4);
			if (item3 != null)
			{
				item3.SetUIActive(uiactive);
			}
			if (flag2)
			{
				return;
			}
			UUIText text = base.GetText(3);
			if (text != null)
			{
				text.ShowTextNew(value.Name);
			}
			base.SetTextureByPath(value.IconReport, base.GetTexture(2), null, null);
		}

		// Token: 0x06034C13 RID: 216083 RVA: 0x00D3D498 File Offset: 0x00D3B698
		private void RefreshRewardList()
		{
			SheriffAnomaly value = ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigById(this.AnomalyInfo.AnomalyId).Value;
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(value.DropId);
			LoopScrollView<CommonItemSmallItemGrid, TItem> rewardList = this.RewardList;
			if (rewardList == null)
			{
				return;
			}
			rewardList.RefreshByData(dropPackagePreviewItemList, false, null, false);
		}

		// Token: 0x06034C14 RID: 216084 RVA: 0x00D3D4EC File Offset: 0x00D3B6EC
		private void RefreshProgressScroll()
		{
			int anomalyId = this.AnomalyInfo.AnomalyId;
			List<int> progressList = this.GetProgressList();
			List<ISheriffProgressPopInfo> list = new List<ISheriffProgressPopInfo>();
			foreach (int id in progressList)
			{
				SheriffProgress value = ConfigBase<SheriffConfig>.Instance.GetProgressConfigById(id).Value;
				SheriffProgressPopInfo item = new SheriffProgressPopInfo
				{
					Progress = value,
					NeedAnim = false
				};
				list.Add(item);
			}
			if (list.Count > 0)
			{
				list[list.Count - 1].NeedAnim = true;
			}
			GenericScrollViewNew<SheriffReportDetailItemProgress, ISheriffProgressPopInfo> progressScroll = this.ProgressScroll;
			if (progressScroll != null)
			{
				progressScroll.RefreshByData(list, new Action(this.OnAfterRefreshProgressScroll), true);
			}
			bool flag = this.AnomalyInfo.EndingTime != 0L;
			UUIItem item2 = base.GetItem(15);
			if (item2 != null)
			{
				item2.SetUIActive(flag);
			}
			UUIItem item3 = base.GetItem(9);
			if (item3 != null)
			{
				item3.SetUIActive(!flag);
			}
			UUIItem item4 = base.GetItem(11);
			if (item4 != null)
			{
				item4.SetUIActive(!flag);
			}
			if (!flag)
			{
				int type = ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigById(anomalyId).Value.Type;
				UUIText text = base.GetText(12);
				if (text != null)
				{
					text.SetUIActive(type > 0);
				}
				List<int> clueListByAnomalyId = ModelBase<SheriffModel>.Instance.GetClueListByAnomalyId(anomalyId);
				int count = this.AnomalyInfo.ClueIds.Count;
				bool uiactive = count > 0 && type > 0;
				UUIButtonComponent button = base.GetButton(13);
				if (button != null)
				{
					button.RootUIComp.Get().SetUIActive(uiactive);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), "Sheriff_EventProgress_9", new <>z__ReadOnlyArray<object>(new object[]
				{
					Math.Min(count, clueListByAnomalyId.Count),
					clueListByAnomalyId.Count
				}));
				FColor changeColor = base.GetText(12).changeColor;
				UUIText text2 = base.GetText(12);
				if (text2 != null)
				{
					bool bUseChangeColor = count != clueListByAnomalyId.Count;
					FColor? fcolor = new FColor?(changeColor);
					text2.SetChangeColor(bUseChangeColor, fcolor);
				}
				this.RefreshTargetPanel();
			}
		}

		// Token: 0x06034C15 RID: 216085 RVA: 0x00D3D724 File Offset: 0x00D3B924
		[NullableContext(1)]
		private List<int> GetProgressList()
		{
			int anomalyId = this.AnomalyInfo.AnomalyId;
			IEnumerable<SheriffProgress> progressConfigListByAnomalyId = ConfigBase<SheriffConfig>.Instance.GetProgressConfigListByAnomalyId(anomalyId);
			List<int> list = new List<int>();
			foreach (SheriffProgress sheriffProgress in progressConfigListByAnomalyId)
			{
				if (sheriffProgress.ProgressType == 1)
				{
					list.Add(sheriffProgress.Id);
				}
			}
			list.AddRange(this.AnomalyInfo.ProgressIds);
			return list;
		}

		// Token: 0x06034C16 RID: 216086 RVA: 0x00D3D7AC File Offset: 0x00D3B9AC
		protected void RefreshTargetPanel()
		{
			if (!ModelBase<SheriffModel>.Instance.CheckGameplayActivated(this.AnomalyInfo.AnomalyId))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "Sheriff_EventProgress_6", Array.Empty<object>());
				ButtonItem confirmBtn = this.ConfirmBtn;
				if (confirmBtn == null)
				{
					return;
				}
				confirmBtn.SetShowText("Sheriff_EventProgress_10");
				return;
			}
			else if (!ModelBase<SheriffModel>.Instance.CheckInBehaviorTreeRange(this.AnomalyInfo.AnomalyId))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "Sheriff_EventProgress_7", Array.Empty<object>());
				ButtonItem confirmBtn2 = this.ConfirmBtn;
				if (confirmBtn2 == null)
				{
					return;
				}
				confirmBtn2.SetShowText("Sheriff_EventProgress_10");
				return;
			}
			else if (ModelBase<SheriffModel>.Instance.CheckInReasoningNode(this.AnomalyInfo.AnomalyId))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "Sheriff_EventProgress_8", Array.Empty<object>());
				ButtonItem confirmBtn3 = this.ConfirmBtn;
				if (confirmBtn3 == null)
				{
					return;
				}
				confirmBtn3.SetShowText("Sheriff_EventProgress_11");
				return;
			}
			else
			{
				string currentBehaviorTreeNodeText = ModelBase<SheriffModel>.Instance.GetCurrentBehaviorTreeNodeText(this.AnomalyInfo.AnomalyId);
				if (StringUtils.IsBlank(currentBehaviorTreeNodeText))
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "Sheriff_EventProgress_7", Array.Empty<object>());
				}
				else
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), currentBehaviorTreeNodeText, Array.Empty<object>());
				}
				ButtonItem confirmBtn4 = this.ConfirmBtn;
				if (confirmBtn4 == null)
				{
					return;
				}
				confirmBtn4.SetShowText("Sheriff_EventProgress_10");
				return;
			}
		}

		// Token: 0x06034C17 RID: 216087 RVA: 0x00D3D8FD File Offset: 0x00D3BAFD
		[NullableContext(1)]
		private CommonItemSmallItemGrid CreateGrid()
		{
			return new CommonItemSmallItemGrid
			{
				ShowReceivedCallBack = new Func<TItem, bool>(this.CheckLevelFinished)
			};
		}

		// Token: 0x06034C18 RID: 216088 RVA: 0x00D3D916 File Offset: 0x00D3BB16
		private bool CheckLevelFinished(TItem data)
		{
			return this.AnomalyInfo.EndingTime != 0L;
		}

		// Token: 0x06034C19 RID: 216089 RVA: 0x00D3D927 File Offset: 0x00D3BB27
		[NullableContext(1)]
		private SheriffReportDetailItemProgress CreateProgressGrid()
		{
			return new SheriffReportDetailItemProgress();
		}

		// Token: 0x06034C1A RID: 216090 RVA: 0x00D3D92E File Offset: 0x00D3BB2E
		private void OnAfterRefreshProgressScroll()
		{
			TimerSystem.GameplayTimeInstance.Next(delegate(float _)
			{
				this.OnLateUpdate();
			}, null, null);
		}

		// Token: 0x06034C1B RID: 216091 RVA: 0x00D3D949 File Offset: 0x00D3BB49
		protected void OnLateUpdate()
		{
			base.GetScrollViewWithScrollbar(7).OnLateUpdate.Bind(delegate(float _)
			{
				base.GetScrollViewWithScrollbar(7).ScrollToEnd();
				base.GetScrollViewWithScrollbar(7).OnLateUpdate.Unbind();
			});
		}

		// Token: 0x0401E654 RID: 124500
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private LoopScrollView<CommonItemSmallItemGrid, TItem> RewardList;

		// Token: 0x0401E655 RID: 124501
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<SheriffReportDetailItemProgress, ISheriffProgressPopInfo> ProgressScroll;

		// Token: 0x0401E656 RID: 124502
		protected ButtonItem ConfirmBtn;

		// Token: 0x0401E657 RID: 124503
		protected SheriffAnomalyInfo AnomalyInfo;

		// Token: 0x0401E658 RID: 124504
		protected SheriffCriminalInfo CriminalInfo;

		// Token: 0x0401E659 RID: 124505
		protected Action CloseViewCallback;

		// Token: 0x0200AFCB RID: 45003
		[NullableContext(0)]
		private enum EDefine
		{
			// Token: 0x040368CE RID: 223438
			PanelLock,
			// Token: 0x040368CF RID: 223439
			PanelUnlock,
			// Token: 0x040368D0 RID: 223440
			TexRole,
			// Token: 0x040368D1 RID: 223441
			TxtName,
			// Token: 0x040368D2 RID: 223442
			PanelDone,
			// Token: 0x040368D3 RID: 223443
			SvInfo,
			// Token: 0x040368D4 RID: 223444
			UiItemItemBaseB,
			// Token: 0x040368D5 RID: 223445
			SvInfoAlt,
			// Token: 0x040368D6 RID: 223446
			PanelInfo,
			// Token: 0x040368D7 RID: 223447
			PanelMission,
			// Token: 0x040368D8 RID: 223448
			TxtMission,
			// Token: 0x040368D9 RID: 223449
			PanelButton,
			// Token: 0x040368DA RID: 223450
			TxtNum,
			// Token: 0x040368DB RID: 223451
			BtnFunctionA,
			// Token: 0x040368DC RID: 223452
			BtnConfirmB,
			// Token: 0x040368DD RID: 223453
			PanelDoneAlt
		}
	}
}
