using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.GravityFlip
{
	// Token: 0x02006E7B RID: 28283
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class GravityFlipController : UiControllerBase<GravityFlipController>
	{
		// Token: 0x0604499C RID: 280988 RVA: 0x011D57B7 File Offset: 0x011D39B7
		public void OnChangeGravityDirection(EGravityDirection offsetAngle)
		{
			SceneItemGravityFlipComponent gravityFlipComp = ModelBase<GravityFlipModel>.Instance.GravityFlipComp;
			if (gravityFlipComp == null)
			{
				return;
			}
			gravityFlipComp.UpdatePrefabState(false);
		}

		// Token: 0x0604499D RID: 280989 RVA: 0x011D57CE File Offset: 0x011D39CE
		public void ListenTeleportCompleteEvent(Action<int> callback)
		{
			Singleton<EventSystem>.Instance.Add<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
			this.TeleportCompleteCallback = callback;
		}

		// Token: 0x0604499E RID: 280990 RVA: 0x011D57F3 File Offset: 0x011D39F3
		private void OnTeleportComplete(TeleportContext context = null)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.TeleportComplete, new <>f__AnonymousDelegate12<TeleportContext>(this.OnTeleportComplete));
			Action<int> teleportCompleteCallback = this.TeleportCompleteCallback;
			if (teleportCompleteCallback == null)
			{
				return;
			}
			teleportCompleteCallback(3);
		}

		// Token: 0x0604499F RID: 280991 RVA: 0x011D5824 File Offset: 0x011D3A24
		public void CancelWaitTeleport()
		{
			if (Singleton<EventSystem>.Instance.Has(EEventName.TeleportComplete, new <>f__AnonymousDelegate12<TeleportContext>(this.OnTeleportComplete)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.TeleportComplete, new <>f__AnonymousDelegate12<TeleportContext>(this.OnTeleportComplete));
			}
			Action<int> teleportCompleteCallback = this.TeleportCompleteCallback;
			if (teleportCompleteCallback == null)
			{
				return;
			}
			teleportCompleteCallback(3);
		}

		// Token: 0x040262F6 RID: 156406
		private Action<int> TeleportCompleteCallback;
	}
}
