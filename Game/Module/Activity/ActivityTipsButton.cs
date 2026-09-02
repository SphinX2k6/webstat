using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity
{
	// Token: 0x020061DA RID: 25050
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityTipsButton : UiPanelBase
	{
		// Token: 0x0603F36F RID: 258927 RVA: 0x0103A16B File Offset: 0x0103836B
		public ActivityTipsButton()
		{
			this.PermanentActivityHelpId = ConfigCommonParamById.GetIntConfig("PermanentActivityHelpId");
			this.ButtonFunction = new Action(this.PermanentActivityHelp);
		}

		// Token: 0x0603F370 RID: 258928 RVA: 0x0103A198 File Offset: 0x01038398
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603F371 RID: 258929 RVA: 0x0103A25F File Offset: 0x0103845F
		private void PermanentActivityHelp()
		{
			if (this.PermanentActivityHelpId != null)
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(this.PermanentActivityHelpId.Value);
			}
		}

		// Token: 0x0603F372 RID: 258930 RVA: 0x0103A283 File Offset: 0x01038483
		protected override void OnBeforeDestroy()
		{
			this.ButtonFunction = null;
		}

		// Token: 0x0603F373 RID: 258931 RVA: 0x0103A28C File Offset: 0x0103848C
		private void ButtonClick()
		{
			Action buttonFunction = this.ButtonFunction;
			if (buttonFunction == null)
			{
				return;
			}
			buttonFunction();
		}

		// Token: 0x0603F374 RID: 258932 RVA: 0x0103A29E File Offset: 0x0103849E
		public void SetFunction(Action buttonFunction)
		{
			this.ButtonFunction = buttonFunction;
		}

		// Token: 0x0603F375 RID: 258933 RVA: 0x0103A2A7 File Offset: 0x010384A7
		public void SetDefaultFunction()
		{
			this.ButtonFunction = new Action(this.PermanentActivityHelp);
		}

		// Token: 0x0603F376 RID: 258934 RVA: 0x0103A2BC File Offset: 0x010384BC
		public void SetText(string text)
		{
			UUIText text2 = base.GetText(2);
			if (text2 != null)
			{
				text2.SetText(text, true);
			}
		}

		// Token: 0x0603F377 RID: 258935 RVA: 0x0103A2DC File Offset: 0x010384DC
		public void SetLocalTextNew(string textId, params object[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textId, args);
		}

		// Token: 0x040237EC RID: 145388
		private int? PermanentActivityHelpId;

		// Token: 0x040237ED RID: 145389
		[Nullable(2)]
		private Action ButtonFunction;

		// Token: 0x0200C31D RID: 49949
		[NullableContext(0)]
		private class EButtonItemDefine
		{
			// Token: 0x0403C23B RID: 246331
			public const int Button = 0;

			// Token: 0x0403C23C RID: 246332
			public const int Sprite = 1;

			// Token: 0x0403C23D RID: 246333
			public const int Text = 2;
		}
	}
}
