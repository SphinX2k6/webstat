using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.KeySettingsView
{
	// Token: 0x020057BC RID: 22460
	[NullableContext(2)]
	[Nullable(0)]
	public class ChangeActionTipsView : UiViewBase
	{
		// Token: 0x06039185 RID: 233861 RVA: 0x00E78644 File Offset: 0x00E76844
		[NullableContext(1)]
		public ChangeActionTipsView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06039186 RID: 233862 RVA: 0x00E78650 File Offset: 0x00E76850
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnConfirmButtonClicked)),
				new ValueTuple<int, Delegate>(1, new Action(this.OnCancelButtonClicked))
			};
		}

		// Token: 0x06039187 RID: 233863 RVA: 0x00E786FB File Offset: 0x00E768FB
		private void OnConfirmButtonClicked()
		{
			if (this.OnConfirmCallback != null)
			{
				this.OnConfirmCallback(this.IsRevert);
			}
			base.CloseMe(null);
		}

		// Token: 0x06039188 RID: 233864 RVA: 0x00E7871D File Offset: 0x00E7691D
		private void OnCancelButtonClicked()
		{
			base.CloseMe(null);
		}

		// Token: 0x06039189 RID: 233865 RVA: 0x00E78728 File Offset: 0x00E76928
		protected override UniTask OnBeforeStartAsync()
		{
			ChangeActionTipsView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ChangeActionTipsView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603918A RID: 233866 RVA: 0x00E7876C File Offset: 0x00E7696C
		protected override void OnStart()
		{
			IChangeActionInfo changeActionInfo = this.OpenParam as IChangeActionInfo;
			EInputControllerType inputControllerType = changeActionInfo.InputControllerType;
			this.OnConfirmCallback = changeActionInfo.OnConfirmCallback;
			this.KeySettingRowData = changeActionInfo.KeySettingRowData;
			ChangeActionRowView oneRowItem = this.OneRowItem;
			if (oneRowItem != null)
			{
				oneRowItem.Refresh(this.KeySettingRowData, inputControllerType, false);
			}
			ChangeActionRowView twoRowItem = this.TwoRowItem;
			if (twoRowItem != null)
			{
				twoRowItem.Refresh(this.KeySettingRowData, inputControllerType, true);
			}
			ChangeActionRowView oneRowItem2 = this.OneRowItem;
			if (oneRowItem2 != null)
			{
				oneRowItem2.SetSelected(true);
			}
			ChangeActionRowView oneRowItem3 = this.OneRowItem;
			if (oneRowItem3 != null)
			{
				oneRowItem3.SetActive(true);
			}
			ChangeActionRowView twoRowItem2 = this.TwoRowItem;
			if (twoRowItem2 == null)
			{
				return;
			}
			twoRowItem2.SetActive(true);
		}

		// Token: 0x0603918B RID: 233867 RVA: 0x00E7880B File Offset: 0x00E76A0B
		protected override void OnBeforeDestroy()
		{
			this.OneRowItem = null;
			this.TwoRowItem = null;
			this.OnConfirmCallback = null;
		}

		// Token: 0x0603918C RID: 233868 RVA: 0x00E78822 File Offset: 0x00E76A22
		[NullableContext(1)]
		private void OnSelected(ChangeActionRowView changeActionRowView, bool bRevert)
		{
			this.OneRowItem.SetSelected(this.OneRowItem.IsRevert == bRevert);
			this.TwoRowItem.SetSelected(this.TwoRowItem.IsRevert == bRevert);
			this.IsRevert = bRevert;
		}

		// Token: 0x04020808 RID: 133128
		private Action<bool> OnConfirmCallback;

		// Token: 0x04020809 RID: 133129
		private KeySettingRowData KeySettingRowData;

		// Token: 0x0402080A RID: 133130
		private ChangeActionRowView OneRowItem;

		// Token: 0x0402080B RID: 133131
		private ChangeActionRowView TwoRowItem;

		// Token: 0x0402080C RID: 133132
		private bool IsRevert;

		// Token: 0x0200B83D RID: 47165
		[NullableContext(0)]
		public class EChildType
		{
			// Token: 0x04038FCB RID: 233419
			public const int ConfirmButton = 0;

			// Token: 0x04038FCC RID: 233420
			public const int CancelButton = 1;

			// Token: 0x04038FCD RID: 233421
			public const int OneRowItem = 2;

			// Token: 0x04038FCE RID: 233422
			public const int TwoRowItem = 3;
		}
	}
}
