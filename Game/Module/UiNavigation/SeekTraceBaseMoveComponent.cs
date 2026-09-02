using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.SeekTrace;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D55 RID: 19797
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class SeekTraceBaseMoveComponent : HotKeyComponent
	{
		// Token: 0x06033589 RID: 210313 RVA: 0x00CD85B2 File Offset: 0x00CD67B2
		protected SeekTraceBaseMoveComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603358A RID: 210314
		protected abstract ESeekTraceMoveDirection GetMoveDirection();

		// Token: 0x0603358B RID: 210315 RVA: 0x00CD85BB File Offset: 0x00CD67BB
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}

		// Token: 0x0603358C RID: 210316 RVA: 0x00CD85C6 File Offset: 0x00CD67C6
		protected override void OnPress(HotKeyMap config)
		{
			Singleton<EventSystem>.Instance.Emit<ESeekTraceMoveDirection, bool>(EEventName.SeekTraceMoveActionInput, this.GetMoveDirection(), true);
		}

		// Token: 0x0603358D RID: 210317 RVA: 0x00CD85DF File Offset: 0x00CD67DF
		protected override void OnRelease(HotKeyMap config)
		{
			Singleton<EventSystem>.Instance.Emit<ESeekTraceMoveDirection, bool>(EEventName.SeekTraceMoveActionInput, this.GetMoveDirection(), false);
		}

		// Token: 0x0603358E RID: 210318 RVA: 0x00CD85F8 File Offset: 0x00CD67F8
		protected override void OnInputAxis(string axisName, float value)
		{
			Singleton<EventSystem>.Instance.Emit<ESeekTraceMoveDirection, float>(EEventName.SeekTraceMoveAxisInput, this.GetMoveDirection(), value);
		}
	}
}
