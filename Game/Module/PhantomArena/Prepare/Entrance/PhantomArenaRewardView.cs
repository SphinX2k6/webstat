using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054E1 RID: 21729
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaRewardView : UiViewBase
	{
		// Token: 0x060375CD RID: 226765 RVA: 0x00E0CDDC File Offset: 0x00E0AFDC
		public PhantomArenaRewardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060375CE RID: 226766 RVA: 0x00E0CDFC File Offset: 0x00E0AFFC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(6, new Action(this.OnDetailBtnClick)),
				new ValueTuple<int, Delegate>(5, new Action(this.OnRewardBtnClick))
			};
		}

		// Token: 0x060375CF RID: 226767 RVA: 0x00E0CEFF File Offset: 0x00E0B0FF
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPhantomArenaTaskAwardUpdate, new Action<int>(this.OnGetRewardUpdate));
		}

		// Token: 0x060375D0 RID: 226768 RVA: 0x00E0CF1D File Offset: 0x00E0B11D
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaTaskAwardUpdate, new Action<int>(this.OnGetRewardUpdate));
		}

		// Token: 0x060375D1 RID: 226769 RVA: 0x00E0CF3C File Offset: 0x00E0B13C
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaRewardView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaRewardView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060375D2 RID: 226770 RVA: 0x00E0CF80 File Offset: 0x00E0B180
		private void RefreshLeftButton()
		{
			this.SpecialTask = ModelBase<PhantomArenaModel>.Instance.GetSpecialTask(this.ActivityId);
			if (this.SpecialTask != null)
			{
				UUIButtonComponent button = base.GetButton(6);
				if (button != null)
				{
					button.RootUIComp.Get().SetUIActive(this.SpecialTask.Status != ActivityTaskState.ActivityTaskFinish);
				}
				UUIButtonComponent button2 = base.GetButton(5);
				if (button2 != null)
				{
					button2.RootUIComp.Get().SetUIActive(this.SpecialTask.Status == ActivityTaskState.ActivityTaskFinish);
				}
				PhantomBattleTask? taskConfigById = ConfigBase<PhantomArenaConfig>.Instance.GetTaskConfigById(this.SpecialTask.Id);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), taskConfigById.Value.Desc, Array.Empty<object>());
			}
		}

		// Token: 0x060375D3 RID: 226771 RVA: 0x00E0D048 File Offset: 0x00E0B248
		private void RefreshScrollView(int tabIndex)
		{
			this.DataList.Clear();
			this.DataList = ModelBase<PhantomArenaModel>.Instance.GetTaskDataByTabId(tabIndex, this.ActivityId);
			this.TaskLayout.RefreshByData(this.DataList, delegate
			{
				this.TaskLayout.ScrollToTop(0);
			}, true);
		}

		// Token: 0x060375D4 RID: 226772 RVA: 0x00E0D095 File Offset: 0x00E0B295
		private PhantomBattleTaskTabItem CreateTaskTabItem()
		{
			return new PhantomBattleTaskTabItem
			{
				OnClickedCb = new Action<int>(this.OnClickTab),
				ActivityId = this.ActivityId
			};
		}

		// Token: 0x060375D5 RID: 226773 RVA: 0x00E0D0BC File Offset: 0x00E0B2BC
		private void OnClickTab(int index)
		{
			for (int i = 0; i < this.TabTypeList.Count; i++)
			{
				this.TabLayout.GetLayoutItemByIndex(i).SetToggleState(index == this.TabTypeList[i], false);
			}
			this.CurrentTypeIndex = index;
			this.RefreshScrollView(this.CurrentTypeIndex);
		}

		// Token: 0x060375D6 RID: 226774 RVA: 0x00E0D114 File Offset: 0x00E0B314
		private void OnGetRewardUpdate(int activityId)
		{
			for (int i = 0; i < this.TabTypeList.Count; i++)
			{
				this.TabLayout.GetLayoutItemByIndex(i).RefreshRedDot();
			}
			this.RefreshScrollView(this.CurrentTypeIndex);
			this.RefreshLeftButton();
		}

		// Token: 0x060375D7 RID: 226775 RVA: 0x00E0D15A File Offset: 0x00E0B35A
		private PhantomBattleTaskItem CreateTaskItem()
		{
			return new PhantomBattleTaskItem();
		}

		// Token: 0x060375D8 RID: 226776 RVA: 0x00E0D164 File Offset: 0x00E0B364
		private void OnDetailBtnClick()
		{
			int rewardItemId = ModelBase<PhantomArenaModel>.Instance.GetRewardItemId(this.ActivityId);
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(rewardItemId, true, null);
		}

		// Token: 0x060375D9 RID: 226777 RVA: 0x00E0D190 File Offset: 0x00E0B390
		private void OnRewardBtnClick()
		{
			if (this.SpecialTask != null)
			{
				ControllerBase<PhantomArenaController>.Instance.TaskRewardRequest(this.SpecialTask.Id);
				return;
			}
			Singleton<Log>.Instance.Error(ELogModule.PhantomArena, ELogAuthor.CXJ, "特殊奖励不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x060375DA RID: 226778 RVA: 0x00E0D1DA File Offset: 0x00E0B3DA
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0401FCB7 RID: 130231
		private int ActivityId;

		// Token: 0x0401FCB8 RID: 130232
		private GenericLayout<PhantomBattleTaskTabItem, int> TabLayout;

		// Token: 0x0401FCB9 RID: 130233
		private GenericScrollViewNew<PhantomBattleTaskItem, PhantomArenaTaskData> TaskLayout;

		// Token: 0x0401FCBA RID: 130234
		private int CurrentTypeIndex;

		// Token: 0x0401FCBB RID: 130235
		protected List<int> TabTypeList = new List<int>();

		// Token: 0x0401FCBC RID: 130236
		private List<PhantomArenaTaskData> DataList = new List<PhantomArenaTaskData>();

		// Token: 0x0401FCBD RID: 130237
		[Nullable(2)]
		private ActivityTask SpecialTask;

		// Token: 0x0200B45C RID: 46172
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04037D47 RID: 228679
			public const int ItemCaption = 0;

			// Token: 0x04037D48 RID: 228680
			public const int ScrollLayoutTask = 1;

			// Token: 0x04037D49 RID: 228681
			public const int ItemTask = 2;

			// Token: 0x04037D4A RID: 228682
			public const int LayoutTab = 3;

			// Token: 0x04037D4B RID: 228683
			public const int TextTip = 4;

			// Token: 0x04037D4C RID: 228684
			public const int BtnReward = 5;

			// Token: 0x04037D4D RID: 228685
			public const int BtnDetail = 6;

			// Token: 0x04037D4E RID: 228686
			public const int TextTime = 7;
		}
	}
}
