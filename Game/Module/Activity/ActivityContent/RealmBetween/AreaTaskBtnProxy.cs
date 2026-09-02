using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x0200655A RID: 25946
	[NullableContext(1)]
	[Nullable(0)]
	public class AreaTaskBtnProxy : UiPanelBase
	{
		// Token: 0x06040D43 RID: 265539 RVA: 0x0109FF98 File Offset: 0x0109E198
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClick))
			};
		}

		// Token: 0x06040D44 RID: 265540 RVA: 0x0109FFFF File Offset: 0x0109E1FF
		private void OnClick()
		{
			Action clickFn = this.ClickFn;
			if (clickFn == null)
			{
				return;
			}
			clickFn();
		}

		// Token: 0x06040D45 RID: 265541 RVA: 0x010A0011 File Offset: 0x0109E211
		public void SetClickFunction(Action fn)
		{
			this.ClickFn = fn;
		}

		// Token: 0x06040D46 RID: 265542 RVA: 0x010A001A File Offset: 0x0109E21A
		public void SetText(string text)
		{
			UUIText text2 = base.GetText(1);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(text, true);
		}

		// Token: 0x06040D47 RID: 265543 RVA: 0x010A002F File Offset: 0x0109E22F
		public void SetTextById(string textId, params object[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, args);
		}

		// Token: 0x06040D48 RID: 265544 RVA: 0x010A0044 File Offset: 0x0109E244
		public void SetBtnUiActive(bool value)
		{
			base.SetUiActive(value);
		}

		// Token: 0x040245FA RID: 148986
		[Nullable(2)]
		private Action ClickFn;
	}
}
