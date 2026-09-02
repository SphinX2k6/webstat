using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066E5 RID: 26341
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MotorFightItemTypeTemplateData : MultiTemplateGridDataBase<MotorFightItemType, MotorFightItemTypeItem>
	{
		// Token: 0x06041C23 RID: 269347 RVA: 0x010DE078 File Offset: 0x010DC278
		public override int GetTemplateIndex()
		{
			return 0;
		}

		// Token: 0x06041C24 RID: 269348 RVA: 0x010DE07B File Offset: 0x010DC27B
		public override MotorFightItemTypeItem CreateProxy()
		{
			return new MotorFightItemTypeItem
			{
				GetUnlockNum = this.GetUnlockNum
			};
		}

		// Token: 0x04024B01 RID: 150273
		public Func<int, Tuple<int, int>> GetUnlockNum = (int type) => new Tuple<int, int>(0, 0);
	}
}
