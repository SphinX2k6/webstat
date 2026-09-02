using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060A0 RID: 24736
	public class ShipTowerBuffBattleView : BattleVisibleChildView
	{
		// Token: 0x0603E735 RID: 255797 RVA: 0x00FF60C4 File Offset: 0x00FF42C4
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			base.InitChildType(EBattleUiChild.MiniMap);
			base.SetVisible(1, false);
			this.Panel = new BattleUiHoverTipsD();
			this.AddEvents();
		}

		// Token: 0x0603E736 RID: 255798 RVA: 0x00FF60ED File Offset: 0x00FF42ED
		public override void Reset()
		{
			base.Reset();
			this.RemoveEvents();
		}

		// Token: 0x0603E737 RID: 255799 RVA: 0x00FF60FC File Offset: 0x00FF42FC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603E738 RID: 255800 RVA: 0x00FF61A2 File Offset: 0x00FF43A2
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.BattleUiToggleShipTowerBuffInfo, new Action(this.OnToggleShipTowerBuffInfoView));
		}

		// Token: 0x0603E739 RID: 255801 RVA: 0x00FF61C0 File Offset: 0x00FF43C0
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiToggleShipTowerBuffInfo, new Action(this.OnToggleShipTowerBuffInfoView));
		}

		// Token: 0x0603E73A RID: 255802 RVA: 0x00FF61DE File Offset: 0x00FF43DE
		public void StartShow()
		{
			this.Panel.UpdateInfo(ModelBase<ShipTowerModel>.Instance.GetInTheBattleBuffInfo());
			base.SetVisible(1, true);
			BattleUiEnvironmentKeyData environmentKeyData = ModelBase<BattleUiModel>.Instance.EnvironmentKeyData;
			if (environmentKeyData == null)
			{
				return;
			}
			environmentKeyData.SetEnvironmentKeyVisible(EEnvironmentKey.ShipTowerBuff, true);
		}

		// Token: 0x0603E73B RID: 255803 RVA: 0x00FF6214 File Offset: 0x00FF4414
		public void EndShow()
		{
			this.Panel.EndShow();
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
			}
			base.SetVisible(1, false);
			BattleUiEnvironmentKeyData environmentKeyData = ModelBase<BattleUiModel>.Instance.EnvironmentKeyData;
			if (environmentKeyData == null)
			{
				return;
			}
			environmentKeyData.SetEnvironmentKeyVisible(EEnvironmentKey.ShipTowerBuff, false);
		}

		// Token: 0x0603E73C RID: 255804 RVA: 0x00FF6261 File Offset: 0x00FF4461
		protected override void OnAfterDestroy()
		{
			BattleUiEnvironmentKeyData environmentKeyData = ModelBase<BattleUiModel>.Instance.EnvironmentKeyData;
			if (environmentKeyData == null)
			{
				return;
			}
			environmentKeyData.SetEnvironmentKeyVisible(EEnvironmentKey.ShipTowerBuff, false);
		}

		// Token: 0x0603E73D RID: 255805 RVA: 0x00FF627C File Offset: 0x00FF447C
		private void OnClickToggle(EToggleState toggleState)
		{
			if (toggleState == EToggleState.ETT_Checked)
			{
				UUIItem item = base.GetItem(1);
				this.Panel.CreateAndShow(item, ModelBase<ShipTowerModel>.Instance.GetInTheBattleBuffInfo());
				return;
			}
			this.Panel.EndShow();
		}

		// Token: 0x0603E73E RID: 255806 RVA: 0x00FF62B8 File Offset: 0x00FF44B8
		private void OnToggleShipTowerBuffInfoView()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				if (extendToggle.GetToggleState() == EToggleState.ETT_Checked)
				{
					extendToggle.SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
					return;
				}
				extendToggle.SetToggleState(EToggleState.ETT_Checked, true, false, false);
			}
		}

		// Token: 0x04023030 RID: 143408
		[Nullable(2)]
		private BattleUiHoverTipsD Panel;

		// Token: 0x0200C1AD RID: 49581
		private enum EVisibleReason
		{
			// Token: 0x0403BA2A RID: 244266
			Default = 1
		}

		// Token: 0x0200C1AE RID: 49582
		private enum EChildComponent
		{
			// Token: 0x0403BA2C RID: 244268
			Toggle,
			// Token: 0x0403BA2D RID: 244269
			PanelNode
		}
	}
}
