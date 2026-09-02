using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.KeySettingsView
{
	// Token: 0x020057CE RID: 22478
	[NullableContext(2)]
	[Nullable(0)]
	public class RepeatKeyTipsView : UiViewBase
	{
		// Token: 0x0603923A RID: 234042 RVA: 0x00E7CB57 File Offset: 0x00E7AD57
		[NullableContext(1)]
		public RepeatKeyTipsView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603923B RID: 234043 RVA: 0x00E7CB60 File Offset: 0x00E7AD60
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(6, new Action(this.OnConfirmButtonClicked)),
				new ValueTuple<int, Delegate>(7, new Action(this.OnCancelButtonClicked))
			};
		}

		// Token: 0x0603923C RID: 234044 RVA: 0x00E7CC63 File Offset: 0x00E7AE63
		private void OnConfirmButtonClicked()
		{
			this.IsConfirm = true;
			base.CloseMe(null);
		}

		// Token: 0x0603923D RID: 234045 RVA: 0x00E7CC73 File Offset: 0x00E7AE73
		private void OnCancelButtonClicked()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603923E RID: 234046 RVA: 0x00E7CC7C File Offset: 0x00E7AE7C
		protected override void OnStart()
		{
			IRepeatKeyInfo repeatKeyInfo = this.OpenParam as IRepeatKeyInfo;
			this.CurrentKeySettingRowData = repeatKeyInfo.CurrentKeySettingRowData;
			this.RepeatKeySettingRowData = repeatKeyInfo.RepeatKeySettingRowData;
			this.InputControllerType = repeatKeyInfo.InputControllerType;
			this.OnCloseCallback = repeatKeyInfo.OnCloseCallback;
			string settingName = this.CurrentKeySettingRowData.GetSettingName();
			string currentKeyNameRichText = this.CurrentKeySettingRowData.GetCurrentKeyNameRichText(this.InputControllerType, "+");
			string settingName2 = this.RepeatKeySettingRowData.GetSettingName();
			string currentKeyNameRichText2 = this.RepeatKeySettingRowData.GetCurrentKeyNameRichText(this.InputControllerType, "+");
			if (StringUtils.IsBlank(currentKeyNameRichText))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "NoneText", Array.Empty<object>());
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "NoneText", Array.Empty<object>());
			}
			else
			{
				UUIText text = base.GetText(1);
				if (text != null)
				{
					text.SetText(currentKeyNameRichText, true);
				}
				UUIText text2 = base.GetText(5);
				if (text2 != null)
				{
					text2.SetText(currentKeyNameRichText, true);
				}
			}
			UUIText text3 = base.GetText(4);
			if (text3 != null)
			{
				text3.SetText(currentKeyNameRichText2, true);
			}
			UUIText text4 = base.GetText(2);
			if (text4 != null)
			{
				text4.SetText(currentKeyNameRichText2, true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), settingName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), settingName2, Array.Empty<object>());
		}

		// Token: 0x0603923F RID: 234047 RVA: 0x00E7CDCC File Offset: 0x00E7AFCC
		protected override void OnBeforeDestroy()
		{
			if (this.OnCloseCallback != null)
			{
				this.OnCloseCallback(this.IsConfirm);
			}
			this.CurrentKeySettingRowData = null;
			this.RepeatKeySettingRowData = null;
			this.InputControllerType = EInputControllerType.None;
			this.OnCloseCallback = null;
		}

		// Token: 0x04020857 RID: 133207
		private KeySettingRowData CurrentKeySettingRowData;

		// Token: 0x04020858 RID: 133208
		private KeySettingRowData RepeatKeySettingRowData;

		// Token: 0x04020859 RID: 133209
		private EInputControllerType InputControllerType;

		// Token: 0x0402085A RID: 133210
		private Action<bool> OnCloseCallback;

		// Token: 0x0402085B RID: 133211
		private bool IsConfirm;

		// Token: 0x0200B855 RID: 47189
		[NullableContext(0)]
		public class EChildType
		{
			// Token: 0x04039046 RID: 233542
			public const int CurrentInputText = 0;

			// Token: 0x04039047 RID: 233543
			public const int CurrentFromKeyNameText = 1;

			// Token: 0x04039048 RID: 233544
			public const int CurrentToKeyNameText = 2;

			// Token: 0x04039049 RID: 233545
			public const int RepeatInputText = 3;

			// Token: 0x0403904A RID: 233546
			public const int RepeatFromKeyNameText = 4;

			// Token: 0x0403904B RID: 233547
			public const int RepeatToKeyNameText = 5;

			// Token: 0x0403904C RID: 233548
			public const int ConfirmButton = 6;

			// Token: 0x0403904D RID: 233549
			public const int CancelButton = 7;
		}
	}
}
