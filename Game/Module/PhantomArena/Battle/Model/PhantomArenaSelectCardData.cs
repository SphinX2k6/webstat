using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Model
{
	// Token: 0x02005605 RID: 22021
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaSelectCardData
	{
		// Token: 0x06038254 RID: 229972 RVA: 0x00E382F0 File Offset: 0x00E364F0
		private void AddSelectCardData(PhantomBattleHandCardInfo dataInfo)
		{
			PhantomCardData phantomCardData = new PhantomCardData(false);
			phantomCardData.InitData(dataInfo);
			this.SelectCardDataList.Add(phantomCardData);
		}

		// Token: 0x06038255 RID: 229973 RVA: 0x00E38318 File Offset: 0x00E36518
		public void SetSelectCardDataList(PhantomBattleHandCardInfo[] dataList)
		{
			this.SelectCardDataList = new List<PhantomCardData>();
			foreach (PhantomBattleHandCardInfo dataInfo in dataList)
			{
				this.AddSelectCardData(dataInfo);
			}
		}

		// Token: 0x06038256 RID: 229974 RVA: 0x00E3834B File Offset: 0x00E3654B
		public List<PhantomCardData> GetSelectCardDataList()
		{
			return this.SelectCardDataList;
		}

		// Token: 0x04020140 RID: 131392
		protected List<PhantomCardData> SelectCardDataList = new List<PhantomCardData>();

		// Token: 0x04020141 RID: 131393
		public int SelectNum;
	}
}
