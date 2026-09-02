using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BossPiling.View.Item
{
	// Token: 0x02005F06 RID: 24326
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public class BossPilingBuffItemData : MultiTemplateGridDataBase<BossPilingBuffCountInfo, BossPilingBuffItem>
	{
		// Token: 0x0603D1A8 RID: 250280 RVA: 0x00F8529B File Offset: 0x00F8349B
		public BossPilingBuffItemData(BossPilingBuffCountInfo data)
		{
			base.Data = data;
		}

		// Token: 0x0603D1A9 RID: 250281 RVA: 0x00F852AA File Offset: 0x00F834AA
		public override int GetTemplateIndex()
		{
			return 1;
		}

		// Token: 0x0603D1AA RID: 250282 RVA: 0x00F852AD File Offset: 0x00F834AD
		public override BossPilingBuffItem CreateProxy()
		{
			return new BossPilingBuffItem
			{
				OnToggleClicked = this.OnToggleClicked,
				IsSelectedCb = this.IsSelectedCb
			};
		}

		// Token: 0x0402244D RID: 140365
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<BossPilingBuffCountInfo> OnToggleClicked;

		// Token: 0x0402244E RID: 140366
		[Nullable(2)]
		public Func<int, bool> IsSelectedCb;
	}
}
