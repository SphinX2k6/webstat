using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D72 RID: 19826
	[NullableContext(1)]
	[Nullable(0)]
	public class TermExplanationComponent : HotKeyComponent
	{
		// Token: 0x060335D9 RID: 210393 RVA: 0x00CD8CF9 File Offset: 0x00CD6EF9
		public TermExplanationComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335DA RID: 210394 RVA: 0x00CD8D02 File Offset: 0x00CD6F02
		protected override void OnPress(HotKeyMap config)
		{
			ControllerBase<TermExplanationController>.Instance.OpenTermExplanationViewDirectly();
		}

		// Token: 0x060335DB RID: 210395 RVA: 0x00CD8D0E File Offset: 0x00CD6F0E
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			this.RefreshVisible();
		}

		// Token: 0x060335DC RID: 210396 RVA: 0x00CD8D16 File Offset: 0x00CD6F16
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<IReadOnlyList<int>>(EEventName.OnTermExplanationRegisteredTextContentChange, new Action<IReadOnlyList<int>>(this.OnTextChange));
		}

		// Token: 0x060335DD RID: 210397 RVA: 0x00CD8D34 File Offset: 0x00CD6F34
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnTermExplanationRegisteredTextContentChange, new Action<IReadOnlyList<int>>(this.OnTextChange));
		}

		// Token: 0x060335DE RID: 210398 RVA: 0x00CD8D54 File Offset: 0x00CD6F54
		private void RefreshVisible()
		{
			bool isActive = ControllerBase<TermExplanationController>.Instance.HasAnyTermInCurrentTexts();
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, isActive, false);
		}

		// Token: 0x060335DF RID: 210399 RVA: 0x00CD8D75 File Offset: 0x00CD6F75
		private void OnTextChange(IReadOnlyList<int> readOnlyList)
		{
			this.RefreshVisible();
		}
	}
}
