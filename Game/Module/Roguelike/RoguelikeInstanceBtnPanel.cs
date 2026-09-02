using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.RougeActivity;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005188 RID: 20872
	public class RoguelikeInstanceBtnPanel : UiPanelBase
	{
		// Token: 0x06035B34 RID: 219956 RVA: 0x00D7DBB0 File Offset: 0x00D7BDB0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnBtnShopClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnSkillTreeClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035B35 RID: 219957 RVA: 0x00D7DD20 File Offset: 0x00D7BF20
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeInstanceBtnPanel.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeInstanceBtnPanel.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035B36 RID: 219958 RVA: 0x00D7DD5B File Offset: 0x00D7BF5B
		protected override void OnStart()
		{
			this.Refresh();
		}

		// Token: 0x06035B37 RID: 219959 RVA: 0x00D7DD63 File Offset: 0x00D7BF63
		protected override void OnBeforeShow()
		{
			this.BindRedDot();
		}

		// Token: 0x06035B38 RID: 219960 RVA: 0x00D7DD6B File Offset: 0x00D7BF6B
		protected override void OnAfterHide()
		{
			this.UnBindRedDot();
		}

		// Token: 0x06035B39 RID: 219961 RVA: 0x00D7DD73 File Offset: 0x00D7BF73
		public void BindRedDot()
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RogueSkillUnlock, base.GetItem(5), null, 0);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RoguelikeShop, base.GetItem(6), null, 0);
		}

		// Token: 0x06035B3A RID: 219962 RVA: 0x00D7DD9F File Offset: 0x00D7BF9F
		public void UnBindRedDot()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RogueSkillUnlock, base.GetItem(5), 0);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RoguelikeShop, base.GetItem(6), 0);
		}

		// Token: 0x06035B3B RID: 219963 RVA: 0x00D7DDCC File Offset: 0x00D7BFCC
		private unsafe void OnBtnShopClick()
		{
			ActivityRogueData currentActivityData = ControllerBase<ActivityRogueController>.Instance.GetCurrentActivityData();
			RogueSeasonData rogueSeasonData = (currentActivityData != null) ? currentActivityData.SeasonData : null;
			if (rogueSeasonData == null)
			{
				return;
			}
			RogueSeason? rogueSeasonConfigById = ConfigBase<RoguelikeConfig>.Instance.GetRogueSeasonConfigById(rogueSeasonData.SeasonId);
			PayShopViewData payShopViewData = new PayShopViewData();
			PayShopViewData payShopViewData2 = payShopViewData;
			int num = 1;
			List<int> list = new List<int>(num);
			CollectionsMarshal.SetCount<int>(list, num);
			Span<int> span = CollectionsMarshal.AsSpan<int>(list);
			int index = 0;
			*span[index] = rogueSeasonConfigById.Value.ShopId;
			payShopViewData2.ShowShopIdList = list;
			payShopViewData.PayShopId = (PayShopDefine.EPayShopTabType)rogueSeasonConfigById.Value.ShopId;
			ModelBase<RoguelikeModel>.Instance.RecordRoguelikeShopRedDot();
			ControllerBase<PayShopController>.Instance.OpenPayShopView(payShopViewData, null);
		}

		// Token: 0x06035B3C RID: 219964 RVA: 0x00D7DE74 File Offset: 0x00D7C074
		private void OnBtnSkillTreeClick()
		{
			ActivityRogueData currentActivityData = ControllerBase<ActivityRogueController>.Instance.GetCurrentActivityData();
			RogueSeasonData rogueSeasonData = (currentActivityData != null) ? currentActivityData.SeasonData : null;
			if (rogueSeasonData == null)
			{
				return;
			}
			ControllerBase<RoguelikeController>.Instance.OpenRoguelikeSkillView(rogueSeasonData.SeasonId);
		}

		// Token: 0x06035B3D RID: 219965 RVA: 0x00D7DEAC File Offset: 0x00D7C0AC
		public void Refresh()
		{
			ActivityRogueData currentActivityData = ControllerBase<ActivityRogueController>.Instance.GetCurrentActivityData();
			RogueSeasonData rogueSeasonData = (currentActivityData != null) ? currentActivityData.SeasonData : null;
			if (rogueSeasonData != null)
			{
				RogueParam? rogueParam;
				int num = (ModelBase<RoguelikeModel>.Instance.GetParamConfigBySeasonId(null) != null) ? rogueParam.GetValueOrDefault().WeekTokenMaxCount : 1;
				float fillAmount = (float)rogueSeasonData.TokenItemCount / (float)num;
				UUISprite sprite = base.GetSprite(4);
				if (sprite != null)
				{
					sprite.SetFillAmount(fillAmount);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "Roguelike_ActivityMain_Score", new <>z__ReadOnlyArray<object>(new object[]
				{
					rogueSeasonData.TokenItemCount,
					num
				}));
			}
			double time = (double)ModelBase<RoguelikeModel>.Instance.TempCountdown.GetValueOrDefault() - Singleton<TimeUtil>.Instance.GetServerTime();
			CommonDefine.IRemainTime remainTime = Singleton<TimeUtil>.Instance.CalculateRemainingTime(time, CommonDefine.ETimeType.Minute);
			if (remainTime == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), remainTime.TextId, new <>z__ReadOnlySingleElementList<object>(remainTime.TimeValue));
		}

		// Token: 0x0200B147 RID: 45383
		private class ERoguelikeInstanceBtnPanelDefine
		{
			// Token: 0x04036FA7 RID: 225191
			public const int BtnSkillTree = 0;

			// Token: 0x04036FA8 RID: 225192
			public const int BtnShop = 1;

			// Token: 0x04036FA9 RID: 225193
			public const int TxtShopTime = 2;

			// Token: 0x04036FAA RID: 225194
			public const int TxtShopPoint = 3;

			// Token: 0x04036FAB RID: 225195
			public const int SpriteProgress = 4;

			// Token: 0x04036FAC RID: 225196
			public const int SkillTreeRedItem = 5;

			// Token: 0x04036FAD RID: 225197
			public const int ShopRedItem = 6;
		}
	}
}
