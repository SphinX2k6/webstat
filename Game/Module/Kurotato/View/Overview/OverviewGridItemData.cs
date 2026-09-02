using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato.View.Overview
{
	// Token: 0x02005AA6 RID: 23206
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	internal class OverviewGridItemData : MultiTemplateGridDataBase<IKurotatoMediumItemGridData, WeaponGridItem>
	{
		// Token: 0x0603AB3C RID: 240444 RVA: 0x00EE0FF2 File Offset: 0x00EDF1F2
		public override int GetTemplateIndex()
		{
			return 1;
		}

		// Token: 0x0603AB3D RID: 240445 RVA: 0x00EE0FF5 File Offset: 0x00EDF1F5
		public override bool IsNavigable()
		{
			return base.Data.Type != EKurotatoCardType.None;
		}

		// Token: 0x0603AB3E RID: 240446 RVA: 0x00EE1008 File Offset: 0x00EDF208
		public override WeaponGridItem CreateProxy()
		{
			WeaponGridItem proxy = new WeaponGridItem();
			proxy.OnClickCb = delegate(bool selected)
			{
				this.OnClickCb(proxy, selected);
			};
			proxy.IsSelectedCb = this.IsSelectedCb;
			return proxy;
		}

		// Token: 0x0402130B RID: 135947
		public Action<WeaponGridItem, bool> OnClickCb = delegate(WeaponGridItem _, bool _)
		{
		};

		// Token: 0x0402130C RID: 135948
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<IKurotatoMediumItemGridData, bool> IsSelectedCb;
	}
}
