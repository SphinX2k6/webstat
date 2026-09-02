using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054CE RID: 21710
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaEntranceTaskTabView : UiTabViewBase
	{
		// Token: 0x060374CB RID: 226507 RVA: 0x00E0799C File Offset: 0x00E05B9C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x060374CC RID: 226508 RVA: 0x00E079F8 File Offset: 0x00E05BF8
		protected override void OnStart()
		{
			this.ActivityId = (int)this.ExtraParams;
			this.TaskTabLayout = new GenericLayout<PhantomBattleTaskTabItem, int>(base.GetHorizontalLayout(0), new Func<PhantomBattleTaskTabItem>(this.InitTaskItem), null, false, true);
			this.ScrollView = new LoopScrollView<PhantomBattleTaskItem, PhantomArenaTaskData>(base.GetLoopScrollViewComponent(1), base.GetItem(2).GetOwner() as AUIBaseActor, new Func<PhantomBattleTaskItem>(this.OnCreateTaskItem), false);
		}

		// Token: 0x060374CD RID: 226509 RVA: 0x00E07A67 File Offset: 0x00E05C67
		protected override void OnBeforeDestroy()
		{
			this.TaskTabLayout = null;
			this.ScrollView = null;
		}

		// Token: 0x060374CE RID: 226510 RVA: 0x00E07A78 File Offset: 0x00E05C78
		protected override void OnBeforeShow()
		{
			List<int> list = this.CreateTabItemDataList();
			this.CurrentTypeIndex = ((list.Count > 0) ? list[0] : 0);
			GenericLayout<PhantomBattleTaskTabItem, int> taskTabLayout = this.TaskTabLayout;
			if (taskTabLayout == null)
			{
				return;
			}
			taskTabLayout.RefreshByData(list, delegate
			{
				this.OnClickTab(this.CurrentTypeIndex);
			}, false);
		}

		// Token: 0x060374CF RID: 226511 RVA: 0x00E07AC3 File Offset: 0x00E05CC3
		protected override void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPhantomArenaTaskAwardUpdate, new Action<int>(this.OnGetRewardUpdate));
		}

		// Token: 0x060374D0 RID: 226512 RVA: 0x00E07AE1 File Offset: 0x00E05CE1
		protected override void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaTaskAwardUpdate, new Action<int>(this.OnGetRewardUpdate));
		}

		// Token: 0x060374D1 RID: 226513 RVA: 0x00E07AFF File Offset: 0x00E05CFF
		private PhantomBattleTaskTabItem InitTaskItem()
		{
			return new PhantomBattleTaskTabItem
			{
				OnClickedCb = new Action<int>(this.OnClickTab),
				ActivityId = this.ActivityId
			};
		}

		// Token: 0x060374D2 RID: 226514 RVA: 0x00E07B24 File Offset: 0x00E05D24
		private void OnClickTab(int index)
		{
			for (int i = 0; i < this.TabTypeList.Count; i++)
			{
				this.TaskTabLayout.GetLayoutItemByIndex(i).SetToggleState(index == this.TabTypeList[i], false);
			}
			this.CurrentTypeIndex = index;
			this.RefreshScrollView(this.CurrentTypeIndex);
		}

		// Token: 0x060374D3 RID: 226515 RVA: 0x00E07B7C File Offset: 0x00E05D7C
		private void OnGetRewardUpdate(int activityId)
		{
			for (int i = 0; i < this.TabTypeList.Count; i++)
			{
				this.TaskTabLayout.GetLayoutItemByIndex(i).RefreshRedDot();
			}
			this.RefreshScrollView(this.CurrentTypeIndex);
		}

		// Token: 0x060374D4 RID: 226516 RVA: 0x00E07BBD File Offset: 0x00E05DBD
		private PhantomBattleTaskItem OnCreateTaskItem()
		{
			return new PhantomBattleTaskItem();
		}

		// Token: 0x060374D5 RID: 226517 RVA: 0x00E07BC4 File Offset: 0x00E05DC4
		private List<int> CreateTabItemDataList()
		{
			this.TabTypeList = ModelBase<PhantomArenaModel>.Instance.GetTaskTabList(this.ActivityId);
			this.CurrentTypeIndex = 0;
			return this.TabTypeList;
		}

		// Token: 0x060374D6 RID: 226518 RVA: 0x00E07BEC File Offset: 0x00E05DEC
		private UniTask RefreshScrollView(int tabIndex)
		{
			PhantomArenaEntranceTaskTabView.<RefreshScrollView>d__18 <RefreshScrollView>d__;
			<RefreshScrollView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshScrollView>d__.<>4__this = this;
			<RefreshScrollView>d__.tabIndex = tabIndex;
			<RefreshScrollView>d__.<>1__state = -1;
			<RefreshScrollView>d__.<>t__builder.Start<PhantomArenaEntranceTaskTabView.<RefreshScrollView>d__18>(ref <RefreshScrollView>d__);
			return <RefreshScrollView>d__.<>t__builder.Task;
		}

		// Token: 0x0401FC6C RID: 130156
		protected int ActivityId;

		// Token: 0x0401FC6D RID: 130157
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<PhantomBattleTaskTabItem, int> TaskTabLayout;

		// Token: 0x0401FC6E RID: 130158
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<PhantomBattleTaskItem, PhantomArenaTaskData> ScrollView;

		// Token: 0x0401FC6F RID: 130159
		private int CurrentTypeIndex;

		// Token: 0x0401FC70 RID: 130160
		protected List<int> TabTypeList = new List<int>();

		// Token: 0x0401FC71 RID: 130161
		private List<PhantomArenaTaskData> DataList = new List<PhantomArenaTaskData>();

		// Token: 0x0200B438 RID: 46136
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04037C65 RID: 228453
			public const int PanelHorizon = 0;

			// Token: 0x04037C66 RID: 228454
			public const int SvList = 1;

			// Token: 0x04037C67 RID: 228455
			public const int TaskItem = 2;
		}
	}
}
