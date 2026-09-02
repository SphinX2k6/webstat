using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SlidingBlocks.View
{
	// Token: 0x02004F0D RID: 20237
	public class CaptionItem : UiPanelBase
	{
		// Token: 0x060344E5 RID: 214245 RVA: 0x00D167D0 File Offset: 0x00D149D0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action(this.OnHelpInfoButtonClick)),
				new ValueTuple<int, Delegate>(3, new Action(this.OnCloseButtonClick))
			};
		}

		// Token: 0x060344E6 RID: 214246 RVA: 0x00D1687C File Offset: 0x00D14A7C
		protected override UniTask OnBeforeStartAsync()
		{
			CaptionItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CaptionItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060344E7 RID: 214247 RVA: 0x00D168BF File Offset: 0x00D14ABF
		private void OnHelpInfoButtonClick()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(581);
		}

		// Token: 0x060344E8 RID: 214248 RVA: 0x00D168D0 File Offset: 0x00D14AD0
		private void OnCloseButtonClick()
		{
			ControllerBase<SlidingBlocksController>.Instance.SendGameEnd(SlidingBlocksDefine.EGameEndReason.ClickClose);
		}

		// Token: 0x0401E2C9 RID: 123593
		private const int TETRISGAME_HELP_ID = 581;

		// Token: 0x0200AF33 RID: 44851
		private enum EViewComponent
		{
			// Token: 0x040365E9 RID: 222697
			SpriteTitleIcon,
			// Token: 0x040365EA RID: 222698
			TitleText,
			// Token: 0x040365EB RID: 222699
			HelpInfoButton,
			// Token: 0x040365EC RID: 222700
			CloseButton
		}
	}
}
