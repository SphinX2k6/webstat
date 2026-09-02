using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005688 RID: 22152
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueButtonItemA : UiPanelBase
	{
		// Token: 0x060386EC RID: 231148 RVA: 0x00E4B368 File Offset: 0x00E49568
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClick))
			};
		}

		// Token: 0x060386ED RID: 231149 RVA: 0x00E4B414 File Offset: 0x00E49614
		public void BindRedDot(ERedDotName redDotName, int? uid = null)
		{
			this.RedDotName = new ERedDotName?(redDotName);
			UUIItem item = base.GetItem(3);
			ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, item, null, uid.GetValueOrDefault());
		}

		// Token: 0x060386EE RID: 231150 RVA: 0x00E4B44C File Offset: 0x00E4964C
		public void UnBindRedDot()
		{
			if (this.RedDotName == null)
			{
				return;
			}
			UUIItem item = base.GetItem(3);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, item, 0);
		}

		// Token: 0x060386EF RID: 231151 RVA: 0x00E4B488 File Offset: 0x00E49688
		public void SetNameById(string name)
		{
			TextConfig instance = ConfigBase<TextConfig>.Instance;
			string newText = (instance != null) ? instance.GetTextById(name) : null;
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText(newText, true);
		}

		// Token: 0x060386F0 RID: 231152 RVA: 0x00E4B4BB File Offset: 0x00E496BB
		public void SetName(string name)
		{
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText(name, true);
		}

		// Token: 0x060386F1 RID: 231153 RVA: 0x00E4B4D0 File Offset: 0x00E496D0
		public void SetNum(string num)
		{
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			text.SetText(num, true);
		}

		// Token: 0x060386F2 RID: 231154 RVA: 0x00E4B4E5 File Offset: 0x00E496E5
		public void SetLimitTime(string time)
		{
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.SetUIActive(true);
			}
			UUIText text2 = base.GetText(4);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(time, true);
		}

		// Token: 0x060386F3 RID: 231155 RVA: 0x00E4B50D File Offset: 0x00E4970D
		public void SetOnClickCall(Action cb)
		{
			this.OnClickCall = cb;
		}

		// Token: 0x060386F4 RID: 231156 RVA: 0x00E4B516 File Offset: 0x00E49716
		private void OnClick()
		{
			this.OnClickCall();
		}

		// Token: 0x04020347 RID: 131911
		private Action OnClickCall = delegate()
		{
		};

		// Token: 0x04020348 RID: 131912
		private ERedDotName? RedDotName;
	}
}
