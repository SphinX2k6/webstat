using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.KeySettingsView
{
	// Token: 0x020057C1 RID: 22465
	[NullableContext(1)]
	[Nullable(0)]
	public class ChangeModeTipsView : UiViewBase
	{
		// Token: 0x0603919D RID: 233885 RVA: 0x00E78B9A File Offset: 0x00E76D9A
		public ChangeModeTipsView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603919E RID: 233886 RVA: 0x00E78BBC File Offset: 0x00E76DBC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIInteractionGroup)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIInteractionGroup)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(8, new Action(this.OnConfirmButtonClicked)),
				new ValueTuple<int, Delegate>(2, new Action(this.OnLeftButtonClicked)),
				new ValueTuple<int, Delegate>(4, new Action(this.OnRightButtonClicked))
			};
		}

		// Token: 0x0603919F RID: 233887 RVA: 0x00E78CF0 File Offset: 0x00E76EF0
		protected override UniTask OnBeforeStartAsync()
		{
			ChangeModeTipsView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ChangeModeTipsView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060391A0 RID: 233888 RVA: 0x00E78D33 File Offset: 0x00E76F33
		protected override void OnStart()
		{
			this.Refresh();
		}

		// Token: 0x060391A1 RID: 233889 RVA: 0x00E78D3B File Offset: 0x00E76F3B
		protected override void OnBeforeDestroy()
		{
			this.CaptionItem = null;
			this.SelectedRowView = null;
			this.ChangeModeRowViewList.Clear();
		}

		// Token: 0x060391A2 RID: 233890 RVA: 0x00E78D56 File Offset: 0x00E76F56
		private void Refresh()
		{
			this.RefreshGroupName();
			this.RefreshDefaultSelected();
			this.RefreshLeftAndRightButtonEnable();
			this.RefreshRowView();
		}

		// Token: 0x060391A3 RID: 233891 RVA: 0x00E78D70 File Offset: 0x00E76F70
		private void RefreshGroupName()
		{
			if (this.ChangeKeyModeData == null)
			{
				return;
			}
			ChangeKeyModeGroupData changeKeyModeGroupData = this.ChangeKeyModeData.GetChangeKeyModeGroupDataList()[this.GroupIndex];
			if (changeKeyModeGroupData == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), changeKeyModeGroupData.GroupName, Array.Empty<object>());
		}

		// Token: 0x060391A4 RID: 233892 RVA: 0x00E78DC0 File Offset: 0x00E76FC0
		private void RefreshDefaultSelected()
		{
			ChangeModeRowView selectedRowView = this.SelectedRowView;
			if (selectedRowView != null)
			{
				selectedRowView.SetSelected(false);
			}
			if (this.ChangeKeyModeData == null)
			{
				return;
			}
			if (this.ChangeKeyModeData.GetChangeKeyModeGroupDataList()[this.GroupIndex] == null)
			{
				return;
			}
			int valueOrDefault = this.EditRowIndexMap.GetValueOrDefault(this.GroupIndex, 0);
			ChangeModeRowView changeModeRowView = this.ChangeModeRowViewList[valueOrDefault];
			this.SelectedRowView = changeModeRowView;
			if (changeModeRowView != null)
			{
				changeModeRowView.SetSelected(true);
			}
		}

		// Token: 0x060391A5 RID: 233893 RVA: 0x00E78E34 File Offset: 0x00E77034
		public void RefreshLeftAndRightButtonEnable()
		{
			if (this.ChangeKeyModeData == null)
			{
				return;
			}
			int maxGroupIndex = this.ChangeKeyModeData.GetMaxGroupIndex();
			UUIInteractionGroup interactionGroup = base.GetInteractionGroup(3);
			UUIInteractionGroup interactionGroup2 = base.GetInteractionGroup(5);
			bool flag = this.GroupIndex > 0;
			bool flag2 = this.GroupIndex < maxGroupIndex;
			if (interactionGroup.GetInteractable() != flag)
			{
				interactionGroup.SetInteractable(flag);
			}
			if (interactionGroup2.GetInteractable() != flag2)
			{
				interactionGroup2.SetInteractable(flag2);
			}
		}

		// Token: 0x060391A6 RID: 233894 RVA: 0x00E78EA0 File Offset: 0x00E770A0
		public void RefreshRowView()
		{
			if (this.ChangeKeyModeData == null)
			{
				return;
			}
			ChangeKeyModeGroupData changeKeyModeGroupData = this.ChangeKeyModeData.GetChangeKeyModeGroupDataList()[this.GroupIndex];
			if (changeKeyModeGroupData == null)
			{
				return;
			}
			IReadOnlyList<ChangeKeyModeRowData> changeKeyModeRowDataList = changeKeyModeGroupData.GetChangeKeyModeRowDataList();
			for (int i = 0; i < this.ChangeModeRowViewList.Count; i++)
			{
				ChangeModeRowView changeModeRowView = this.ChangeModeRowViewList[i];
				ChangeKeyModeRowData changeKeyModeRowData = changeKeyModeRowDataList[i];
				changeModeRowView.Refresh(changeKeyModeRowData);
			}
		}

		// Token: 0x060391A7 RID: 233895 RVA: 0x00E78F08 File Offset: 0x00E77108
		private void OnCloseButtonClicked()
		{
			base.CloseMe(null);
		}

		// Token: 0x060391A8 RID: 233896 RVA: 0x00E78F11 File Offset: 0x00E77111
		private void OnConfirmButtonClicked()
		{
			ChangeModeRowView selectedRowView = this.SelectedRowView;
			if (((selectedRowView != null) ? selectedRowView.ChangeKeyModeRowData : null) == null)
			{
				base.CloseMe(null);
				return;
			}
			if (this.OnConfirmCallback != null)
			{
				this.OnConfirmCallback(this.EditRowIndexMap);
			}
			base.CloseMe(null);
		}

		// Token: 0x060391A9 RID: 233897 RVA: 0x00E78F50 File Offset: 0x00E77150
		private void OnLeftButtonClicked()
		{
			int num = Math.Max(this.GroupIndex - 1, 0);
			if (num == this.GroupIndex)
			{
				return;
			}
			this.GroupIndex = num;
			this.Refresh();
		}

		// Token: 0x060391AA RID: 233898 RVA: 0x00E78F84 File Offset: 0x00E77184
		private void OnRightButtonClicked()
		{
			int maxGroupIndex = this.ChangeKeyModeData.GetMaxGroupIndex();
			int num = Math.Min(this.GroupIndex + 1, maxGroupIndex);
			if (num == this.GroupIndex)
			{
				return;
			}
			this.GroupIndex = num;
			this.Refresh();
		}

		// Token: 0x060391AB RID: 233899 RVA: 0x00E78FC4 File Offset: 0x00E771C4
		private void OnSelectedRowView(ChangeModeRowView changeModeRowView)
		{
			ChangeKeyModeRowData changeKeyModeRowData = changeModeRowView.ChangeKeyModeRowData;
			if (changeKeyModeRowData == null)
			{
				return;
			}
			ChangeModeRowView selectedRowView = this.SelectedRowView;
			if (selectedRowView != null)
			{
				selectedRowView.SetSelected(false);
			}
			this.SelectedRowView = changeModeRowView;
			this.EditRowIndexMap[this.GroupIndex] = changeKeyModeRowData.Index;
		}

		// Token: 0x0402081B RID: 133147
		[Nullable(2)]
		private ChangeKeyModeData ChangeKeyModeData;

		// Token: 0x0402081C RID: 133148
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0402081D RID: 133149
		private int GroupIndex;

		// Token: 0x0402081E RID: 133150
		private readonly Dictionary<int, int> EditRowIndexMap = new Dictionary<int, int>();

		// Token: 0x0402081F RID: 133151
		private readonly List<ChangeModeRowView> ChangeModeRowViewList = new List<ChangeModeRowView>();

		// Token: 0x04020820 RID: 133152
		[Nullable(2)]
		private ChangeModeRowView SelectedRowView;

		// Token: 0x04020821 RID: 133153
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<Dictionary<int, int>> OnConfirmCallback;

		// Token: 0x0200B840 RID: 47168
		[NullableContext(0)]
		public class EChildType
		{
			// Token: 0x04038FD7 RID: 233431
			public const int CaptionItem = 0;

			// Token: 0x04038FD8 RID: 233432
			public const int GroupNameText = 1;

			// Token: 0x04038FD9 RID: 233433
			public const int LeftButton = 2;

			// Token: 0x04038FDA RID: 233434
			public const int LeftButtonInteractionGroup = 3;

			// Token: 0x04038FDB RID: 233435
			public const int RightButton = 4;

			// Token: 0x04038FDC RID: 233436
			public const int RightButtonInteractionGroup = 5;

			// Token: 0x04038FDD RID: 233437
			public const int RowVerticalItem = 6;

			// Token: 0x04038FDE RID: 233438
			public const int ChangeModeRowItem = 7;

			// Token: 0x04038FDF RID: 233439
			public const int ConfirmButton = 8;
		}
	}
}
