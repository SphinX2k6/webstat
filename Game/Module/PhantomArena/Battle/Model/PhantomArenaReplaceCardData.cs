using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Model
{
	// Token: 0x02005604 RID: 22020
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaReplaceCardData
	{
		// Token: 0x06038250 RID: 229968 RVA: 0x00E3827C File Offset: 0x00E3647C
		public void SetReplaceCardData(PhantomBattleHandCardInfo[] cardInfoList)
		{
			foreach (PhantomBattleHandCardInfo dataInfo in cardInfoList)
			{
				PhantomCardData phantomCardData = new PhantomCardData(false);
				phantomCardData.InitData(dataInfo);
				this.DataMap[phantomCardData.CardId] = phantomCardData;
			}
		}

		// Token: 0x06038251 RID: 229969 RVA: 0x00E382BD File Offset: 0x00E364BD
		public List<PhantomCardData> GetReplaceCardDataList()
		{
			return this.DataMap.Values.ToList<PhantomCardData>();
		}

		// Token: 0x06038252 RID: 229970 RVA: 0x00E382CF File Offset: 0x00E364CF
		public void ClearReplaceCardData()
		{
			this.DataMap.Clear();
		}

		// Token: 0x0402013E RID: 131390
		private readonly Dictionary<int, PhantomCardData> DataMap = new Dictionary<int, PhantomCardData>();

		// Token: 0x0402013F RID: 131391
		public int ReplaceNum;
	}
}
