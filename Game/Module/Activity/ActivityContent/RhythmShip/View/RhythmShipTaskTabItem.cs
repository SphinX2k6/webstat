using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x02006523 RID: 25891
	internal class RhythmShipTaskTabItem : GridProxyAbstract<int>
	{
		// Token: 0x06040C05 RID: 265221 RVA: 0x0109AAD0 File Offset: 0x01098CD0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
			};
		}

		// Token: 0x06040C06 RID: 265222 RVA: 0x0109AB50 File Offset: 0x01098D50
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			if (this.TabId > 0)
			{
				ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RhythmShipTaskTab, base.GetItem(2), this.TabId);
			}
			this.TabId = data;
			RhythmTaskTab? rhythmShipTaskTabById = ConfigBase<RhythmShipConfig>.Instance.GetRhythmShipTaskTabById(this.TabId);
			if (rhythmShipTaskTabById == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), rhythmShipTaskTabById.Value.TabName, Array.Empty<object>());
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RhythmShipTaskTab, base.GetItem(2), null, this.TabId);
		}

		// Token: 0x06040C07 RID: 265223 RVA: 0x0109ABE6 File Offset: 0x01098DE6
		private void OnClickToggle(EToggleState state)
		{
			Action<int, UUIExtendToggle> onClickToggleCallBack = this.OnClickToggleCallBack;
			if (onClickToggleCallBack == null)
			{
				return;
			}
			onClickToggleCallBack(this.TabId, base.GetExtendToggle(0));
		}

		// Token: 0x06040C08 RID: 265224 RVA: 0x0109AC05 File Offset: 0x01098E05
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, true, false, false);
		}

		// Token: 0x06040C09 RID: 265225 RVA: 0x0109AC18 File Offset: 0x01098E18
		protected override void OnBeforeDestroy()
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.RhythmShipTaskTab, base.GetItem(2), this.TabId);
		}

		// Token: 0x040244FD RID: 148733
		public int TabId;

		// Token: 0x040244FE RID: 148734
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<int, UUIExtendToggle> OnClickToggleCallBack;
	}
}
