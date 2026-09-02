using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049B3 RID: 18867
	public class UiTickViewBase : UiViewBase, IPanelTickInterface
	{
		// Token: 0x0603150A RID: 201994 RVA: 0x00C462BB File Offset: 0x00C444BB
		[NullableContext(1)]
		public UiTickViewBase(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603150B RID: 201995 RVA: 0x00C462C4 File Offset: 0x00C444C4
		protected override void OnBeforeShowImplementImplement()
		{
			Singleton<UiManager>.Instance.AddTickView(this);
		}

		// Token: 0x0603150C RID: 201996 RVA: 0x00C462D1 File Offset: 0x00C444D1
		protected override void OnAfterHideImplementImplement()
		{
			Singleton<UiManager>.Instance.RemoveTickView(this);
		}

		// Token: 0x0603150D RID: 201997 RVA: 0x00C462DE File Offset: 0x00C444DE
		public void Tick(float delta)
		{
			this.OnTick(delta);
		}

		// Token: 0x0603150E RID: 201998 RVA: 0x00C462E7 File Offset: 0x00C444E7
		public void AfterTick(float delta)
		{
			this.OnAfterTick(delta);
		}

		// Token: 0x0603150F RID: 201999 RVA: 0x00C462F0 File Offset: 0x00C444F0
		protected virtual void OnTick(float delta)
		{
		}

		// Token: 0x06031510 RID: 202000 RVA: 0x00C462F2 File Offset: 0x00C444F2
		protected virtual void OnAfterTick(float delta)
		{
		}
	}
}
