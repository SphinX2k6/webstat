using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F86 RID: 24454
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiSlideControlData
	{
		// Token: 0x0603D67B RID: 251515 RVA: 0x00F9F398 File Offset: 0x00F9D598
		public void OnPress(UUIItem item, float x, float y)
		{
			this.CurItem = item;
			this.Position.Set((double)x, (double)y);
			this.SetVisible(true);
			this.TouchBeginPos.Set(0.0, 0.0);
			this.TouchMoveDir.Set(0.0, 0.0);
		}

		// Token: 0x0603D67C RID: 251516 RVA: 0x00F9F3FC File Offset: 0x00F9D5FC
		public void OnRelease(UUIItem item)
		{
			if (this.CurItem != item)
			{
				return;
			}
			this.CurItem = null;
			this.SetVisible(false);
			this.TouchBeginPos.Set(0.0, 0.0);
			this.TouchMoveDir.Set(0.0, 0.0);
		}

		// Token: 0x0603D67D RID: 251517 RVA: 0x00F9F45C File Offset: 0x00F9D65C
		public void OnTouch(InputDistributeDefine.ITouchData touchData)
		{
			if (touchData.TouchType == InputDistributeDefine.ETouchType.TouchBegin)
			{
				this.TouchBeginPos.Set(touchData.TouchPosition.X, touchData.TouchPosition.Y);
				this.TouchMoveDir.Set(0.0, 0.0);
				this.TouchId = touchData.TouchId;
				return;
			}
			if (touchData.TouchType == InputDistributeDefine.ETouchType.TouchMove)
			{
				this.TouchMoveDir.Set(touchData.TouchPosition.X - this.TouchBeginPos.X, touchData.TouchPosition.Y - this.TouchBeginPos.Y);
			}
		}

		// Token: 0x0603D67E RID: 251518 RVA: 0x00F9F4FE File Offset: 0x00F9D6FE
		public void Preload()
		{
		}

		// Token: 0x0603D67F RID: 251519 RVA: 0x00F9F500 File Offset: 0x00F9D700
		public void ForceStop()
		{
			this.SetVisible(false);
			this.CurItem = null;
		}

		// Token: 0x0603D680 RID: 251520 RVA: 0x00F9F510 File Offset: 0x00F9D710
		public bool GetVisible()
		{
			return this.Visible;
		}

		// Token: 0x0603D681 RID: 251521 RVA: 0x00F9F518 File Offset: 0x00F9D718
		public void SetVisible(bool visible)
		{
			this.Visible = visible;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.BattleUiSlideControlVisibleChanged, visible);
		}

		// Token: 0x040227FA RID: 141306
		private bool Visible;

		// Token: 0x040227FB RID: 141307
		public readonly Vector2D Position = Vector2D.Create(0.0, 0.0);

		// Token: 0x040227FC RID: 141308
		[Nullable(2)]
		private UUIItem CurItem;

		// Token: 0x040227FD RID: 141309
		private readonly Vector2D TouchBeginPos = Vector2D.Create(0.0, 0.0);

		// Token: 0x040227FE RID: 141310
		public Vector2D TouchMoveDir = Vector2D.Create(0.0, 0.0);

		// Token: 0x040227FF RID: 141311
		public int TouchId = -1;
	}
}
