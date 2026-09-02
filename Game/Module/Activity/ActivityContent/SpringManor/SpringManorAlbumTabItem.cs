using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x0200631F RID: 25375
	public class SpringManorAlbumTabItem : UiPanelBase
	{
		// Token: 0x0603FC48 RID: 261192 RVA: 0x010597AC File Offset: 0x010579AC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x0603FC49 RID: 261193 RVA: 0x0105981C File Offset: 0x01057A1C
		[NullableContext(1)]
		public void SetTitle(string title)
		{
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(title);
		}

		// Token: 0x0603FC4A RID: 261194 RVA: 0x01059830 File Offset: 0x01057A30
		public void InitProgress(int curNum, int maxNum)
		{
			this.MaxNum = maxNum;
			this.SetCurProgress(curNum);
		}

		// Token: 0x0603FC4B RID: 261195 RVA: 0x01059840 File Offset: 0x01057A40
		public void SetCurProgress(int curNum)
		{
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(curNum);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.MaxNum);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0603FC4C RID: 261196 RVA: 0x01059890 File Offset: 0x01057A90
		public void SetSelected(bool isSelected)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603FC4D RID: 261197 RVA: 0x010598AE File Offset: 0x01057AAE
		public void SetRedDotActive(bool hasRedDot)
		{
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(hasRedDot);
		}

		// Token: 0x04023CC0 RID: 146624
		private int MaxNum;
	}
}
