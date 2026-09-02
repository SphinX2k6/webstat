using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067A2 RID: 26530
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardCageData
	{
		// Token: 0x0604229F RID: 271007 RVA: 0x010F91AC File Offset: 0x010F73AC
		public DockyardCageData(OneFishCage data)
		{
			this.Data = data;
			foreach (FishingItemInfo data2 in data.Items)
			{
				DockyardItemBlockOriginalData dockyardItemBlockOriginalData = new DockyardItemBlockOriginalData(data2);
				this.ItemDataMap.Add(dockyardItemBlockOriginalData.IncId, dockyardItemBlockOriginalData);
			}
		}

		// Token: 0x060422A0 RID: 271008 RVA: 0x010F9224 File Offset: 0x010F7424
		public DockyardItemBlockOriginalData GetData(int uniqueId)
		{
			return this.ItemDataMap[uniqueId];
		}

		// Token: 0x060422A1 RID: 271009 RVA: 0x010F9232 File Offset: 0x010F7432
		public List<DockyardItemBlockOriginalData> GetDataList()
		{
			return new List<DockyardItemBlockOriginalData>(this.ItemDataMap.Values);
		}

		// Token: 0x04024DBC RID: 150972
		public readonly OneFishCage Data;

		// Token: 0x04024DBD RID: 150973
		private readonly Dictionary<int, DockyardItemBlockOriginalData> ItemDataMap = new Dictionary<int, DockyardItemBlockOriginalData>();
	}
}
