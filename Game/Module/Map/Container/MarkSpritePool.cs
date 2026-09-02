using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Container
{
	// Token: 0x020058F1 RID: 22769
	[NullableContext(1)]
	[Nullable(0)]
	[StaticVariableRuleIgnore]
	public static class MarkSpritePool
	{
		// Token: 0x06039C9C RID: 236700 RVA: 0x00EA31CC File Offset: 0x00EA13CC
		[return: Nullable(2)]
		public static ULGUISpriteData_BaseObject Get(int componentId, string spritePath)
		{
			IMarkSpritePoolObj markSpritePoolObj;
			if (MarkSpritePool.SpriteHandleCacheMap.TryGetValue(spritePath, out markSpritePoolObj))
			{
				MarkSpritePool.Ref(componentId, spritePath, markSpritePoolObj.Obj);
				return markSpritePoolObj.Obj;
			}
			return null;
		}

		// Token: 0x06039C9D RID: 236701 RVA: 0x00EA3200 File Offset: 0x00EA1400
		public static void Ref(int componentId, string spritePath, ULGUISpriteData_BaseObject sprite)
		{
			HashSet<string> hashSet;
			if (!MarkSpritePool.ComponentAndSpriteRefMap.TryGetValue(componentId, out hashSet))
			{
				hashSet = new HashSet<string>();
				MarkSpritePool.ComponentAndSpriteRefMap[componentId] = hashSet;
			}
			hashSet.Add(spritePath);
			IMarkSpritePoolObj markSpritePoolObj;
			if (MarkSpritePool.SpriteHandleCacheMap.TryGetValue(spritePath, out markSpritePoolObj))
			{
				IMarkSpritePoolObj markSpritePoolObj2 = markSpritePoolObj;
				int @ref = markSpritePoolObj2.Ref;
				markSpritePoolObj2.Ref = @ref + 1;
				return;
			}
			markSpritePoolObj = new MarkSpritePoolObj
			{
				SpritePath = spritePath,
				RecycleTimeStamp = 0.0,
				Obj = sprite,
				Ref = 1
			};
			MarkSpritePool.SpriteHandleCacheMap[spritePath] = markSpritePoolObj;
		}

		// Token: 0x06039C9E RID: 236702 RVA: 0x00EA328C File Offset: 0x00EA148C
		public static void UnRef(int componentId)
		{
			HashSet<string> hashSet;
			if (!MarkSpritePool.ComponentAndSpriteRefMap.TryGetValue(componentId, out hashSet))
			{
				return;
			}
			foreach (string key in hashSet)
			{
				IMarkSpritePoolObj markSpritePoolObj;
				if (MarkSpritePool.SpriteHandleCacheMap.TryGetValue(key, out markSpritePoolObj))
				{
					IMarkSpritePoolObj markSpritePoolObj2 = markSpritePoolObj;
					int @ref = markSpritePoolObj2.Ref;
					markSpritePoolObj2.Ref = @ref - 1;
					if (markSpritePoolObj.Ref <= 0)
					{
						markSpritePoolObj.RecycleTimeStamp = Singleton<Time>.Instance.ServerTimeStamp;
						MarkSpritePool.SpriteHandleCacheMap.Remove(key);
					}
				}
			}
			MarkSpritePool.ComponentAndSpriteRefMap.Remove(componentId);
		}

		// Token: 0x06039C9F RID: 236703 RVA: 0x00EA3338 File Offset: 0x00EA1538
		public static void Tick()
		{
			MarkSpritePool.ToRemoveElements.Clear();
			foreach (IMarkSpritePoolObj markSpritePoolObj in MarkSpritePool.SpriteHandleCacheMap.Values)
			{
				double num = Singleton<Time>.Instance.ServerTimeStamp - markSpritePoolObj.RecycleTimeStamp;
				bool flag;
				if (markSpritePoolObj.Ref > 0 || num <= 10000.0)
				{
					ULGUISpriteData_BaseObject obj = markSpritePoolObj.Obj;
					flag = (obj == null || !obj.IsValid());
				}
				else
				{
					flag = true;
				}
				if (flag)
				{
					MarkSpritePool.ToRemoveElements.Add(markSpritePoolObj.SpritePath);
				}
			}
			foreach (string key in MarkSpritePool.ToRemoveElements)
			{
				MarkSpritePool.SpriteHandleCacheMap.Remove(key);
			}
		}

		// Token: 0x06039CA0 RID: 236704 RVA: 0x00EA342C File Offset: 0x00EA162C
		public static void Dispose()
		{
			MarkSpritePool.ComponentAndSpriteRefMap.Clear();
			MarkSpritePool.SpriteHandleCacheMap.Clear();
		}

		// Token: 0x04020C0C RID: 134156
		public const int MAX_SPRITE_HANDLE_CACHE_TIME = 10000;

		// Token: 0x04020C0D RID: 134157
		private static readonly Dictionary<int, HashSet<string>> ComponentAndSpriteRefMap = new Dictionary<int, HashSet<string>>();

		// Token: 0x04020C0E RID: 134158
		private static readonly Dictionary<string, IMarkSpritePoolObj> SpriteHandleCacheMap = new Dictionary<string, IMarkSpritePoolObj>();

		// Token: 0x04020C0F RID: 134159
		private static readonly List<string> ToRemoveElements = new List<string>();
	}
}
