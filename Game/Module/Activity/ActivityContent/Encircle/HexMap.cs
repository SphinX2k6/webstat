using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x02006868 RID: 26728
	[NullableContext(1)]
	[Nullable(0)]
	internal class HexMap
	{
		// Token: 0x060429A8 RID: 272808 RVA: 0x01117ED4 File Offset: 0x011160D4
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<int, IHexData> GetHexes()
		{
			return this.Hexes;
		}

		// Token: 0x060429A9 RID: 272809 RVA: 0x01117EDC File Offset: 0x011160DC
		public void SetHexes([Nullable(new byte[]
		{
			2,
			1
		})] Dictionary<int, IHexData> hexesInternal)
		{
			this.Hexes = hexesInternal;
		}

		// Token: 0x060429AA RID: 272810 RVA: 0x01117EE5 File Offset: 0x011160E5
		public void Clear()
		{
			this.Hexes = null;
			this.Width = null;
			this.Height = null;
		}

		// Token: 0x060429AB RID: 272811 RVA: 0x01117F06 File Offset: 0x01116106
		public int GetWidth()
		{
			return this.Width.Value;
		}

		// Token: 0x060429AC RID: 272812 RVA: 0x01117F13 File Offset: 0x01116113
		public int GetHeight()
		{
			return this.Height.Value;
		}

		// Token: 0x060429AD RID: 272813 RVA: 0x01117F20 File Offset: 0x01116120
		public void SetWidth(int width)
		{
			this.Width = new int?(width);
		}

		// Token: 0x060429AE RID: 272814 RVA: 0x01117F2E File Offset: 0x0111612E
		public void SetHeight(int height)
		{
			this.Height = new int?(height);
		}

		// Token: 0x060429AF RID: 272815 RVA: 0x01117F3C File Offset: 0x0111613C
		public void SetHex(IHexPos pos, [Nullable(2)] IHexData hexData)
		{
			this.Hexes[Singleton<EncircleUtils>.Instance.HexPosToKey(pos)] = hexData;
		}

		// Token: 0x060429B0 RID: 272816 RVA: 0x01117F58 File Offset: 0x01116158
		[return: Nullable(2)]
		public IHexData GetHex(IHexPos pos)
		{
			IHexData result;
			this.Hexes.TryGetValue(Singleton<EncircleUtils>.Instance.HexPosToKey(pos), out result);
			return result;
		}

		// Token: 0x060429B1 RID: 272817 RVA: 0x01117F7F File Offset: 0x0111617F
		public bool CheckCanAddObstacle(IHexPos pos)
		{
			IHexData hex = this.GetHex(pos);
			return hex != null && hex.Type == EncircleHexType.Plain;
		}

		// Token: 0x060429B2 RID: 272818 RVA: 0x01117F98 File Offset: 0x01116198
		public void CheckInTrap(MapMonster monster, IHexPos pos)
		{
			IHexData hex = this.GetHex(pos);
			if (hex == null)
			{
				return;
			}
			if (hex.Type == EncircleHexType.Trap)
			{
				monster.BeTrapped = true;
				hex.Type = EncircleHexType.Plain;
				this.SetHex(monster.Pos, hex);
			}
		}

		// Token: 0x060429B3 RID: 272819 RVA: 0x01117FD8 File Offset: 0x011161D8
		protected bool IsValidPos(IHexPos pos)
		{
			if (pos.PosX >= 0)
			{
				int posX = pos.PosX;
				int? num = this.Width;
				if ((posX < num.GetValueOrDefault() & num != null) && pos.PosY >= 0)
				{
					int posY = pos.PosY;
					num = this.Height;
					return posY < num.GetValueOrDefault() & num != null;
				}
			}
			return false;
		}

		// Token: 0x060429B4 RID: 272820 RVA: 0x01118037 File Offset: 0x01116237
		protected List<IHexData> GetAllHexes()
		{
			return new List<IHexData>(this.Hexes.Values);
		}

		// Token: 0x060429B5 RID: 272821 RVA: 0x0111804C File Offset: 0x0111624C
		private bool IsWithinMap(IHexPos pos)
		{
			if (pos.PosX >= 0)
			{
				int posX = pos.PosX;
				int? num = this.Width * 2;
				if ((posX < num.GetValueOrDefault() & num != null) && pos.PosY >= 0)
				{
					int posY = pos.PosY;
					num = this.Height;
					return posY < num.GetValueOrDefault() & num != null;
				}
			}
			return false;
		}

		// Token: 0x060429B6 RID: 272822 RVA: 0x011180D0 File Offset: 0x011162D0
		public bool IsBoundary(IHexPos pos)
		{
			if (pos.PosX != 0 && pos.PosX != 1)
			{
				int posX = pos.PosX;
				int? width = this.Width;
				int? num = (width != null) ? new int?(width.GetValueOrDefault() * 2 - 3) : null;
				if (!(posX == num.GetValueOrDefault() & num != null))
				{
					int posX2 = pos.PosX;
					width = this.Width;
					num = ((width != null) ? new int?(width.GetValueOrDefault() * 2 - 2) : null);
					if (!(posX2 == num.GetValueOrDefault() & num != null) && pos.PosY != 0)
					{
						int posY = pos.PosY;
						num = this.Height - 1;
						return posY == num.GetValueOrDefault() & num != null;
					}
				}
			}
			return true;
		}

		// Token: 0x060429B7 RID: 272823 RVA: 0x011181CC File Offset: 0x011163CC
		private bool IsObstacle(IHexPos pos)
		{
			IHexData hexData;
			this.Hexes.TryGetValue(Singleton<EncircleUtils>.Instance.HexPosToKey(pos), out hexData);
			return (hexData != null && hexData.Type == EncircleHexType.Wall) || (hexData != null && hexData.Type == EncircleHexType.InitialWall) || (hexData != null && hexData.Type == EncircleHexType.DifficultyWall);
		}

		// Token: 0x060429B8 RID: 272824 RVA: 0x0111821C File Offset: 0x0111641C
		private bool IsLimitObstacle(IHexPos pos)
		{
			IHexData hexData;
			this.Hexes.TryGetValue(Singleton<EncircleUtils>.Instance.HexPosToKey(pos), out hexData);
			return (hexData != null && hexData.Type == EncircleHexType.LimitWall) || (hexData != null && hexData.Type == EncircleHexType.Monster);
		}

		// Token: 0x060429B9 RID: 272825 RVA: 0x01118260 File Offset: 0x01116460
		private IHexPos[] GetPriorityOffsets(int priority)
		{
			if (priority == 1)
			{
				return new IHexPos[]
				{
					new HexPos
					{
						PosX = this.DirectionUpLeft.Item1,
						PosY = this.DirectionUpLeft.Item2
					},
					new HexPos
					{
						PosX = this.DirectionUpRight.Item1,
						PosY = this.DirectionUpRight.Item2
					},
					new HexPos
					{
						PosX = this.DirectionLeft.Item1,
						PosY = this.DirectionLeft.Item2
					},
					new HexPos
					{
						PosX = this.DirectionRight.Item1,
						PosY = this.DirectionRight.Item2
					},
					new HexPos
					{
						PosX = this.DirectionDownLeft.Item1,
						PosY = this.DirectionDownLeft.Item2
					},
					new HexPos
					{
						PosX = this.DirectionDownRight.Item1,
						PosY = this.DirectionDownRight.Item2
					}
				};
			}
			return new IHexPos[]
			{
				new HexPos
				{
					PosX = this.DirectionDownRight.Item1,
					PosY = this.DirectionDownRight.Item2
				},
				new HexPos
				{
					PosX = this.DirectionDownLeft.Item1,
					PosY = this.DirectionDownLeft.Item2
				},
				new HexPos
				{
					PosX = this.DirectionRight.Item1,
					PosY = this.DirectionRight.Item2
				},
				new HexPos
				{
					PosX = this.DirectionLeft.Item1,
					PosY = this.DirectionLeft.Item2
				},
				new HexPos
				{
					PosX = this.DirectionUpRight.Item1,
					PosY = this.DirectionUpRight.Item2
				},
				new HexPos
				{
					PosX = this.DirectionUpLeft.Item1,
					PosY = this.DirectionUpLeft.Item2
				}
			};
		}

		// Token: 0x060429BA RID: 272826 RVA: 0x0111847C File Offset: 0x0111667C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public IHexPos[] GetOptimalEscapeRoutes(MapMonster monster)
		{
			IHexPos[] priorityOffsets = this.GetPriorityOffsets(monster.Priority);
			IHexPos pos = monster.Pos;
			List<IHexPos> list = new List<IHexPos>();
			List<IHexPos> list2 = new List<IHexPos>();
			Dictionary<int, IHexPos> dictionary = new Dictionary<int, IHexPos>();
			int key = Singleton<EncircleUtils>.Instance.HexPosToKey(pos);
			dictionary[key] = null;
			list.Add(pos);
			int? num = null;
			while (list.Count > 0 || list2.Count > 0)
			{
				if (list.Count == 0)
				{
					list = list2;
					list2 = new List<IHexPos>();
				}
				IHexPos hexPos = list[0];
				list.RemoveAt(0);
				if (this.IsBoundary(hexPos))
				{
					return this.ReconstructPath(dictionary, hexPos);
				}
				foreach (IHexPos hexPos2 in priorityOffsets)
				{
					IHexPos hexPos3 = new HexPos
					{
						PosX = hexPos.PosX + hexPos2.PosX,
						PosY = hexPos.PosY + hexPos2.PosY
					};
					num = new int?(Singleton<EncircleUtils>.Instance.HexPosToKey(hexPos3));
					if (this.IsWithinMap(hexPos3) && !dictionary.ContainsKey(num.Value) && !this.IsObstacle(hexPos3))
					{
						if (this.IsLimitObstacle(hexPos3))
						{
							list2.Add(hexPos3);
						}
						else
						{
							list.Add(hexPos3);
						}
						dictionary[num.Value] = hexPos;
					}
				}
			}
			return null;
		}

		// Token: 0x060429BB RID: 272827 RVA: 0x011185E8 File Offset: 0x011167E8
		private IHexPos[] ReconstructPath([Nullable(new byte[]
		{
			1,
			2
		})] Dictionary<int, IHexPos> cameFrom, IHexPos end)
		{
			List<IHexPos> list = new List<IHexPos>();
			IHexPos hexPos = end;
			while (hexPos != null)
			{
				list.Add(hexPos);
				int key = Singleton<EncircleUtils>.Instance.HexPosToKey(hexPos);
				cameFrom.TryGetValue(key, out hexPos);
			}
			list.Reverse();
			return list.ToArray();
		}

		// Token: 0x060429BC RID: 272828 RVA: 0x0111862B File Offset: 0x0111682B
		public void AddObstacle(IHexPos pos)
		{
			this.ChangeMapType(pos, EncircleHexType.Wall);
		}

		// Token: 0x060429BD RID: 272829 RVA: 0x01118638 File Offset: 0x01116838
		public void ChangeMapType(IHexPos pos, EncircleHexType changeType)
		{
			IHexData hex = this.GetHex(pos);
			hex.Type = changeType;
			this.SetHex(pos, hex);
		}

		// Token: 0x0402511A RID: 151834
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, IHexData> Hexes;

		// Token: 0x0402511B RID: 151835
		private int? Width;

		// Token: 0x0402511C RID: 151836
		private int? Height;

		// Token: 0x0402511D RID: 151837
		[TupleElementNames(new string[]
		{
			"PosX",
			"PosY"
		})]
		[Nullable(0)]
		private readonly ValueTuple<int, int> DirectionUpLeft = new ValueTuple<int, int>(-1, -1);

		// Token: 0x0402511E RID: 151838
		[TupleElementNames(new string[]
		{
			"PosX",
			"PosY"
		})]
		[Nullable(0)]
		private readonly ValueTuple<int, int> DirectionUpRight = new ValueTuple<int, int>(1, -1);

		// Token: 0x0402511F RID: 151839
		[TupleElementNames(new string[]
		{
			"PosX",
			"PosY"
		})]
		[Nullable(0)]
		private readonly ValueTuple<int, int> DirectionLeft = new ValueTuple<int, int>(-2, 0);

		// Token: 0x04025120 RID: 151840
		[TupleElementNames(new string[]
		{
			"PosX",
			"PosY"
		})]
		[Nullable(0)]
		private readonly ValueTuple<int, int> DirectionRight = new ValueTuple<int, int>(2, 0);

		// Token: 0x04025121 RID: 151841
		[TupleElementNames(new string[]
		{
			"PosX",
			"PosY"
		})]
		[Nullable(0)]
		private readonly ValueTuple<int, int> DirectionDownLeft = new ValueTuple<int, int>(-1, 1);

		// Token: 0x04025122 RID: 151842
		[TupleElementNames(new string[]
		{
			"PosX",
			"PosY"
		})]
		[Nullable(0)]
		private readonly ValueTuple<int, int> DirectionDownRight = new ValueTuple<int, int>(1, 1);
	}
}
