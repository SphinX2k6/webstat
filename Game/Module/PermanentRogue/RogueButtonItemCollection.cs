using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x0200568A RID: 22154
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueButtonItemCollection : UiPanelBase
	{
		// Token: 0x060386F6 RID: 231158 RVA: 0x00E4B550 File Offset: 0x00E49750
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClick))
			};
		}

		// Token: 0x060386F7 RID: 231159 RVA: 0x00E4B610 File Offset: 0x00E49810
		public void BindRedDot(ERedDotName redDotName, int? uid = null)
		{
			this.RedDotName = new ERedDotName?(redDotName);
			UUIItem item = base.GetItem(3);
			ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, item, null, uid.GetValueOrDefault());
		}

		// Token: 0x060386F8 RID: 231160 RVA: 0x00E4B648 File Offset: 0x00E49848
		public void UnBindRedDot()
		{
			if (this.RedDotName == null)
			{
				return;
			}
			UUIItem item = base.GetItem(3);
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, item, 0);
		}

		// Token: 0x060386F9 RID: 231161 RVA: 0x00E4B684 File Offset: 0x00E49884
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

		// Token: 0x060386FA RID: 231162 RVA: 0x00E4B6B7 File Offset: 0x00E498B7
		public void SetName(string name)
		{
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText(name, true);
		}

		// Token: 0x060386FB RID: 231163 RVA: 0x00E4B6CC File Offset: 0x00E498CC
		public void SetNum(string num)
		{
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			text.SetText(num, true);
		}

		// Token: 0x060386FC RID: 231164 RVA: 0x00E4B6E1 File Offset: 0x00E498E1
		public void SetOnClickCall(Action cb)
		{
			this.OnClickCall = cb;
		}

		// Token: 0x060386FD RID: 231165 RVA: 0x00E4B6EA File Offset: 0x00E498EA
		public void SetButtonDone(bool isDone)
		{
			UUIItem item = base.GetItem(5);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(isDone);
		}

		// Token: 0x060386FE RID: 231166 RVA: 0x00E4B6FE File Offset: 0x00E498FE
		private void OnClick()
		{
			this.OnClickCall();
		}

		// Token: 0x04020350 RID: 131920
		private Action OnClickCall = delegate()
		{
		};

		// Token: 0x04020351 RID: 131921
		private ERedDotName? RedDotName;
	}
}
