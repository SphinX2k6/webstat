using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200598C RID: 22924
	[NullableContext(1)]
	[Nullable(0)]
	public class PopupComponentFunctionButton : UiPanelBase
	{
		// Token: 0x0603A0F2 RID: 237810 RVA: 0x00EB1ED6 File Offset: 0x00EB00D6
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem))
			};
		}

		// Token: 0x0603A0F3 RID: 237811 RVA: 0x00EB1EFC File Offset: 0x00EB00FC
		protected override UniTask OnBeforeStartAsync()
		{
			PopupComponentFunctionButton.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PopupComponentFunctionButton.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A0F4 RID: 237812 RVA: 0x00EB1F40 File Offset: 0x00EB0140
		public void SetButtonTextByTextId(string textId, params string[] args)
		{
			this.ButtonItem.SetLocalTextNew(textId, args);
		}

		// Token: 0x0603A0F5 RID: 237813 RVA: 0x00EB1F5C File Offset: 0x00EB015C
		public void SetButtonFunction(Action<int> buttonFunction)
		{
			this.ButtonItem.SetFunction(buttonFunction);
		}

		// Token: 0x0603A0F6 RID: 237814 RVA: 0x00EB1F6C File Offset: 0x00EB016C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			ButtonItem buttonItem = this.ButtonItem;
			UUIItem uuiitem;
			if (buttonItem == null)
			{
				uuiitem = null;
			}
			else
			{
				UUIButtonComponent btn = buttonItem.GetBtn();
				uuiitem = ((btn != null) ? btn.RootUIComp.Get() : null);
			}
			UUIItem uuiitem2 = uuiitem;
			if (uuiitem2 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem2,
				uuiitem2
			};
		}

		// Token: 0x04020EF0 RID: 134896
		protected ButtonItem ButtonItem;
	}
}
