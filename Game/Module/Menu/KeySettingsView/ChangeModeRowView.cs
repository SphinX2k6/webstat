using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.KeySettingsView
{
	// Token: 0x020057C0 RID: 22464
	public class ChangeModeRowView : UiPanelBase
	{
		// Token: 0x06039193 RID: 233875 RVA: 0x00E789A4 File Offset: 0x00E76BA4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText))
			};
		}

		// Token: 0x06039194 RID: 233876 RVA: 0x00E78A14 File Offset: 0x00E76C14
		protected override void OnStart()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChanged));
		}

		// Token: 0x06039195 RID: 233877 RVA: 0x00E78A38 File Offset: 0x00E76C38
		protected override void OnBeforeDestroy()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.OnStateChange.Clear();
			}
			this.OnSelected = null;
			this.ChangeKeyModeRowData = null;
		}

		// Token: 0x06039196 RID: 233878 RVA: 0x00E78A5F File Offset: 0x00E76C5F
		[NullableContext(1)]
		public void Refresh(ChangeKeyModeRowData changeKeyModeRowData)
		{
			this.ChangeKeyModeRowData = changeKeyModeRowData;
			this.RefreshRawSprite();
			this.RefreshDescription();
		}

		// Token: 0x06039197 RID: 233879 RVA: 0x00E78A74 File Offset: 0x00E76C74
		private void RefreshRawSprite()
		{
			if (this.ChangeKeyModeRowData == null)
			{
				return;
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(this.ChangeKeyModeRowData.SpriteResourceId);
			this.SetSpriteByPath(resourcePath, base.GetSprite(1), false, null, null);
		}

		// Token: 0x06039198 RID: 233880 RVA: 0x00E78ABC File Offset: 0x00E76CBC
		private void RefreshDescription()
		{
			if (this.ChangeKeyModeRowData == null)
			{
				return;
			}
			UUIText text = base.GetText(2);
			UUIText text2 = base.GetText(3);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, this.ChangeKeyModeRowData.DescriptionA, this.ChangeKeyModeRowData.DescriptionParametersA ?? Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, this.ChangeKeyModeRowData.DescriptionB, this.ChangeKeyModeRowData.DescriptionParametersB ?? Array.Empty<object>());
		}

		// Token: 0x06039199 RID: 233881 RVA: 0x00E78B36 File Offset: 0x00E76D36
		private void OnToggleStateChanged(EToggleState state)
		{
			if (this.ChangeKeyModeRowData == null)
			{
				return;
			}
			if (state != EToggleState.ETT_Checked)
			{
				return;
			}
			Action<ChangeModeRowView> onSelected = this.OnSelected;
			if (onSelected == null)
			{
				return;
			}
			onSelected(this);
		}

		// Token: 0x0603919A RID: 233882 RVA: 0x00E78B57 File Offset: 0x00E76D57
		[NullableContext(1)]
		public void BindOnSelected(Action<ChangeModeRowView> onSelected)
		{
			this.OnSelected = onSelected;
		}

		// Token: 0x0603919B RID: 233883 RVA: 0x00E78B60 File Offset: 0x00E76D60
		public void SetSelected(bool bSelected)
		{
			if (bSelected)
			{
				UUIExtendToggle extendToggle = base.GetExtendToggle(0);
				if (extendToggle == null)
				{
					return;
				}
				extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
				return;
			}
			else
			{
				UUIExtendToggle extendToggle2 = base.GetExtendToggle(0);
				if (extendToggle2 == null)
				{
					return;
				}
				extendToggle2.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
				return;
			}
		}

		// Token: 0x04020819 RID: 133145
		[Nullable(2)]
		public ChangeKeyModeRowData ChangeKeyModeRowData;

		// Token: 0x0402081A RID: 133146
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<ChangeModeRowView> OnSelected;

		// Token: 0x0200B83F RID: 47167
		public class EChildType
		{
			// Token: 0x04038FD3 RID: 233427
			public const int RowToggle = 0;

			// Token: 0x04038FD4 RID: 233428
			public const int RowSprite = 1;

			// Token: 0x04038FD5 RID: 233429
			public const int TextA = 2;

			// Token: 0x04038FD6 RID: 233430
			public const int TextB = 3;
		}
	}
}
