using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CEA RID: 19690
	public class ClickBtnReleaseComponent : HotKeyComponent
	{
		// Token: 0x060333CB RID: 209867 RVA: 0x00CD4575 File Offset: 0x00CD2775
		public ClickBtnReleaseComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060333CC RID: 209868 RVA: 0x00CD457E File Offset: 0x00CD277E
		protected override void OnRelease(HotKeyMap config)
		{
			this.ClickButton(config.BindButtonTag);
		}

		// Token: 0x060333CD RID: 209869 RVA: 0x00CD458D File Offset: 0x00CD278D
		[NullableContext(1)]
		private void ClickButton(string tag)
		{
			if (tag == "tag1")
			{
				ControllerBase<UiNavigationNewController>.Instance.HotKeyCloseView();
				return;
			}
			ControllerBase<UiNavigationNewController>.Instance.ClickButton(tag);
		}
	}
}
