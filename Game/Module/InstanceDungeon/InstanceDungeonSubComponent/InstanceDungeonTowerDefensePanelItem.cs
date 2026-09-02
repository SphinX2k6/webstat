using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BFC RID: 23548
	public class InstanceDungeonTowerDefensePanelItem : UiPanelBase
	{
		// Token: 0x0603B957 RID: 244055 RVA: 0x00F1ADF8 File Offset: 0x00F18FF8
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

		// Token: 0x0603B958 RID: 244056 RVA: 0x00F1AEE0 File Offset: 0x00F190E0
		protected override void OnStart()
		{
			if (this.ItemDataHandle != null && this.ItemDataHandle.HaveRefresh)
			{
				this.RefreshItem();
			}
		}

		// Token: 0x0603B959 RID: 244057 RVA: 0x00F1AF00 File Offset: 0x00F19100
		public void RefreshItem()
		{
			if (base.InAsyncLoading())
			{
				this.ItemDataHandle = new IInstanceDungeonTowerDefensePanelItem
				{
					HaveRefresh = true
				};
				return;
			}
			base.GetItem(2).SetUIActive(ControllerBase<TowerDefenseController>.Instance.CheckHasReward());
			string text = ControllerBase<TowerDefenseController>.Instance.BuildTotalScoreContent();
			base.GetText(1).SetText(text ?? "", true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "TowerDefence_PintDesc", Array.Empty<object>());
		}

		// Token: 0x0603B95A RID: 244058 RVA: 0x00F1AF7C File Offset: 0x00F1917C
		private void OnClickBtnScoreReward()
		{
			IActivityRewardViewData param = ControllerBase<TowerDefenseController>.Instance.BuildPreviewRewardData();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRewardPopUpView, param, delegate(bool success, int viewId)
			{
				if (success && Singleton<UiManager>.Instance.IsViewShow(EUiViewName.InstanceDungeonEntranceView))
				{
					UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.InstanceDungeonEntranceView);
					if (viewByName == null)
					{
						return;
					}
					viewByName.AddChildViewById(viewId);
				}
			});
		}

		// Token: 0x0402189E RID: 137374
		[Nullable(2)]
		private IInstanceDungeonTowerDefensePanelItem ItemDataHandle;

		// Token: 0x0200BC71 RID: 48241
		private enum EChildType
		{
			// Token: 0x0403A1AA RID: 237994
			BtnScoreReward,
			// Token: 0x0403A1AB RID: 237995
			TxtScore,
			// Token: 0x0403A1AC RID: 237996
			ScoreRedDot,
			// Token: 0x0403A1AD RID: 237997
			TxtDesc
		}
	}
}
