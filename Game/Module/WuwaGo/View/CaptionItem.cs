using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.WuwaGo.Controller;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.View
{
	// Token: 0x02004ABD RID: 19133
	public class CaptionItem : UiPanelBase
	{
		// Token: 0x06031E20 RID: 204320 RVA: 0x00C7B838 File Offset: 0x00C79A38
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
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnHelpInfoButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnCloseButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06031E21 RID: 204321 RVA: 0x00C7B944 File Offset: 0x00C79B44
		protected override UniTask OnBeforeStartAsync()
		{
			CaptionItem.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CaptionItem.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031E22 RID: 204322 RVA: 0x00C7B987 File Offset: 0x00C79B87
		private void OnHelpInfoButtonClick()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(WuWaGoGlobal.Setting.HelpId);
		}

		// Token: 0x06031E23 RID: 204323 RVA: 0x00C7B99D File Offset: 0x00C79B9D
		private void OnCloseButtonClick()
		{
			if (ControllerBase<WuWaGoController>.Instance.IsDamageBatchActive())
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WuWaGoPauseView, null, null);
		}

		// Token: 0x06031E24 RID: 204324 RVA: 0x00C7B9BD File Offset: 0x00C79BBD
		public void SetCloseButtonInteractive(bool interactive)
		{
			UUIButtonComponent button = base.GetButton(3);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(interactive);
		}

		// Token: 0x06031E25 RID: 204325 RVA: 0x00C7B9D4 File Offset: 0x00C79BD4
		public void SetRightTopButtonsVisible(bool visible)
		{
			UUIButtonComponent button = base.GetButton(3);
			if (button == null)
			{
				return;
			}
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(visible);
		}

		// Token: 0x0200AB1A RID: 43802
		private enum EViewComponent
		{
			// Token: 0x040353F1 RID: 218097
			SpriteTitleIcon,
			// Token: 0x040353F2 RID: 218098
			TitleText,
			// Token: 0x040353F3 RID: 218099
			HelpInfoButton,
			// Token: 0x040353F4 RID: 218100
			CloseButton
		}
	}
}
