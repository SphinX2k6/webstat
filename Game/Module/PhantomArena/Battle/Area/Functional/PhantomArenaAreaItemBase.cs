using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Card;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Area.Functional
{
	// Token: 0x02005633 RID: 22067
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class PhantomArenaAreaItemBase : UiPanelBase
	{
		// Token: 0x0603841B RID: 230427 RVA: 0x00E3EA4C File Offset: 0x00E3CC4C
		protected override void OnStart()
		{
			Vector worldLocation = this.WorldLocation;
			FVector location = base.GetRootItem().K2_GetComponentToWorld().GetLocation();
			worldLocation.FromUeVector(location);
			this.SetHoverStateActive(false);
			this.SetCanUseStateActive(false);
			this.OnStartImplement();
		}

		// Token: 0x0603841C RID: 230428 RVA: 0x00E3EA8E File Offset: 0x00E3CC8E
		public Vector GetWorldLocation()
		{
			return this.WorldLocation;
		}

		// Token: 0x0603841D RID: 230429 RVA: 0x00E3EA96 File Offset: 0x00E3CC96
		protected override void OnStartImplement()
		{
		}

		// Token: 0x0603841E RID: 230430
		public abstract void Refresh(PhantomArenaCard card);

		// Token: 0x0603841F RID: 230431
		public abstract void SetHoverStateActive(bool value);

		// Token: 0x06038420 RID: 230432
		public abstract void SetCanUseStateActive(bool value);

		// Token: 0x06038421 RID: 230433 RVA: 0x00E3EA98 File Offset: 0x00E3CC98
		public void SetProxy(PhantomArenaAreaProxyBase proxy)
		{
			this.Proxy = proxy;
		}

		// Token: 0x040201CA RID: 131530
		private readonly Vector WorldLocation = Vector.Create();

		// Token: 0x040201CB RID: 131531
		protected PhantomArenaAreaProxyBase Proxy;
	}
}
