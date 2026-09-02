using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato.View.Settlement
{
	// Token: 0x02005A82 RID: 23170
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class RoleItemData : MultiTemplateGridDataBase<int, RoleItem>
	{
		// Token: 0x0603AA02 RID: 240130 RVA: 0x00ED9EF4 File Offset: 0x00ED80F4
		public override int GetTemplateIndex()
		{
			return 2;
		}

		// Token: 0x0603AA03 RID: 240131 RVA: 0x00ED9EF8 File Offset: 0x00ED80F8
		public override RoleItem CreateProxy()
		{
			RoleItem proxy = new RoleItem();
			proxy.OnClickCb = delegate(int roleId)
			{
				Action<RoleItem, bool> onClickCb = this.OnClickCb;
				if (onClickCb == null)
				{
					return;
				}
				onClickCb(proxy, true);
			};
			return proxy;
		}

		// Token: 0x0402129A RID: 135834
		public Action<RoleItem, bool> OnClickCb;
	}
}
