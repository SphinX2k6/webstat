using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato.View.KurotatoLevelSelect
{
	// Token: 0x02005AAC RID: 23212
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class KurotatoLevelItemTemplateData : MultiTemplateGridDataBase<int, KurotatoLevelItem>
	{
		// Token: 0x0603AB50 RID: 240464 RVA: 0x00EE1779 File Offset: 0x00EDF979
		public override int GetTemplateIndex()
		{
			return 1;
		}

		// Token: 0x0603AB51 RID: 240465 RVA: 0x00EE177C File Offset: 0x00EDF97C
		public override KurotatoLevelItem CreateProxy()
		{
			KurotatoLevelItem proxy = new KurotatoLevelItem();
			proxy.OnClickCb = delegate(int id)
			{
				this.OnClickCb(id, proxy.GridIndex);
			};
			proxy.IsSelected = this.IsSelected;
			return proxy;
		}

		// Token: 0x04021310 RID: 135952
		public Action<int, int> OnClickCb = delegate(int _, int _)
		{
		};

		// Token: 0x04021311 RID: 135953
		public Func<int, bool> IsSelected = (int _) => false;
	}
}
