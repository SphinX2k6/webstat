using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BF6 RID: 23542
	public class InstanceDungeonSolarSpeedPanelItem : UiPanelBase
	{
		// Token: 0x0603B93C RID: 244028 RVA: 0x00F1A324 File Offset: 0x00F18524
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnScoreReward));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B93D RID: 244029 RVA: 0x00F1A40C File Offset: 0x00F1860C
		protected override void OnStart()
		{
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), "BossRushCollectReward", Array.Empty<object>());
			if (this.ItemDataHandle != null && this.ItemDataHandle.HaveRefresh)
			{
				this.RefreshItem();
			}
		}

		// Token: 0x0603B93E RID: 244030 RVA: 0x00F1A444 File Offset: 0x00F18644
		protected override UniTask OnBeforeStartAsync()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.SolarSpeedRewarded, new Action(this.HandleSolarSpeedRewarded));
			return UniTask.CompletedTask;
		}

		// Token: 0x0603B93F RID: 244031 RVA: 0x00F1A467 File Offset: 0x00F18667
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.SolarSpeedRewarded, new Action(this.HandleSolarSpeedRewarded));
		}

		// Token: 0x0603B940 RID: 244032 RVA: 0x00F1A488 File Offset: 0x00F18688
		public void RefreshItem()
		{
			if (base.InAsyncLoading())
			{
				this.ItemDataHandle = new IInstanceDungeonSolarSpeedPanelItem
				{
					HaveRefresh = true
				};
				return;
			}
			SolarSpeedModel instance = ModelBase<SolarSpeedModel>.Instance;
			base.GetItem(2).SetUIActive(instance.HasRewardRedDot);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(3), "parkour_award_2_1", new <>z__ReadOnlyArray<object>(new object[]
			{
				instance.CurrentCompletedCount,
				instance.TotalRewardCount
			}));
		}

		// Token: 0x0603B941 RID: 244033 RVA: 0x00F1A505 File Offset: 0x00F18705
		private void OnClickBtnScoreReward()
		{
			ControllerBase<ActivitySolarSpeedController>.Instance.HandleOnClickRewardInActivitySubView();
		}

		// Token: 0x0603B942 RID: 244034 RVA: 0x00F1A511 File Offset: 0x00F18711
		private void HandleSolarSpeedRewarded()
		{
			this.RefreshItem();
		}

		// Token: 0x04021897 RID: 137367
		[Nullable(2)]
		private IInstanceDungeonSolarSpeedPanelItem ItemDataHandle;

		// Token: 0x0200BC6C RID: 48236
		private enum EChildType
		{
			// Token: 0x0403A196 RID: 237974
			BtnScoreReward,
			// Token: 0x0403A197 RID: 237975
			TxtTitle,
			// Token: 0x0403A198 RID: 237976
			ScoreRedDot,
			// Token: 0x0403A199 RID: 237977
			TxtProgress
		}
	}
}
