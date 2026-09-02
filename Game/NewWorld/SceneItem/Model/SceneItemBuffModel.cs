using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem.Model
{
	// Token: 0x02004846 RID: 18502
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class SceneItemBuffModel : ModelBase<SceneItemBuffModel>
	{
		// Token: 0x0603022A RID: 197162 RVA: 0x00BACAF8 File Offset: 0x00BAACF8
		public bool Add(int targetEntityId, long buffId, int producerEntityId)
		{
			Dictionary<long, List<int>> dictionary;
			if (!this.SceneItemBuffCacheMap.TryGetValue(targetEntityId, out dictionary))
			{
				dictionary = new Dictionary<long, List<int>>();
				this.SceneItemBuffCacheMap.Add(targetEntityId, dictionary);
			}
			List<int> list;
			if (!dictionary.TryGetValue(buffId, out list))
			{
				list = new List<int>();
				dictionary.Add(buffId, list);
			}
			if (!list.Contains(producerEntityId))
			{
				list.Add(producerEntityId);
				return true;
			}
			return false;
		}

		// Token: 0x0603022B RID: 197163 RVA: 0x00BACB54 File Offset: 0x00BAAD54
		public List<int> Remove(int targetEntityId, long buffId, int deltaCount, int? producerEntityId = null)
		{
			List<int> result = new List<int>();
			Dictionary<long, List<int>> dictionary;
			if (this.SceneItemBuffCacheMap.TryGetValue(targetEntityId, out dictionary))
			{
				List<int> list;
				if (dictionary.TryGetValue(buffId, out list))
				{
					if (producerEntityId != null)
					{
						int? num = producerEntityId;
						int num2 = 0;
						if (!(num.GetValueOrDefault() == num2 & num != null))
						{
							int num3 = list.IndexOf(producerEntityId.Value);
							if (num3 > -1)
							{
								result = list.Slice(num3, deltaCount);
								list.RemoveRange(num3, deltaCount);
								goto IL_93;
							}
							goto IL_93;
						}
					}
					int num4 = (deltaCount == -1) ? list.Count : deltaCount;
					result = list.Slice(0, num4);
					list.RemoveRange(0, num4);
					IL_93:
					if (list.Count == 0)
					{
						dictionary.Remove(buffId);
					}
				}
				if (dictionary.Count == 0)
				{
					this.SceneItemBuffCacheMap.Remove(targetEntityId);
				}
			}
			return result;
		}

		// Token: 0x0603022C RID: 197164 RVA: 0x00BACC1A File Offset: 0x00BAAE1A
		public bool RemoveAll(int targetEntityId)
		{
			return this.SceneItemBuffCacheMap.Remove(targetEntityId);
		}

		// Token: 0x0603022D RID: 197165 RVA: 0x00BACC28 File Offset: 0x00BAAE28
		public bool Switch(int newTargetEntityId, int oldTargetEntityId)
		{
			Dictionary<long, List<int>> value;
			if (this.SceneItemBuffCacheMap.ContainsKey(newTargetEntityId) || !this.SceneItemBuffCacheMap.TryGetValue(oldTargetEntityId, out value))
			{
				return false;
			}
			this.SceneItemBuffCacheMap.Add(newTargetEntityId, value);
			this.SceneItemBuffCacheMap.Remove(oldTargetEntityId);
			return true;
		}

		// Token: 0x0603022E RID: 197166 RVA: 0x00BACC70 File Offset: 0x00BAAE70
		[NullableContext(2)]
		public List<int> GetSceneItemIds(int targetEntityId)
		{
			Dictionary<long, List<int>> dictionary;
			if (!this.SceneItemBuffCacheMap.TryGetValue(targetEntityId, out dictionary))
			{
				return null;
			}
			List<int> list = new List<int>();
			foreach (List<int> list2 in dictionary.Values)
			{
				foreach (int item in list2)
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x0401BA19 RID: 113177
		private readonly Dictionary<int, Dictionary<long, List<int>>> SceneItemBuffCacheMap = new Dictionary<int, Dictionary<long, List<int>>>();
	}
}
