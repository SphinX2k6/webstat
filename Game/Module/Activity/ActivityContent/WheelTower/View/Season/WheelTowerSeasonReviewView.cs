using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower.View.Season
{
	// Token: 0x02006245 RID: 25157
	[NullableContext(1)]
	[Nullable(0)]
	public class WheelTowerSeasonReviewView : UiViewBase
	{
		// Token: 0x0603F6D4 RID: 259796 RVA: 0x01042237 File Offset: 0x01040437
		public WheelTowerSeasonReviewView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603F6D5 RID: 259797 RVA: 0x01042240 File Offset: 0x01040440
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnConfirmBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnShareBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603F6D6 RID: 259798 RVA: 0x010423F4 File Offset: 0x010405F4
		protected override void OnStart()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("S");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.GetSeasonId());
			string item = defaultInterpolatedStringHandler.ToStringAndClear();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "NewTower_medalreview", new <>z__ReadOnlySingleElementList<object>(item));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "NewTower_SeasonMedal", new <>z__ReadOnlySingleElementList<object>(item));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "NewTower_Endlessmodereview", new <>z__ReadOnlySingleElementList<object>(item));
			this.MedalLayout = new GenericLayout<WheelTowerSeasonMedalItem, IWheelTowerMedalItemData>(base.GetHorizontalLayout(2), new Func<WheelTowerSeasonMedalItem>(this.CreateMedalItem), null, false, true);
			this.ScoreLayout = new GenericLayout<WheelTowerStageMedalItem, IWheelTowerMedalItemData>(base.GetHorizontalLayout(5), new Func<WheelTowerStageMedalItem>(this.CreateScoreMedalItem), null, false, true);
			this.RefreshMedalLayout();
			this.RefreshScoreLayout();
		}

		// Token: 0x0603F6D7 RID: 259799 RVA: 0x010424D0 File Offset: 0x010406D0
		private void RefreshMedalLayout()
		{
			int seasonId = this.GetSeasonId();
			List<IWheelTowerMedalGroupData> seasonMedalGroupList = ModelBase<WheelTowerModel>.Instance.GetSeasonMedalGroupList(seasonId, EWheelTowerMedalType.Season);
			List<IWheelTowerMedalItemData> list = new List<IWheelTowerMedalItemData>();
			for (int i = 0; i < seasonMedalGroupList.Count; i++)
			{
				list.Add(new WheelTowerMedalItemData
				{
					GroupId = seasonMedalGroupList[i].GroupId,
					IsLast = new bool?(i == seasonMedalGroupList.Count - 1),
					DisableInteract = new bool?(true),
					HideDetails = new bool?(true)
				});
			}
			GenericLayout<WheelTowerSeasonMedalItem, IWheelTowerMedalItemData> medalLayout = this.MedalLayout;
			if (medalLayout == null)
			{
				return;
			}
			medalLayout.RefreshByData(list, null, false);
		}

		// Token: 0x0603F6D8 RID: 259800 RVA: 0x01042568 File Offset: 0x01040768
		private void RefreshScoreLayout()
		{
			int seasonId = this.GetSeasonId();
			List<IWheelTowerMedalGroupData> seasonMedalGroupList = ModelBase<WheelTowerModel>.Instance.GetSeasonMedalGroupList(seasonId, EWheelTowerMedalType.Stage);
			List<IWheelTowerMedalItemData> list = new List<IWheelTowerMedalItemData>();
			for (int i = 0; i < seasonMedalGroupList.Count; i++)
			{
				list.Add(new WheelTowerMedalItemData
				{
					GroupId = seasonMedalGroupList[i].GroupId,
					IsLast = new bool?(i == seasonMedalGroupList.Count - 1),
					DisableInteract = new bool?(true)
				});
			}
			GenericLayout<WheelTowerStageMedalItem, IWheelTowerMedalItemData> scoreLayout = this.ScoreLayout;
			if (scoreLayout == null)
			{
				return;
			}
			scoreLayout.RefreshByData(list, null, false);
		}

		// Token: 0x0603F6D9 RID: 259801 RVA: 0x010425F2 File Offset: 0x010407F2
		private int GetSeasonId()
		{
			WheelTowerSeasonReviewViewData wheelTowerSeasonReviewViewData = this.OpenParam as WheelTowerSeasonReviewViewData;
			if (wheelTowerSeasonReviewViewData != null)
			{
				return wheelTowerSeasonReviewViewData.SeasonId;
			}
			WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return 0;
			}
			return activityData.SeasonId;
		}

		// Token: 0x0603F6DA RID: 259802 RVA: 0x0104261E File Offset: 0x0104081E
		private WheelTowerSeasonMedalItem CreateMedalItem()
		{
			return new WheelTowerSeasonMedalItem();
		}

		// Token: 0x0603F6DB RID: 259803 RVA: 0x01042625 File Offset: 0x01040825
		private WheelTowerStageMedalItem CreateScoreMedalItem()
		{
			return new WheelTowerStageMedalItem();
		}

		// Token: 0x0603F6DC RID: 259804 RVA: 0x0104262C File Offset: 0x0104082C
		private void OnConfirmBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603F6DD RID: 259805 RVA: 0x01042635 File Offset: 0x01040835
		private void OnShareBtnClick()
		{
			ControllerBase<WheelTowerController>.Instance.OpenSeasonMedalView(this.GetSeasonId(), true);
		}

		// Token: 0x04023987 RID: 145799
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<WheelTowerSeasonMedalItem, IWheelTowerMedalItemData> MedalLayout;

		// Token: 0x04023988 RID: 145800
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<WheelTowerStageMedalItem, IWheelTowerMedalItemData> ScoreLayout;
	}
}
