using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200607B RID: 24699
	public class MoraleBuffBattleView : BattleVisibleChildView
	{
		// Token: 0x0603E47C RID: 255100 RVA: 0x00FE6A21 File Offset: 0x00FE4C21
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			base.InitChildType(EBattleUiChild.MiniMap);
			base.SetVisible(1, false);
			this.Panel = new BattleUiHoverTipsC();
			this.AddEvents();
		}

		// Token: 0x0603E47D RID: 255101 RVA: 0x00FE6A4A File Offset: 0x00FE4C4A
		public override void Reset()
		{
			base.Reset();
			this.RemoveEvents();
		}

		// Token: 0x0603E47E RID: 255102 RVA: 0x00FE6A58 File Offset: 0x00FE4C58
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

		// Token: 0x0603E47F RID: 255103 RVA: 0x00FE6AFE File Offset: 0x00FE4CFE
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.BattleUiToggleMoraleBuffInfo, new Action(this.OnToggleMoraleBuffInfoView));
		}

		// Token: 0x0603E480 RID: 255104 RVA: 0x00FE6B1C File Offset: 0x00FE4D1C
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiToggleMoraleBuffInfo, new Action(this.OnToggleMoraleBuffInfoView));
		}

		// Token: 0x0603E481 RID: 255105 RVA: 0x00FE6B3A File Offset: 0x00FE4D3A
		public void StartShow()
		{
			this.Panel.UpdateInfo(ModelBase<MoraleModel>.Instance.GetInTheBattleBuffInfo());
			base.SetVisible(1, true);
			BattleUiEnvironmentKeyData environmentKeyData = ModelBase<BattleUiModel>.Instance.EnvironmentKeyData;
			if (environmentKeyData == null)
			{
				return;
			}
			environmentKeyData.SetEnvironmentKeyVisible(EEnvironmentKey.MoraleBuff, true);
		}

		// Token: 0x0603E482 RID: 255106 RVA: 0x00FE6B70 File Offset: 0x00FE4D70
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
			environmentKeyData.SetEnvironmentKeyVisible(EEnvironmentKey.MoraleBuff, false);
		}

		// Token: 0x0603E483 RID: 255107 RVA: 0x00FE6BBD File Offset: 0x00FE4DBD
		protected override void OnAfterDestroy()
		{
			BattleUiEnvironmentKeyData environmentKeyData = ModelBase<BattleUiModel>.Instance.EnvironmentKeyData;
			if (environmentKeyData == null)
			{
				return;
			}
			environmentKeyData.SetEnvironmentKeyVisible(EEnvironmentKey.MoraleBuff, false);
		}

		// Token: 0x0603E484 RID: 255108 RVA: 0x00FE6BD8 File Offset: 0x00FE4DD8
		private void OnClickToggle(EToggleState toggleState)
		{
			if (toggleState == EToggleState.ETT_Checked)
			{
				UUIItem item = base.GetItem(1);
				this.Panel.CreateAndShow(item, ModelBase<MoraleModel>.Instance.GetInTheBattleBuffInfo());
				return;
			}
			this.Panel.EndShow();
		}

		// Token: 0x0603E485 RID: 255109 RVA: 0x00FE6C14 File Offset: 0x00FE4E14
		private void OnToggleMoraleBuffInfoView()
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

		// Token: 0x04022E91 RID: 142993
		[Nullable(2)]
		private BattleUiHoverTipsC Panel;

		// Token: 0x0200C14C RID: 49484
		private enum EVisibleReason
		{
			// Token: 0x0403B865 RID: 243813
			Default = 1
		}

		// Token: 0x0200C14D RID: 49485
		private enum EChildComponent
		{
			// Token: 0x0403B867 RID: 243815
			Toggle,
			// Token: 0x0403B868 RID: 243816
			PanelNode
		}
	}
}
