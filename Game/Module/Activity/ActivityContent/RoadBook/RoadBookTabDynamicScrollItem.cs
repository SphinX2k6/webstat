using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064A7 RID: 25767
	[NullableContext(1)]
	[Nullable(0)]
	public class RoadBookTabDynamicScrollItem : UiPanelBase, IDynamicScrollItem<RoadBookAreaData>
	{
		// Token: 0x0604098C RID: 264588 RVA: 0x0108EFDE File Offset: 0x0108D1DE
		public RoadBookTabDynamicScrollItem(ActivityRoadBookData activityBaseData)
		{
			this.ActivityBaseData = activityBaseData;
		}

		// Token: 0x0604098D RID: 264589 RVA: 0x0108EFF0 File Offset: 0x0108D1F0
		public UniTask Init(UUIItem actor)
		{
			RoadBookTabDynamicScrollItem.<Init>d__7 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<RoadBookTabDynamicScrollItem.<Init>d__7>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x0604098E RID: 264590 RVA: 0x0108F03B File Offset: 0x0108D23B
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x0604098F RID: 264591 RVA: 0x0108F074 File Offset: 0x0108D274
		protected override UniTask OnBeforeStartAsync()
		{
			RoadBookTabDynamicScrollItem.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoadBookTabDynamicScrollItem.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040990 RID: 264592 RVA: 0x0108F0B7 File Offset: 0x0108D2B7
		[return: Nullable(2)]
		public AUIBaseActor GetUsingItem(RoadBookAreaData data)
		{
			if (data.IsUnlock)
			{
				return this.GetItemActor(EComponents.LockItem);
			}
			return this.GetItemActor(EComponents.NormalItem);
		}

		// Token: 0x06040991 RID: 264593 RVA: 0x0108F0D0 File Offset: 0x0108D2D0
		private AUIBaseActor GetItemActor(EComponents key)
		{
			return base.GetItem((int)key).GetOwner() as AUIBaseActor;
		}

		// Token: 0x06040992 RID: 264594 RVA: 0x0108F0E4 File Offset: 0x0108D2E4
		public void Update(RoadBookAreaData data, int index)
		{
			this.Data = data;
			this.LockItem.SetUiActive(!data.IsUnlock);
			this.NormalItem.SetUiActive(data.IsUnlock);
			if (!data.IsUnlock)
			{
				this.LockItem.RefreshByData(data, index);
			}
			else
			{
				this.NormalItem.RefreshByData(data, index);
			}
			Func<RoadBookAreaData, int, bool> isSelectedOn = this.IsSelectedOn;
			if (isSelectedOn != null && isSelectedOn(data, index))
			{
				this.SetSelected(true, false);
				return;
			}
			this.SetSelected(false, false);
		}

		// Token: 0x06040993 RID: 264595 RVA: 0x0108F168 File Offset: 0x0108D368
		public void SetSelected(bool bOn, bool bFireEvent)
		{
			this.LockItem.SetToggleState(bOn, bFireEvent && !this.Data.IsUnlock);
			this.NormalItem.SetToggleState(bOn, bFireEvent && this.Data.IsUnlock);
		}

		// Token: 0x06040994 RID: 264596 RVA: 0x0108F1A7 File Offset: 0x0108D3A7
		public void BindSelectedCallBack(Action<RoadBookAreaData, int> selectCallback)
		{
			this.SelectedCallBack = selectCallback;
		}

		// Token: 0x06040995 RID: 264597 RVA: 0x0108F1B0 File Offset: 0x0108D3B0
		public void BindIsSelectedOn(Func<RoadBookAreaData, int, bool> isSelectedOn)
		{
			this.IsSelectedOn = isSelectedOn;
		}

		// Token: 0x06040996 RID: 264598 RVA: 0x0108F1B9 File Offset: 0x0108D3B9
		public void ClearItem()
		{
			base.Destroy(null);
		}

		// Token: 0x040242B0 RID: 148144
		[Nullable(2)]
		private RoadBookTabItem NormalItem;

		// Token: 0x040242B1 RID: 148145
		[Nullable(2)]
		private RoadBookTabItemLock LockItem;

		// Token: 0x040242B2 RID: 148146
		[Nullable(2)]
		protected RoadBookAreaData Data;

		// Token: 0x040242B3 RID: 148147
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected Action<RoadBookAreaData, int> SelectedCallBack;

		// Token: 0x040242B4 RID: 148148
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected Func<RoadBookAreaData, int, bool> IsSelectedOn;

		// Token: 0x040242B5 RID: 148149
		protected ActivityRoadBookData ActivityBaseData;
	}
}
