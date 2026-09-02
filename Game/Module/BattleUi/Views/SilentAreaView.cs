using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060A5 RID: 24741
	public class SilentAreaView : BattleVisibleChildView
	{
		// Token: 0x17009AD2 RID: 39634
		// (get) Token: 0x0603E761 RID: 255841 RVA: 0x00FF6CFE File Offset: 0x00FF4EFE
		public long Id
		{
			get
			{
				return this.TreeIncId;
			}
		}

		// Token: 0x0603E762 RID: 255842 RVA: 0x00FF6D06 File Offset: 0x00FF4F06
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			base.InitChildType(EBattleUiChild.MiniMap);
			base.SetVisible(1, false);
			this.Panel = new SilentAreaInfoPanel();
			this.AddEvents();
		}

		// Token: 0x0603E763 RID: 255843 RVA: 0x00FF6D2F File Offset: 0x00FF4F2F
		public override void Reset()
		{
			base.Reset();
			this.RemoveEvents();
		}

		// Token: 0x0603E764 RID: 255844 RVA: 0x00FF6D40 File Offset: 0x00FF4F40
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

		// Token: 0x0603E765 RID: 255845 RVA: 0x00FF6DE6 File Offset: 0x00FF4FE6
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.BattleUiToggleSilentAreaInfoView, new Action(this.OnToggleSilentAreaInfoView));
		}

		// Token: 0x0603E766 RID: 255846 RVA: 0x00FF6E04 File Offset: 0x00FF5004
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiToggleSilentAreaInfoView, new Action(this.OnToggleSilentAreaInfoView));
		}

		// Token: 0x0603E767 RID: 255847 RVA: 0x00FF6E22 File Offset: 0x00FF5022
		[NullableContext(1)]
		public void StartShow(long treeIncId, BaseBehaviorTree tree)
		{
			this.TreeIncId = treeIncId;
			this.Tree = tree;
			this.Panel.UpdateInfo(tree.GetSilentAreaShowInfo());
			base.SetVisible(1, true);
			BattleUiEnvironmentKeyData environmentKeyData = ModelBase<BattleUiModel>.Instance.EnvironmentKeyData;
			if (environmentKeyData == null)
			{
				return;
			}
			environmentKeyData.SetEnvironmentKeyVisible(EEnvironmentKey.SilentArea, true);
		}

		// Token: 0x0603E768 RID: 255848 RVA: 0x00FF6E64 File Offset: 0x00FF5064
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
			environmentKeyData.SetEnvironmentKeyVisible(EEnvironmentKey.SilentArea, false);
		}

		// Token: 0x0603E769 RID: 255849 RVA: 0x00FF6EB1 File Offset: 0x00FF50B1
		protected override void OnAfterDestroy()
		{
			BattleUiEnvironmentKeyData environmentKeyData = ModelBase<BattleUiModel>.Instance.EnvironmentKeyData;
			if (environmentKeyData == null)
			{
				return;
			}
			environmentKeyData.SetEnvironmentKeyVisible(EEnvironmentKey.SilentArea, false);
		}

		// Token: 0x0603E76A RID: 255850 RVA: 0x00FF6ECC File Offset: 0x00FF50CC
		private void OnClickToggle(EToggleState toggleState)
		{
			if (toggleState == EToggleState.ETT_Checked)
			{
				UUIItem item = base.GetItem(1);
				BaseBehaviorTree tree = this.Tree;
				SilentAreaShowInfo silentAreaInfo = (tree != null) ? tree.GetSilentAreaShowInfo() : null;
				this.Panel.CreateAndShow("UiItem_HoverTipsC", item, silentAreaInfo);
				return;
			}
			this.Panel.EndShow();
		}

		// Token: 0x0603E76B RID: 255851 RVA: 0x00FF6F18 File Offset: 0x00FF5118
		private void OnToggleSilentAreaInfoView()
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

		// Token: 0x04023039 RID: 143417
		[Nullable(2)]
		private SilentAreaInfoPanel Panel;

		// Token: 0x0402303A RID: 143418
		private long TreeIncId;

		// Token: 0x0402303B RID: 143419
		[Nullable(2)]
		private BaseBehaviorTree Tree;

		// Token: 0x0200C1B8 RID: 49592
		private enum EVisibleReason
		{
			// Token: 0x0403BA4C RID: 244300
			Default = 1
		}

		// Token: 0x0200C1B9 RID: 49593
		private enum EChildComponent
		{
			// Token: 0x0403BA4E RID: 244302
			Toggle,
			// Token: 0x0403BA4F RID: 244303
			PanelNode
		}
	}
}
