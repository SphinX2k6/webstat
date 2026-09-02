using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem.Model
{
	// Token: 0x02004844 RID: 18500
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class RangeItemModel : ModelBase<RangeItemModel>
	{
		// Token: 0x0603021F RID: 197151 RVA: 0x00BAC92D File Offset: 0x00BAAB2D
		protected override bool OnInit()
		{
			this.BoxRangeCache = new Dictionary<string, TsBoxRangeItem>();
			return true;
		}

		// Token: 0x06030220 RID: 197152 RVA: 0x00BAC93C File Offset: 0x00BAAB3C
		public void AddBoxRange(string rangeId, TsBoxRangeItem range)
		{
			if (this.BoxRangeCache.ContainsKey(rangeId))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneGameplay;
				ELogAuthor author = ELogAuthor.CJH;
				string message = "[RangeItemModel] Box Range Id 重复";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("BoxRangeItem", range);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			this.BoxRangeCache[rangeId] = range;
		}

		// Token: 0x06030221 RID: 197153 RVA: 0x00BAC98B File Offset: 0x00BAAB8B
		public void RemoveBoxRange(string rangeId)
		{
			this.BoxRangeCache.Remove(rangeId);
		}

		// Token: 0x06030222 RID: 197154 RVA: 0x00BAC99A File Offset: 0x00BAAB9A
		public TsBoxRangeItem GetBoxRange(string rangeId)
		{
			return this.BoxRangeCache[rangeId];
		}

		// Token: 0x06030223 RID: 197155 RVA: 0x00BAC9A8 File Offset: 0x00BAABA8
		protected override bool OnClear()
		{
			this.BoxRangeCache = null;
			return true;
		}

		// Token: 0x0401BA16 RID: 113174
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<string, TsBoxRangeItem> BoxRangeCache;
	}
}
