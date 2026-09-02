using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BossPiling.View.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View
{
	// Token: 0x02005EF6 RID: 24310
	[NullableContext(1)]
	[Nullable(0)]
	public class BossPilingLevelView : UiViewBase
	{
		// Token: 0x0603D126 RID: 250150 RVA: 0x00F820EA File Offset: 0x00F802EA
		public BossPilingLevelView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603D127 RID: 250151 RVA: 0x00F82100 File Offset: 0x00F80300
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
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
			*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.OnClickedConfirm));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(14, new Action(this.OnClickedBuff));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603D128 RID: 250152 RVA: 0x00F823A1 File Offset: 0x00F805A1
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		}

		// Token: 0x0603D129 RID: 250153 RVA: 0x00F823BF File Offset: 0x00F805BF
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		}

		// Token: 0x0603D12A RID: 250154 RVA: 0x00F823E0 File Offset: 0x00F805E0
		protected override UniTask OnBeforeStartAsync()
		{
			BossPilingLevelView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BossPilingLevelView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D12B RID: 250155 RVA: 0x00F82424 File Offset: 0x00F80624
		protected override void OnStart()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickedClose));
			this.CaptionItem.SetHelpBtnActive(false);
			bool flag = ModelBase<BossPilingModel>.Instance.CheckIsBossPiling();
			this.CaptionItem.SetHomeBtnShowState(!flag);
			this.BuffLayout = new GenericLayout<BossPilingBuffSimpleItem, int>(base.GetHorizontalLayout(4), new Func<BossPilingBuffSimpleItem>(this.CreateBuffItem), null, false, true);
			this.ScoreLayout = new GenericLayout<BossPilingScoreTabItem, BossPilingScoreTabInfo>(base.GetVerticalLayout(7), new Func<BossPilingScoreTabItem>(this.CreateScoreItem), null, false, true);
			this.RefreshPanel();
		}

		// Token: 0x0603D12C RID: 250156 RVA: 0x00F824C8 File Offset: 0x00F806C8
		protected void RefreshPanel()
		{
			BossPilingLevels? levelInfo = ConfigBase<BossPilingConfig>.Instance.GetLevelInfo(this.CurLevel);
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(levelInfo.Value.LevelName);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "BossPilingActivity_DungeonDetail01", new <>z__ReadOnlySingleElementList<object>(configTextByKey));
			List<int> data = new List<int>(levelInfo.Value.BuffShow());
			this.BuffLayout.RefreshByData(data, null, false);
			BossPilingLevelInfo levelInfo2 = ModelBase<BossPilingModel>.Instance.GetActivityData().GetLevelInfo(this.CurLevel);
			List<BossPilingScoreTabInfo> list = new List<BossPilingScoreTabInfo>();
			for (int i = 0; i < levelInfo.Value.Achievement().Length; i++)
			{
				int num = levelInfo.Value.Achievement()[i];
				BossPilingScoreTabInfo item = new BossPilingScoreTabInfo
				{
					BossHp = num,
					Quality = i + 1,
					IsAchieve = (levelInfo2.BossHp >= num)
				};
				list.Add(item);
			}
			this.ScoreLayout.RefreshByData(list, null, false);
			List<BossPilingLevelDescInfo> levelDataList = this.GetLevelDataList();
			this.LevelInfo1.Refresh(levelDataList[0], false, 0);
			this.LevelInfo2.Refresh(levelDataList[1], false, 1);
		}

		// Token: 0x0603D12D RID: 250157 RVA: 0x00F8260C File Offset: 0x00F8080C
		protected List<BossPilingLevelDescInfo> GetLevelDataList()
		{
			if (this.LevelDataList.Count > 0)
			{
				return this.LevelDataList;
			}
			BossPilingLevels value = ConfigBase<BossPilingConfig>.Instance.GetLevelInfo(this.CurLevel).Value;
			BossPilingLevelDescInfo item = new BossPilingLevelDescInfo
			{
				IsFirstLevel = true,
				LevelId = value.InstIds()[0],
				LevelMechanism = value.LevelMechanism1,
				MonsterDesc = value.LevelMonsterDesc1,
				LevelDesc = value.LevelDesc1
			};
			this.LevelDataList.Add(item);
			BossPilingLevelDescInfo item2 = new BossPilingLevelDescInfo
			{
				IsFirstLevel = false,
				LevelId = value.InstIds()[1],
				LevelMechanism = value.LevelMechanism2,
				MonsterDesc = value.LevelMonsterDesc2,
				LevelDesc = value.LevelDesc2
			};
			this.LevelDataList.Add(item2);
			return this.LevelDataList;
		}

		// Token: 0x0603D12E RID: 250158 RVA: 0x00F826EB File Offset: 0x00F808EB
		private BossPilingBuffSimpleItem CreateBuffItem()
		{
			return new BossPilingBuffSimpleItem();
		}

		// Token: 0x0603D12F RID: 250159 RVA: 0x00F826F2 File Offset: 0x00F808F2
		private BossPilingScoreTabItem CreateScoreItem()
		{
			return new BossPilingScoreTabItem();
		}

		// Token: 0x0603D130 RID: 250160 RVA: 0x00F826F9 File Offset: 0x00F808F9
		private void OnClickedClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603D131 RID: 250161 RVA: 0x00F82704 File Offset: 0x00F80904
		private void OnClickedView(bool isFirst)
		{
			List<BossPilingLevelDescInfo> levelDataList = this.GetLevelDataList();
			BossPilingLevelDetailInfo param = new BossPilingLevelDetailInfo
			{
				IsFirst = isFirst,
				LevelList = levelDataList
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.BossPilingLevelDescView, param, null);
		}

		// Token: 0x0603D132 RID: 250162 RVA: 0x00F82740 File Offset: 0x00F80940
		private void OnClickedConfirm()
		{
			ValueTuple<List<int>, List<int>> teamListResult = this.PanelTeam.GetTeamListResult();
			List<int> teamList = teamListResult.Item1;
			List<int> tagList = teamListResult.Item2;
			int num = 0;
			using (List<int>.Enumerator enumerator = teamList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current != 0)
					{
						num++;
					}
				}
			}
			if (num == 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_NoRole_Text", Array.Empty<object>());
				return;
			}
			if (num < 3)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BossRushRoleLess);
				confirmBoxDataNew.FunctionMap[2] = delegate()
				{
					ControllerBase<BossPilingController>.Instance.RequestChallenge(this.CurLevel, teamList, tagList, false);
				};
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			ControllerBase<BossPilingController>.Instance.RequestChallenge(this.CurLevel, teamList, tagList, false);
		}

		// Token: 0x0603D133 RID: 250163 RVA: 0x00F82830 File Offset: 0x00F80A30
		private void OnActivityClose(IReadOnlySet<int> closeActivities)
		{
			ModelBase<BossPilingModel>.Instance.CloseActivityView(closeActivities);
		}

		// Token: 0x0603D134 RID: 250164 RVA: 0x00F82840 File Offset: 0x00F80A40
		private void OnClickedBuff()
		{
			BossPilingBuffViewInfo param = new BossPilingBuffViewInfo
			{
				LevelId = this.CurLevel,
				InGame = false
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.BossPilingBuffView, param, null);
		}

		// Token: 0x04022419 RID: 140313
		protected int CurLevel;

		// Token: 0x0402241A RID: 140314
		protected List<BossPilingLevelDescInfo> LevelDataList = new List<BossPilingLevelDescInfo>();

		// Token: 0x0402241B RID: 140315
		protected PopupCaptionItem CaptionItem;

		// Token: 0x0402241C RID: 140316
		protected GenericLayout<BossPilingBuffSimpleItem, int> BuffLayout;

		// Token: 0x0402241D RID: 140317
		protected GenericLayout<BossPilingScoreTabItem, BossPilingScoreTabInfo> ScoreLayout;

		// Token: 0x0402241E RID: 140318
		protected BossPilingLevelDescItem LevelInfo1;

		// Token: 0x0402241F RID: 140319
		protected BossPilingLevelDescItem LevelInfo2;

		// Token: 0x04022420 RID: 140320
		protected BossPilingTeamPanel PanelTeam;

		// Token: 0x0200BEEB RID: 48875
		[NullableContext(0)]
		private enum EDefine
		{
			// Token: 0x0403AC1A RID: 240666
			CaptionItem,
			// Token: 0x0403AC1B RID: 240667
			TxtTitle,
			// Token: 0x0403AC1C RID: 240668
			SpriteFrameHover,
			// Token: 0x0403AC1D RID: 240669
			TxtBuffView,
			// Token: 0x0403AC1E RID: 240670
			PanelBuff,
			// Token: 0x0403AC1F RID: 240671
			BuffItem,
			// Token: 0x0403AC20 RID: 240672
			TxtTitleScore,
			// Token: 0x0403AC21 RID: 240673
			ContentScore,
			// Token: 0x0403AC22 RID: 240674
			TargetItem,
			// Token: 0x0403AC23 RID: 240675
			ScrollViewDefault,
			// Token: 0x0403AC24 RID: 240676
			ContentLevelInfo,
			// Token: 0x0403AC25 RID: 240677
			LevelInfo1,
			// Token: 0x0403AC26 RID: 240678
			PanelTeam,
			// Token: 0x0403AC27 RID: 240679
			BtnConfirm,
			// Token: 0x0403AC28 RID: 240680
			BtnBuff,
			// Token: 0x0403AC29 RID: 240681
			LevelInfo2
		}
	}
}
