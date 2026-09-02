using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066D5 RID: 26325
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public class MotorFightGridTemplateData : MultiTemplateGridDataBase<MotorFightItemData, MotorFightGridItem>
	{
		// Token: 0x06041BC3 RID: 269251 RVA: 0x010DB56D File Offset: 0x010D976D
		public override int GetTemplateIndex()
		{
			return 1;
		}

		// Token: 0x06041BC4 RID: 269252 RVA: 0x010DB570 File Offset: 0x010D9770
		public override MotorFightGridItem CreateProxy()
		{
			MotorFightGridItem proxy = new MotorFightGridItem();
			proxy.OnClickCb = delegate(MotorFightItemData data)
			{
				this.OnClickCb(data, proxy.GridIndex);
			};
			proxy.IsSelected = this.IsSelected;
			return proxy;
		}

		// Token: 0x04024ADF RID: 150239
		public Func<int, bool> IsSelected = (int id) => false;

		// Token: 0x04024AE0 RID: 150240
		public Action<MotorFightItemData, int> OnClickCb;
	}
}
