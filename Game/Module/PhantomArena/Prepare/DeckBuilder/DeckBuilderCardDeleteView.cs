using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054EA RID: 21738
	[NullableContext(1)]
	[Nullable(0)]
	public class DeckBuilderCardDeleteView : UiViewBase
	{
		// Token: 0x06037650 RID: 226896 RVA: 0x00E0E457 File Offset: 0x00E0C657
		public DeckBuilderCardDeleteView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06037651 RID: 226897 RVA: 0x00E0E478 File Offset: 0x00E0C678
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(3, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnCancelButtonClick)),
				new ValueTuple<int, Delegate>(1, new Action(this.OnConfirmButtonClick)),
				new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnPhysicalToggleClick))
			};
		}

		// Token: 0x06037652 RID: 226898 RVA: 0x00E0E554 File Offset: 0x00E0C754
		protected override UniTask OnBeforeStartAsync()
		{
			DeckBuilderCardDeleteView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DeckBuilderCardDeleteView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037653 RID: 226899 RVA: 0x00E0E597 File Offset: 0x00E0C797
		private void OnCancelButtonClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06037654 RID: 226900 RVA: 0x00E0E5A0 File Offset: 0x00E0C7A0
		private void OnConfirmButtonClick()
		{
			if (this.SelectedElementSet.Count == 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomBattle_1125", Array.Empty<object>());
				return;
			}
			base.CloseMe(null);
			this.Data.DeleteFunc(this.SelectedElementSet);
		}

		// Token: 0x06037655 RID: 226901 RVA: 0x00E0E5EC File Offset: 0x00E0C7EC
		private void OnPhysicalToggleClick(EToggleState toggleState)
		{
			if (base.GetExtendToggle(2).GetToggleState() == EToggleState.ETT_Checked)
			{
				this.SelectedElementSet.Add(ECardElement.Physical);
				return;
			}
			this.SelectedElementSet.Remove(ECardElement.Physical);
		}

		// Token: 0x06037656 RID: 226902 RVA: 0x00E0E618 File Offset: 0x00E0C818
		private DeckBuilderCardDeleteFilterItem CreateFilterItem()
		{
			return new DeckBuilderCardDeleteFilterItem
			{
				OnItemToggleStateChange = new Action<int, EToggleState>(this.OnItemToggleStateChange)
			};
		}

		// Token: 0x06037657 RID: 226903 RVA: 0x00E0E634 File Offset: 0x00E0C834
		private void OnItemToggleStateChange(int gridIndex, EToggleState state)
		{
			IDeckBuilderCardDeleteFilterItemData deckBuilderCardDeleteFilterItemData = this.FilterDataList[gridIndex];
			if (state == EToggleState.ETT_Checked)
			{
				this.SelectedElementSet.Add(deckBuilderCardDeleteFilterItemData.Element);
				return;
			}
			this.SelectedElementSet.Remove(deckBuilderCardDeleteFilterItemData.Element);
		}

		// Token: 0x0401FCDB RID: 130267
		private readonly HashSet<ECardElement> SelectedElementSet = new HashSet<ECardElement>();

		// Token: 0x0401FCDC RID: 130268
		[Nullable(2)]
		private IDeckBuilderCardDeleteViewData Data;

		// Token: 0x0401FCDD RID: 130269
		private readonly List<IDeckBuilderCardDeleteFilterItemData> FilterDataList = new List<IDeckBuilderCardDeleteFilterItemData>();

		// Token: 0x0401FCDE RID: 130270
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<DeckBuilderCardDeleteFilterItem, IDeckBuilderCardDeleteFilterItemData> FilterLayout;

		// Token: 0x0200B464 RID: 46180
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037D7A RID: 228730
			public const int CancelButton = 0;

			// Token: 0x04037D7B RID: 228731
			public const int ConfirmButton = 1;

			// Token: 0x04037D7C RID: 228732
			public const int PhysicalToggle = 2;

			// Token: 0x04037D7D RID: 228733
			public const int FilterLayout = 3;

			// Token: 0x04037D7E RID: 228734
			public const int FilterItem = 4;
		}
	}
}
