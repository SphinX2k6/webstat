using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x0200686B RID: 26731
	[NullableContext(1)]
	[Nullable(0)]
	public class EncirclePlayDataManager
	{
		// Token: 0x060429CE RID: 272846 RVA: 0x0111876C File Offset: 0x0111696C
		public Dictionary<int, IHexData> InitHexMap(int mapId)
		{
			IReadOnlyList<EncircleMap> encircleMap = ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleMap(mapId);
			int num = this.CalcMapWidth(encircleMap);
			int count = encircleMap.Count;
			Dictionary<int, IHexData> dictionary = new Dictionary<int, IHexData>();
			List<MapMonster> list = new List<MapMonster>();
			Dictionary<int, LimitWall> dictionary2 = new Dictionary<int, LimitWall>();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < num; j++)
				{
					IHexPos hexPos = Singleton<EncircleUtils>.Instance.PlanePosToHexPos(j, i);
					int? currentMapItemId = this.GetCurrentMapItemId(encircleMap, i, j);
					if (currentMapItemId != null)
					{
						EncircleHexType? mapItemType = ConfigBase<ActivityEncircleConfig>.Instance.GetMapItemType(currentMapItemId.Value);
						HexData value = new HexData
						{
							HexPos = hexPos,
							Type = mapItemType.Value,
							MapId = currentMapItemId.Value
						};
						int key = Singleton<EncircleUtils>.Instance.HexPosToKey(hexPos);
						dictionary[key] = value;
						EncircleHexType? encircleHexType = mapItemType;
						EncircleHexType encircleHexType2 = EncircleHexType.Monster;
						if (encircleHexType.GetValueOrDefault() == encircleHexType2 & encircleHexType != null)
						{
							int priority = int.Parse(ConfigBase<ActivityEncircleConfig>.Instance.GetMapItemMemo(currentMapItemId.Value));
							list.Add(new MapMonster(hexPos, currentMapItemId.Value, priority));
						}
						encircleHexType = mapItemType;
						encircleHexType2 = EncircleHexType.LimitWall;
						if (encircleHexType.GetValueOrDefault() == encircleHexType2 & encircleHexType != null)
						{
							int limitRound = int.Parse(ConfigBase<ActivityEncircleConfig>.Instance.GetMapItemMemo(currentMapItemId.Value));
							dictionary2[key] = new LimitWall(hexPos, limitRound);
						}
					}
				}
			}
			this.HexMap.SetHexes(dictionary);
			this.HexMap.SetHeight(count);
			this.HexMap.SetWidth(num);
			this.Monsters = list;
			this.LimitWalls = dictionary2;
			return dictionary;
		}

		// Token: 0x060429CF RID: 272847 RVA: 0x01118918 File Offset: 0x01116B18
		[NullableContext(2)]
		private int CalcMapWidth(IReadOnlyList<EncircleMap> encircleMaps)
		{
			int num = 1;
			if (encircleMaps == null)
			{
				return 0;
			}
			while (!this.CheckColumnIsEmpty(encircleMaps, num))
			{
				num++;
			}
			return num - 1;
		}

		// Token: 0x060429D0 RID: 272848 RVA: 0x01118940 File Offset: 0x01116B40
		[NullableContext(2)]
		public LimitWall GetLimitWall(int posKey)
		{
			if (this.LimitWalls == null)
			{
				return null;
			}
			LimitWall result;
			this.LimitWalls.TryGetValue(posKey, out result);
			return result;
		}

		// Token: 0x060429D1 RID: 272849 RVA: 0x01118968 File Offset: 0x01116B68
		private bool CheckColumnIsEmpty(IReadOnlyList<EncircleMap> encircleMaps, int width)
		{
			bool result = true;
			string name = this.GenColumnArrayMethodName(width);
			if (encircleMaps.Count <= 0)
			{
				return true;
			}
			EncircleMap encircleMap = encircleMaps[0];
			MethodInfo method = encircleMap.GetType().GetMethod(name);
			if (method != null)
			{
				using (IEnumerator<EncircleMap> enumerator = encircleMaps.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						EncircleMap encircleMap2 = enumerator.Current;
						int[] array = method.Invoke(encircleMap2, null) as int[];
						if (array != null && array.Length != 0)
						{
							result = false;
						}
					}
					return result;
				}
				return true;
			}
			return true;
		}

		// Token: 0x060429D2 RID: 272850 RVA: 0x01118A0C File Offset: 0x01116C0C
		[NullableContext(2)]
		private int? GetCurrentMapItemId(IReadOnlyList<EncircleMap> encircleMaps, int r, int q)
		{
			EncircleMap encircleMap = encircleMaps[r];
			string name = this.GenColumnArrayMethodName(q + 1);
			MethodInfo method = encircleMap.GetType().GetMethod(name);
			int[] array = ((method != null) ? method.Invoke(encircleMap, null) : null) as int[];
			if (array == null || array.Length == 0)
			{
				return null;
			}
			int num = Math.Min(Singleton<EncirclePlayLevelController>.Instance.GetCurrentDifficulty(), array.Length - 1);
			return new int?(array[num]);
		}

		// Token: 0x060429D3 RID: 272851 RVA: 0x01118A84 File Offset: 0x01116C84
		private string GenColumnArrayMethodName(int num)
		{
			return StringUtils.Format("GetColumn{0}Array", new string[]
			{
				num.ToString()
			});
		}

		// Token: 0x060429D4 RID: 272852 RVA: 0x01118AA0 File Offset: 0x01116CA0
		public int GetMapHeight()
		{
			return this.HexMap.GetHeight();
		}

		// Token: 0x060429D5 RID: 272853 RVA: 0x01118AAD File Offset: 0x01116CAD
		public int GetMapWidth()
		{
			return this.HexMap.GetWidth();
		}

		// Token: 0x060429D6 RID: 272854 RVA: 0x01118ABA File Offset: 0x01116CBA
		private IHexPos ViewPosToHexPos(int? x, int? y)
		{
			return Singleton<EncircleUtils>.Instance.PlanePosToHexPos(x.Value, y.Value);
		}

		// Token: 0x060429D7 RID: 272855 RVA: 0x01118AD4 File Offset: 0x01116CD4
		public bool CheckCanAddObstacle(int? x, int? y)
		{
			return this.HexMap.CheckCanAddObstacle(this.ViewPosToHexPos(x, y));
		}

		// Token: 0x060429D8 RID: 272856 RVA: 0x01118AE9 File Offset: 0x01116CE9
		public void Clear()
		{
			this.HexMap.Clear();
			this.MoveMonsterIndex = 0;
			this.MoveMonsterEffectIndex = 0;
		}

		// Token: 0x060429D9 RID: 272857 RVA: 0x01118B04 File Offset: 0x01116D04
		public bool TryMoveMonster()
		{
			bool result = false;
			this.MoveMonsterIndex %= this.Monsters.Count;
			MapMonster mapMonster = this.Monsters[this.MoveMonsterIndex];
			if (this.TryMoveMonsterHandle(mapMonster))
			{
				result = true;
			}
			else
			{
				bool flag = !mapMonster.BeCaught;
				mapMonster.BeCaught = true;
				if (!this.IsAllMonsterBeCaught())
				{
					if (flag)
					{
						Singleton<EncirclePlayLevelController>.Instance.SetMonsterDead(mapMonster.MapItemId.Value);
					}
					this.MoveMonsterIndex++;
					result = this.TryMoveMonster();
				}
			}
			this.MoveMonsterIndex++;
			return result;
		}

		// Token: 0x060429DA RID: 272858 RVA: 0x01118BA4 File Offset: 0x01116DA4
		private bool IsAllMonsterBeCaught()
		{
			using (List<MapMonster>.Enumerator enumerator = this.Monsters.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.BeCaught)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x060429DB RID: 272859 RVA: 0x01118C00 File Offset: 0x01116E00
		public void TryShowMonsterMoveEffect()
		{
			if (this.Monsters.Count < 2)
			{
				return;
			}
			foreach (MapMonster mapMonster in this.Monsters)
			{
				if (mapMonster.BeCaught)
				{
					Singleton<EncirclePlayLevelController>.Instance.ShowItemMoveEffect(mapMonster.Pos, false);
				}
			}
			int index = this.MoveMonsterEffectIndex % this.Monsters.Count;
			if (this.Monsters[index].BeCaught)
			{
				this.MoveMonsterEffectIndex++;
				index = this.MoveMonsterEffectIndex % this.Monsters.Count;
			}
			Singleton<EncirclePlayLevelController>.Instance.ShowItemMoveEffect(this.Monsters[index].Pos, true);
			this.MoveMonsterEffectIndex++;
		}

		// Token: 0x060429DC RID: 272860 RVA: 0x01118CE8 File Offset: 0x01116EE8
		private bool TryMoveMonsterHandle(MapMonster monster)
		{
			IHexPos[] optimalEscapeRoutes = this.HexMap.GetOptimalEscapeRoutes(monster);
			if (optimalEscapeRoutes == null)
			{
				return false;
			}
			if (Singleton<EncirclePlayLevelController>.Instance.GetGmLog())
			{
				List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
				foreach (IHexPos hexPos in optimalEscapeRoutes)
				{
					list.Add(Singleton<EncircleUtils>.Instance.HexPosToPlanePos(hexPos));
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneGameplay;
				ELogAuthor author = ELogAuthor.SWC;
				string message = "RoutePath";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RoutePath", list);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			this.MoveMonster(monster, optimalEscapeRoutes);
			return true;
		}

		// Token: 0x060429DD RID: 272861 RVA: 0x01118D78 File Offset: 0x01116F78
		private void MoveMonster(MapMonster monster, IHexPos[] path)
		{
			IHexPos pos = monster.Pos;
			if (monster.BeTrapped)
			{
				monster.BeTrapped = false;
				Singleton<EncirclePlayLevelController>.Instance.ChangeViewMapType(monster.MapItemId.Value, pos, pos);
				return;
			}
			if (this.HexMap.GetHex(path[1]).Type == EncircleHexType.LimitWall || this.HexMap.GetHex(path[1]).Type == EncircleHexType.Monster)
			{
				Singleton<EncirclePlayLevelController>.Instance.ChangeViewMapType(monster.MapItemId.Value, pos, pos);
				return;
			}
			Singleton<EncirclePlayLevelController>.Instance.ChangeViewMapType(monster.MapItemId.Value, path[1], pos);
			monster.Pos = path[1];
			this.HexMap.CheckInTrap(monster, path[1]);
			this.HexMap.ChangeMapType(path[1], EncircleHexType.Monster);
			if (pos != null)
			{
				this.HexMap.ChangeMapType(pos, EncircleHexType.Plain);
			}
		}

		// Token: 0x060429DE RID: 272862 RVA: 0x01118E50 File Offset: 0x01117050
		public void AddObstacle(int? x, int? y)
		{
			IHexPos hexPos = Singleton<EncircleUtils>.Instance.PlanePosToHexPos(x.Value, y.Value);
			this.HexMap.AddObstacle(hexPos);
			Singleton<EncirclePlayLevelController>.Instance.ChangeViewMapType(1, hexPos, null);
		}

		// Token: 0x060429DF RID: 272863 RVA: 0x01118E90 File Offset: 0x01117090
		public bool CheckMonsterEscape()
		{
			bool result = false;
			foreach (MapMonster mapMonster in this.Monsters)
			{
				if (this.HexMap.IsBoundary(mapMonster.Pos))
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x060429E0 RID: 272864 RVA: 0x01118EF4 File Offset: 0x011170F4
		public bool CheckIsBoundary(IHexPos pos)
		{
			return this.HexMap.IsBoundary(pos);
		}

		// Token: 0x060429E1 RID: 272865 RVA: 0x01118F04 File Offset: 0x01117104
		public void PushWallLimit()
		{
			List<LimitWall> list = new List<LimitWall>();
			foreach (LimitWall limitWall in this.LimitWalls.Values)
			{
				if (Singleton<EncirclePlayLevelController>.Instance.GetCurrentRound() >= limitWall.LimitRound)
				{
					list.Add(limitWall);
				}
			}
			foreach (LimitWall limitWall2 in list)
			{
				Singleton<EncirclePlayLevelController>.Instance.ChangeViewMapType(0, limitWall2.Pos, null);
				this.HexMap.ChangeMapType(limitWall2.Pos, EncircleHexType.Plain);
				Dictionary<int, LimitWall> limitWalls = this.LimitWalls;
				if (limitWalls != null)
				{
					limitWalls.Remove(Singleton<EncircleUtils>.Instance.HexPosToKey(limitWall2.Pos));
				}
			}
			foreach (LimitWall limitWall3 in this.LimitWalls.Values)
			{
				Singleton<EncirclePlayLevelController>.Instance.ChangeViewMapType(5, limitWall3.Pos, null);
			}
		}

		// Token: 0x060429E2 RID: 272866 RVA: 0x01119048 File Offset: 0x01117248
		public List<int> GetAllMonsterId()
		{
			List<int> list = new List<int>();
			foreach (MapMonster mapMonster in this.Monsters)
			{
				list.Add(mapMonster.MapItemId.Value);
			}
			return list;
		}

		// Token: 0x0402512A RID: 151850
		private readonly HexMap HexMap = new HexMap();

		// Token: 0x0402512B RID: 151851
		private int MoveMonsterIndex;

		// Token: 0x0402512C RID: 151852
		private int MoveMonsterEffectIndex;

		// Token: 0x0402512D RID: 151853
		private List<MapMonster> Monsters = new List<MapMonster>();

		// Token: 0x0402512E RID: 151854
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, LimitWall> LimitWalls;

		// Token: 0x0402512F RID: 151855
		private const int LIMIT_WALL_ID = 5;
	}
}
