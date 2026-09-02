using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064A8 RID: 25768
	[NullableContext(1)]
	[Nullable(0)]
	public class RoadBookTabItemBase : UiPanelBase
	{
		// Token: 0x06040998 RID: 264600 RVA: 0x0108F1CD File Offset: 0x0108D3CD
		public RoadBookTabItemBase(ActivityRoadBookData activityBaseData)
		{
			this.ActivityBaseData = activityBaseData;
		}

		// Token: 0x06040999 RID: 264601 RVA: 0x0108F1DC File Offset: 0x0108D3DC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleSelectOn))
			};
		}

		// Token: 0x0604099A RID: 264602 RVA: 0x0108F285 File Offset: 0x0108D485
		private void OnToggleSelectOn(EToggleState toggleState)
		{
			if (this.Data != null)
			{
				Action<RoadBookAreaData, int> selectedCallBack = this.SelectedCallBack;
				if (selectedCallBack == null)
				{
					return;
				}
				selectedCallBack(this.Data, this.Index);
			}
		}

		// Token: 0x0604099B RID: 264603 RVA: 0x0108F2AC File Offset: 0x0108D4AC
		public void SetToggleState(bool bOn, bool bFireEvent)
		{
			EToggleState state = bOn ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleState(state, bFireEvent, false, false);
		}

		// Token: 0x0604099C RID: 264604 RVA: 0x0108F2D2 File Offset: 0x0108D4D2
		public virtual void RefreshByData(RoadBookAreaData data, int index)
		{
			this.Data = data;
			this.Index = index;
		}

		// Token: 0x040242B6 RID: 148150
		[Nullable(2)]
		protected RoadBookAreaData Data;

		// Token: 0x040242B7 RID: 148151
		protected int Index;

		// Token: 0x040242B8 RID: 148152
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<RoadBookAreaData, int> SelectedCallBack;

		// Token: 0x040242B9 RID: 148153
		protected ActivityRoadBookData ActivityBaseData;
	}
}
