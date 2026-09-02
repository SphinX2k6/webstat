using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x02006982 RID: 27010
	[NullableContext(1)]
	[Nullable(0)]
	public class CyberPunkTaskTopItem : UiPanelBase
	{
		// Token: 0x06043059 RID: 274521 RVA: 0x01135D04 File Offset: 0x01133F04
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickHelp));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickBack));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604305A RID: 274522 RVA: 0x01135E0F File Offset: 0x0113400F
		public void SetOnClose(Action callback)
		{
			this.CloseCallback = callback;
		}

		// Token: 0x0604305B RID: 274523 RVA: 0x01135E18 File Offset: 0x01134018
		public void SetOnHelp(Action callback)
		{
			this.HelpCallback = callback;
		}

		// Token: 0x0604305C RID: 274524 RVA: 0x01135E21 File Offset: 0x01134021
		public void SetTitleByTextId(string textId, params string[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, args);
		}

		// Token: 0x0604305D RID: 274525 RVA: 0x01135E36 File Offset: 0x01134036
		public void SetTitleByText(string text)
		{
			UUIText text2 = base.GetText(1);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(text, true);
		}

		// Token: 0x0604305E RID: 274526 RVA: 0x01135E4C File Offset: 0x0113404C
		public void SetTitleIconByPath(string path)
		{
			this.SetSpriteByPath(path, base.GetSprite(0), false, null, null);
		}

		// Token: 0x0604305F RID: 274527 RVA: 0x01135E72 File Offset: 0x01134072
		private void OnClickHelp()
		{
			Action helpCallback = this.HelpCallback;
			if (helpCallback == null)
			{
				return;
			}
			helpCallback();
		}

		// Token: 0x06043060 RID: 274528 RVA: 0x01135E84 File Offset: 0x01134084
		private void OnClickBack()
		{
			Action closeCallback = this.CloseCallback;
			if (closeCallback == null)
			{
				return;
			}
			closeCallback();
		}

		// Token: 0x04025536 RID: 152886
		[Nullable(2)]
		private Action CloseCallback;

		// Token: 0x04025537 RID: 152887
		[Nullable(2)]
		private Action HelpCallback;

		// Token: 0x0200C930 RID: 51504
		[NullableContext(0)]
		private static class ETopItemComponent
		{
			// Token: 0x0403DE27 RID: 253479
			public const int TitleSpriteIcon = 0;

			// Token: 0x0403DE28 RID: 253480
			public const int TxtTitle = 1;

			// Token: 0x0403DE29 RID: 253481
			public const int BtnHelpInfo = 2;

			// Token: 0x0403DE2A RID: 253482
			public const int BtnBack = 3;
		}
	}
}
