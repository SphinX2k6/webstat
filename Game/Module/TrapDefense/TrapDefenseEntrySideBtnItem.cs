using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E0D RID: 19981
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseEntrySideBtnItem : UiPanelBase
	{
		// Token: 0x06033AB5 RID: 211637 RVA: 0x00CE9BCC File Offset: 0x00CE7DCC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033AB6 RID: 211638 RVA: 0x00CE9CB4 File Offset: 0x00CE7EB4
		protected override void OnBeforeDestroy()
		{
			this.UnBindRedDot();
		}

		// Token: 0x06033AB7 RID: 211639 RVA: 0x00CE9CBC File Offset: 0x00CE7EBC
		private void ButtonClick()
		{
			if (this.ButtonFunction != null)
			{
				this.ButtonFunction();
			}
		}

		// Token: 0x06033AB8 RID: 211640 RVA: 0x00CE9CD4 File Offset: 0x00CE7ED4
		public void SetText(string text)
		{
			UUIText text2 = base.GetText(1);
			if (text2 != null)
			{
				text2.SetText(text, true);
			}
		}

		// Token: 0x06033AB9 RID: 211641 RVA: 0x00CE9CF4 File Offset: 0x00CE7EF4
		public void SetProgressText(string text)
		{
			UUIText text2 = base.GetText(3);
			if (text2 != null)
			{
				text2.SetText(text, true);
			}
		}

		// Token: 0x06033ABA RID: 211642 RVA: 0x00CE9D14 File Offset: 0x00CE7F14
		public void SetProgressTextWithLabel(string textId, params object[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), textId, args);
		}

		// Token: 0x06033ABB RID: 211643 RVA: 0x00CE9D29 File Offset: 0x00CE7F29
		public void SetLocalTextNew(string textId, params object[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, args);
		}

		// Token: 0x06033ABC RID: 211644 RVA: 0x00CE9D3E File Offset: 0x00CE7F3E
		public void TrySetLocalTextNew(string textId, params object[] args)
		{
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), textId, args);
		}

		// Token: 0x06033ABD RID: 211645 RVA: 0x00CE9D53 File Offset: 0x00CE7F53
		public void SetShowText(string text)
		{
			base.GetText(1).ShowTextNew(text);
		}

		// Token: 0x06033ABE RID: 211646 RVA: 0x00CE9D62 File Offset: 0x00CE7F62
		public void SetEnableClick(bool state)
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(state);
		}

		// Token: 0x06033ABF RID: 211647 RVA: 0x00CE9D76 File Offset: 0x00CE7F76
		public void SetFunction(Action buttonFunction)
		{
			this.ButtonFunction = buttonFunction;
		}

		// Token: 0x06033AC0 RID: 211648 RVA: 0x00CE9D7F File Offset: 0x00CE7F7F
		public void SetRedDotVisible(bool bVisible)
		{
			base.GetItem(2).SetUIActive(bVisible);
		}

		// Token: 0x06033AC1 RID: 211649 RVA: 0x00CE9D90 File Offset: 0x00CE7F90
		public void BindRedDot(ERedDotName redDotName, int uId = 0)
		{
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			this.UnBindRedDot();
			this.RedDotName = new ERedDotName?(redDotName);
			if (this.RedDotName != null)
			{
				ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, item, null, uId);
			}
		}

		// Token: 0x06033AC2 RID: 211650 RVA: 0x00CE9DD6 File Offset: 0x00CE7FD6
		public void UnBindRedDot()
		{
			if (this.RedDotName != null)
			{
				ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, base.GetItem(2), 0);
				this.RedDotName = null;
			}
		}

		// Token: 0x0401DED6 RID: 122582
		private ERedDotName? RedDotName;

		// Token: 0x0401DED7 RID: 122583
		[Nullable(2)]
		private Action ButtonFunction;

		// Token: 0x0200AD81 RID: 44417
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04035E2A RID: 220714
			public const int Button = 0;

			// Token: 0x04035E2B RID: 220715
			public const int ButtonText = 1;

			// Token: 0x04035E2C RID: 220716
			public const int RedDot = 2;

			// Token: 0x04035E2D RID: 220717
			public const int TextProgress = 3;
		}
	}
}
