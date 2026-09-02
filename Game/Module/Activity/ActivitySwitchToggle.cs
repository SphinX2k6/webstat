using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity
{
	// Token: 0x020061D8 RID: 25048
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivitySwitchToggle : UiPanelBase, IDynamicScrollItem<IActivityCategoryTabData>
	{
		// Token: 0x17009B42 RID: 39746
		// (get) Token: 0x0603F347 RID: 258887 RVA: 0x01039BB3 File Offset: 0x01037DB3
		// (set) Token: 0x0603F348 RID: 258888 RVA: 0x01039BBB File Offset: 0x01037DBB
		private IActivityCategoryTabData Data { get; set; }

		// Token: 0x17009B43 RID: 39747
		// (get) Token: 0x0603F349 RID: 258889 RVA: 0x01039BC4 File Offset: 0x01037DC4
		// (set) Token: 0x0603F34A RID: 258890 RVA: 0x01039BCC File Offset: 0x01037DCC
		private TOnToggleClickCb OnToggleClick { get; set; }

		// Token: 0x17009B44 RID: 39748
		// (get) Token: 0x0603F34B RID: 258891 RVA: 0x01039BD5 File Offset: 0x01037DD5
		// (set) Token: 0x0603F34C RID: 258892 RVA: 0x01039BDD File Offset: 0x01037DDD
		private CategoryToggleItem TabItem { get; set; }

		// Token: 0x0603F34D RID: 258893 RVA: 0x01039BE8 File Offset: 0x01037DE8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F34E RID: 258894 RVA: 0x01039C54 File Offset: 0x01037E54
		[NullableContext(1)]
		public UniTask Init(UUIItem actor)
		{
			ActivitySwitchToggle.<Init>d__14 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<ActivitySwitchToggle.<Init>d__14>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0603F34F RID: 258895 RVA: 0x01039C9F File Offset: 0x01037E9F
		protected override void OnBeforeShow()
		{
			this.RefreshRedDotIds();
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.RefreshRedDot));
		}

		// Token: 0x0603F350 RID: 258896 RVA: 0x01039CC3 File Offset: 0x01037EC3
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.RefreshRedDot));
		}

		// Token: 0x0603F351 RID: 258897 RVA: 0x01039CE1 File Offset: 0x01037EE1
		protected override void OnBeforeDestroy()
		{
			if (this.Data != null)
			{
				this.Data = null;
			}
			this.RedDotStateMap.Clear();
		}

		// Token: 0x0603F352 RID: 258898 RVA: 0x01039CFD File Offset: 0x01037EFD
		private void OnTabItemClicked(EToggleState state)
		{
			TOnToggleClickCb onToggleClick = this.OnToggleClick;
			if (onToggleClick == null)
			{
				return;
			}
			onToggleClick(this.Data, this.TabItem.GetTabToggle(), state);
		}

		// Token: 0x0603F353 RID: 258899 RVA: 0x01039D21 File Offset: 0x01037F21
		public void ClearItem()
		{
		}

		// Token: 0x0603F354 RID: 258900 RVA: 0x01039D23 File Offset: 0x01037F23
		[NullableContext(1)]
		public AUIBaseActor GetUsingItem(IActivityCategoryTabData data)
		{
			if (data.IsLineType)
			{
				return base.GetItem(1).GetOwner() as AUIBaseActor;
			}
			return base.GetRootItem().GetOwner() as AUIBaseActor;
		}

		// Token: 0x0603F355 RID: 258901 RVA: 0x01039D50 File Offset: 0x01037F50
		[NullableContext(1)]
		public void Update(IActivityCategoryTabData data, int index)
		{
			this.Data = data;
			if (data.IsLineType)
			{
				this.RefreshLineItem();
				return;
			}
			this.RefreshTabItem();
			this.BindRedDotIds((from x in data.Activities
			select x.Id).ToArray<int>());
		}

		// Token: 0x0603F356 RID: 258902 RVA: 0x01039DAE File Offset: 0x01037FAE
		[NullableContext(1)]
		public void InitData(IActivityCategoryTabData data)
		{
			this.Data = data;
		}

		// Token: 0x0603F357 RID: 258903 RVA: 0x01039DB7 File Offset: 0x01037FB7
		[NullableContext(1)]
		public void SetOnToggleClicked(TOnToggleClickCb onToggleSelected)
		{
			this.OnToggleClick = onToggleSelected;
		}

		// Token: 0x0603F358 RID: 258904 RVA: 0x01039DC0 File Offset: 0x01037FC0
		private void RefreshLineItem()
		{
			base.GetItem(1).SetUIActive(true);
			CategoryToggleItem tabItem = this.TabItem;
			if (tabItem == null)
			{
				return;
			}
			tabItem.SetUiActive(false);
		}

		// Token: 0x0603F359 RID: 258905 RVA: 0x01039DE0 File Offset: 0x01037FE0
		private void RefreshTabItem()
		{
			base.GetItem(1).SetUIActive(false);
			CategoryToggleItem tabItem = this.TabItem;
			if (tabItem != null)
			{
				tabItem.SetUiActive(true);
			}
			CategoryToggleItem tabItem2 = this.TabItem;
			if (tabItem2 == null)
			{
				return;
			}
			tabItem2.SetIcon(this.Data.IconPath);
		}

		// Token: 0x0603F35A RID: 258906 RVA: 0x01039E1C File Offset: 0x0103801C
		public void OnSelected(bool fireEvent)
		{
			CategoryToggleItem tabItem = this.TabItem;
			if (tabItem == null)
			{
				return;
			}
			tabItem.GetTabToggle().SetToggleStateForce(EToggleState.ETT_Checked, fireEvent, false, false);
		}

		// Token: 0x17009B45 RID: 39749
		// (get) Token: 0x0603F35B RID: 258907 RVA: 0x01039E37 File Offset: 0x01038037
		// (set) Token: 0x0603F35C RID: 258908 RVA: 0x01039E3F File Offset: 0x0103803F
		[Nullable(1)]
		private Dictionary<int, bool> RedDotStateMap { [NullableContext(1)] get; [NullableContext(1)] set; } = new Dictionary<int, bool>();

		// Token: 0x17009B46 RID: 39750
		// (get) Token: 0x0603F35D RID: 258909 RVA: 0x01039E48 File Offset: 0x01038048
		// (set) Token: 0x0603F35E RID: 258910 RVA: 0x01039E50 File Offset: 0x01038050
		private int RedDotCount { get; set; }

		// Token: 0x0603F35F RID: 258911 RVA: 0x01039E5C File Offset: 0x0103805C
		private void RefreshRedDotIds()
		{
			foreach (int activityId in this.RedDotStateMap.Keys)
			{
				this.RefreshRedDot(activityId);
			}
		}

		// Token: 0x0603F360 RID: 258912 RVA: 0x01039EB4 File Offset: 0x010380B4
		private void ChangeRedDotCount(bool addOrRemove)
		{
			int redDotCount = this.RedDotCount;
			if (addOrRemove)
			{
				int redDotCount2 = this.RedDotCount;
				this.RedDotCount = redDotCount2 + 1;
			}
			else
			{
				int redDotCount2 = this.RedDotCount;
				this.RedDotCount = redDotCount2 - 1;
			}
			if ((redDotCount > 0 && this.RedDotCount == 0) || (redDotCount == 0 && this.RedDotCount > 0))
			{
				this.SetRedDotState(this.RedDotCount > 0);
			}
		}

		// Token: 0x0603F361 RID: 258913 RVA: 0x01039F14 File Offset: 0x01038114
		public void SetRedDotState(bool bVisible)
		{
			this.TabItem.SetRedDotState(bVisible);
		}

		// Token: 0x0603F362 RID: 258914 RVA: 0x01039F24 File Offset: 0x01038124
		private void RefreshRedDot(int activityId)
		{
			bool flag;
			if (this.RedDotStateMap.TryGetValue(activityId, out flag))
			{
				bool activityRedDotState = this.GetActivityRedDotState(activityId);
				this.RedDotStateMap[activityId] = activityRedDotState;
				if (flag && !activityRedDotState)
				{
					this.ChangeRedDotCount(false);
					return;
				}
				if (!flag && activityRedDotState)
				{
					this.ChangeRedDotCount(true);
				}
			}
		}

		// Token: 0x0603F363 RID: 258915 RVA: 0x01039F73 File Offset: 0x01038173
		private bool GetActivityRedDotState(int id)
		{
			return ModelBase<ActivityModel>.Instance.GetActivityRedDotState(id);
		}

		// Token: 0x0603F364 RID: 258916 RVA: 0x01039F80 File Offset: 0x01038180
		[NullableContext(1)]
		public void BindRedDotIds(int[] redDotIds)
		{
			this.RedDotStateMap = new Dictionary<int, bool>();
			this.RedDotCount = 0;
			foreach (int num in redDotIds)
			{
				bool activityRedDotState = this.GetActivityRedDotState(num);
				this.RedDotStateMap[num] = activityRedDotState;
				if (activityRedDotState)
				{
					int redDotCount = this.RedDotCount;
					this.RedDotCount = redDotCount + 1;
				}
			}
			this.SetRedDotState(this.RedDotCount > 0);
		}

		// Token: 0x0200C318 RID: 49944
		[NullableContext(0)]
		private class ECategoryComponents
		{
			// Token: 0x0403C22B RID: 246315
			public const int ItemTypeTitle = 1;

			// Token: 0x0403C22C RID: 246316
			public const int PanelTab = 0;
		}
	}
}
