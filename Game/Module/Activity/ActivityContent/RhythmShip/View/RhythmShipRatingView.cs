using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x02006505 RID: 25861
	[NullableContext(1)]
	[Nullable(0)]
	public class RhythmShipRatingView : UiViewBase
	{
		// Token: 0x06040B82 RID: 265090 RVA: 0x0109868D File Offset: 0x0109688D
		public RhythmShipRatingView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040B83 RID: 265091 RVA: 0x010986AC File Offset: 0x010968AC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUILoopScrollViewComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(10, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(8, new Action(this.OnClickLeftBtn)),
				new ValueTuple<int, Delegate>(9, new Action(this.OnClickRightBtn))
			};
		}

		// Token: 0x06040B84 RID: 265092 RVA: 0x010987F4 File Offset: 0x010969F4
		protected override UniTask OnBeforeStartAsync()
		{
			RhythmShipRatingView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RhythmShipRatingView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040B85 RID: 265093 RVA: 0x01098838 File Offset: 0x01096A38
		protected override void OnStart()
		{
			IRhythmShipRatingViewData rhythmShipRatingViewData = this.OpenParam as IRhythmShipRatingViewData;
			RhythmShipLevel? rhythmShipLevelById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipLevelById(rhythmShipRatingViewData.LevelId);
			if (rhythmShipLevelById == null)
			{
				return;
			}
			foreach (RhythmSubLevel rhythmSubLevel in (ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipSubLevelByLevelId(rhythmShipRatingViewData.LevelId) ?? new List<RhythmSubLevel>()))
			{
				this.SubLevelIdList.Add(rhythmSubLevel.Id);
			}
			this.CurrentShowSubLevelId = this.SubLevelIdList.IndexOf(rhythmShipRatingViewData.SubLevelId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), rhythmShipLevelById.Value.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), rhythmShipLevelById.Value.DesName, Array.Empty<object>());
			this.RefreshView();
		}

		// Token: 0x06040B86 RID: 265094 RVA: 0x01098934 File Offset: 0x01096B34
		private void OnClickLeftBtn()
		{
			if (this.CurrentShowSubLevelId <= 0)
			{
				return;
			}
			this.CurrentShowSubLevelId--;
			this.RefreshView();
		}

		// Token: 0x06040B87 RID: 265095 RVA: 0x01098954 File Offset: 0x01096B54
		private void OnClickRightBtn()
		{
			if (this.CurrentShowSubLevelId >= this.SubLevelIdList.Count - 1)
			{
				return;
			}
			this.CurrentShowSubLevelId++;
			this.RefreshView();
		}

		// Token: 0x06040B88 RID: 265096 RVA: 0x01098980 File Offset: 0x01096B80
		private void RefreshView()
		{
			int num = this.SubLevelIdList[this.CurrentShowSubLevelId];
			List<IRhythmShipSubLevelRatingData> subLevelRatingInfo;
			if (!this.LevelRatingInfoMap.TryGetValue(num, out subLevelRatingInfo))
			{
				subLevelRatingInfo = ModelBase<RhythmShipModel>.Instance.GetSubLevelRatingInfo(num);
				this.LevelRatingInfoMap[num] = subLevelRatingInfo;
			}
			if (subLevelRatingInfo.Count > 0)
			{
				LoopScrollView<RhythmShipRatingItem, IRhythmShipSubLevelRatingData> playerScroll = this.PlayerScroll;
				if (playerScroll != null)
				{
					playerScroll.RefreshByData(subLevelRatingInfo, false, null, false);
				}
				base.GetLoopScrollViewComponent(3).RootUIComp.Get().SetUIActive(true);
				base.GetItem(10).SetUIActive(false);
			}
			else
			{
				base.GetLoopScrollViewComponent(3).RootUIComp.Get().SetUIActive(false);
				base.GetItem(10).SetUIActive(true);
			}
			IRhythmShipSubLevelRatingData subLevelSelfRatingInfo = ModelBase<RhythmShipModel>.Instance.GetSubLevelSelfRatingInfo(num);
			if (subLevelSelfRatingInfo == null)
			{
				RhythmShipRatingItem selfItem = this.SelfItem;
				if (selfItem != null)
				{
					selfItem.RefreshItemNone();
				}
			}
			else
			{
				int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
				if (subLevelRatingInfo != null && subLevelRatingInfo.Count > 0)
				{
					foreach (IRhythmShipSubLevelRatingData rhythmShipSubLevelRatingData in subLevelRatingInfo)
					{
						int playerId = rhythmShipSubLevelRatingData.PlayerId;
						int? num2 = id;
						if (playerId == num2.GetValueOrDefault() & num2 != null)
						{
							subLevelSelfRatingInfo.RankingNumber = rhythmShipSubLevelRatingData.RankingNumber;
							break;
						}
					}
				}
				RhythmShipRatingItem selfItem2 = this.SelfItem;
				if (selfItem2 != null)
				{
					selfItem2.RefreshItemByData(subLevelSelfRatingInfo);
				}
			}
			RhythmSubLevel? rhythmShipSubLevelById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipSubLevelById(num);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), RhythmShipDefine.rhythmShipDifficultyText[(rhythmShipSubLevelById != null) ? rhythmShipSubLevelById.GetValueOrDefault().Difficulty : 1], Array.Empty<object>());
			this.RefreshBtnActivity();
		}

		// Token: 0x06040B89 RID: 265097 RVA: 0x01098B44 File Offset: 0x01096D44
		private void RefreshBtnActivity()
		{
			base.GetButton(9).RootUIComp.Get().SetUIActive(false);
			base.GetButton(8).RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x0402448C RID: 148620
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0402448D RID: 148621
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<RhythmShipRatingItem, IRhythmShipSubLevelRatingData> PlayerScroll;

		// Token: 0x0402448E RID: 148622
		[Nullable(2)]
		private RhythmShipRatingItem SelfItem;

		// Token: 0x0402448F RID: 148623
		private readonly List<int> SubLevelIdList = new List<int>();

		// Token: 0x04024490 RID: 148624
		private int CurrentShowSubLevelId;

		// Token: 0x04024491 RID: 148625
		private readonly Dictionary<int, List<IRhythmShipSubLevelRatingData>> LevelRatingInfoMap = new Dictionary<int, List<IRhythmShipSubLevelRatingData>>();
	}
}
