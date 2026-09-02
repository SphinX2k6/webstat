using System;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004F0B RID: 20235
	public static class SlidingBlocksDefine_ETetrominoTypeExtensions
	{
		// Token: 0x060344DC RID: 214236 RVA: 0x00D15F90 File Offset: 0x00D14190
		public static string ToEnumString(this SlidingBlocksDefine.ETetrominoType value)
		{
			string result;
			switch (value)
			{
			case SlidingBlocksDefine.ETetrominoType.I块:
				result = "I块";
				break;
			case SlidingBlocksDefine.ETetrominoType.J块:
				result = "J块";
				break;
			case SlidingBlocksDefine.ETetrominoType.L块:
				result = "L块";
				break;
			case SlidingBlocksDefine.ETetrominoType.O块:
				result = "O块";
				break;
			case SlidingBlocksDefine.ETetrominoType.S块:
				result = "S块";
				break;
			case SlidingBlocksDefine.ETetrominoType.T块:
				result = "T块";
				break;
			case SlidingBlocksDefine.ETetrominoType.Z块:
				result = "Z块";
				break;
			case SlidingBlocksDefine.ETetrominoType.五连I块:
				result = "五连I块";
				break;
			case SlidingBlocksDefine.ETetrominoType.五连T块:
				result = "五连T块";
				break;
			case SlidingBlocksDefine.ETetrominoType.五连U块:
				result = "五连U块";
				break;
			case SlidingBlocksDefine.ETetrominoType.五连V块:
				result = "五连V块";
				break;
			case SlidingBlocksDefine.ETetrominoType.五连W块:
				result = "五连W块";
				break;
			case SlidingBlocksDefine.ETetrominoType.五连X块:
				result = "五连X块";
				break;
			case SlidingBlocksDefine.ETetrominoType.五连F块:
				result = "五连F块";
				break;
			case SlidingBlocksDefine.ETetrominoType.五连F1块:
				result = "五连F1块";
				break;
			case SlidingBlocksDefine.ETetrominoType.五连S块:
				result = "五连S块";
				break;
			case SlidingBlocksDefine.ETetrominoType.五连Z块:
				result = "五连Z块";
				break;
			case SlidingBlocksDefine.ETetrominoType.五连J块:
				result = "五连J块";
				break;
			case SlidingBlocksDefine.ETetrominoType.五连L块:
				result = "五连L块";
				break;
			case SlidingBlocksDefine.ETetrominoType.五连Y块:
				result = "五连Y块";
				break;
			case SlidingBlocksDefine.ETetrominoType.五连Y1块:
				result = "五连Y1块";
				break;
			case SlidingBlocksDefine.ETetrominoType.五连N块:
				result = "五连N块";
				break;
			case SlidingBlocksDefine.ETetrominoType.五连N1块:
				result = "五连N1块";
				break;
			case SlidingBlocksDefine.ETetrominoType.五连P块:
				result = "五连P块";
				break;
			case SlidingBlocksDefine.ETetrominoType.五连Q块:
				result = "五连Q块";
				break;
			case SlidingBlocksDefine.ETetrominoType.三连I块:
				result = "三连I块";
				break;
			case SlidingBlocksDefine.ETetrominoType.三连V块:
				result = "三连V块";
				break;
			case SlidingBlocksDefine.ETetrominoType.二连方块:
				result = "二连方块";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x060344DD RID: 214237 RVA: 0x00D16130 File Offset: 0x00D14330
		public static SlidingBlocksDefine.ETetrominoType FromString(string name)
		{
			SlidingBlocksDefine.ETetrominoType result;
			if (!SlidingBlocksDefine_ETetrominoTypeExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 SlidingBlocksDefine.ETetrominoType 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x060344DE RID: 214238 RVA: 0x00D1615C File Offset: 0x00D1435C
		public static bool TryFromString(string name, out SlidingBlocksDefine.ETetrominoType value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = SlidingBlocksDefine.ETetrominoType.I块;
				return false;
			}
			if (name != null)
			{
				switch (name.Length)
				{
				case 2:
				{
					char c = name[0];
					if (c <= 'S')
					{
						switch (c)
						{
						case 'I':
							if (name == "I块")
							{
								value = SlidingBlocksDefine.ETetrominoType.I块;
								return true;
							}
							break;
						case 'J':
							if (name == "J块")
							{
								value = SlidingBlocksDefine.ETetrominoType.J块;
								return true;
							}
							break;
						case 'K':
						case 'M':
						case 'N':
							break;
						case 'L':
							if (name == "L块")
							{
								value = SlidingBlocksDefine.ETetrominoType.L块;
								return true;
							}
							break;
						case 'O':
							if (name == "O块")
							{
								value = SlidingBlocksDefine.ETetrominoType.O块;
								return true;
							}
							break;
						default:
							if (c == 'S')
							{
								if (name == "S块")
								{
									value = SlidingBlocksDefine.ETetrominoType.S块;
									return true;
								}
							}
							break;
						}
					}
					else if (c != 'T')
					{
						if (c == 'Z')
						{
							if (name == "Z块")
							{
								value = SlidingBlocksDefine.ETetrominoType.Z块;
								return true;
							}
						}
					}
					else if (name == "T块")
					{
						value = SlidingBlocksDefine.ETetrominoType.T块;
						return true;
					}
					break;
				}
				case 4:
				{
					char c = name[2];
					switch (c)
					{
					case 'F':
						if (name == "五连F块")
						{
							value = SlidingBlocksDefine.ETetrominoType.五连F块;
							return true;
						}
						break;
					case 'G':
					case 'H':
					case 'K':
					case 'M':
					case 'O':
					case 'R':
						break;
					case 'I':
						if (name == "五连I块")
						{
							value = SlidingBlocksDefine.ETetrominoType.五连I块;
							return true;
						}
						if (name == "三连I块")
						{
							value = SlidingBlocksDefine.ETetrominoType.三连I块;
							return true;
						}
						break;
					case 'J':
						if (name == "五连J块")
						{
							value = SlidingBlocksDefine.ETetrominoType.五连J块;
							return true;
						}
						break;
					case 'L':
						if (name == "五连L块")
						{
							value = SlidingBlocksDefine.ETetrominoType.五连L块;
							return true;
						}
						break;
					case 'N':
						if (name == "五连N块")
						{
							value = SlidingBlocksDefine.ETetrominoType.五连N块;
							return true;
						}
						break;
					case 'P':
						if (name == "五连P块")
						{
							value = SlidingBlocksDefine.ETetrominoType.五连P块;
							return true;
						}
						break;
					case 'Q':
						if (name == "五连Q块")
						{
							value = SlidingBlocksDefine.ETetrominoType.五连Q块;
							return true;
						}
						break;
					case 'S':
						if (name == "五连S块")
						{
							value = SlidingBlocksDefine.ETetrominoType.五连S块;
							return true;
						}
						break;
					case 'T':
						if (name == "五连T块")
						{
							value = SlidingBlocksDefine.ETetrominoType.五连T块;
							return true;
						}
						break;
					case 'U':
						if (name == "五连U块")
						{
							value = SlidingBlocksDefine.ETetrominoType.五连U块;
							return true;
						}
						break;
					case 'V':
						if (name == "五连V块")
						{
							value = SlidingBlocksDefine.ETetrominoType.五连V块;
							return true;
						}
						if (name == "三连V块")
						{
							value = SlidingBlocksDefine.ETetrominoType.三连V块;
							return true;
						}
						break;
					case 'W':
						if (name == "五连W块")
						{
							value = SlidingBlocksDefine.ETetrominoType.五连W块;
							return true;
						}
						break;
					case 'X':
						if (name == "五连X块")
						{
							value = SlidingBlocksDefine.ETetrominoType.五连X块;
							return true;
						}
						break;
					case 'Y':
						if (name == "五连Y块")
						{
							value = SlidingBlocksDefine.ETetrominoType.五连Y块;
							return true;
						}
						break;
					case 'Z':
						if (name == "五连Z块")
						{
							value = SlidingBlocksDefine.ETetrominoType.五连Z块;
							return true;
						}
						break;
					default:
						if (c == '方')
						{
							if (name == "二连方块")
							{
								value = SlidingBlocksDefine.ETetrominoType.二连方块;
								return true;
							}
						}
						break;
					}
					break;
				}
				case 5:
				{
					char c = name[2];
					if (c != 'F')
					{
						if (c != 'N')
						{
							if (c == 'Y')
							{
								if (name == "五连Y1块")
								{
									value = SlidingBlocksDefine.ETetrominoType.五连Y1块;
									return true;
								}
							}
						}
						else if (name == "五连N1块")
						{
							value = SlidingBlocksDefine.ETetrominoType.五连N1块;
							return true;
						}
					}
					else if (name == "五连F1块")
					{
						value = SlidingBlocksDefine.ETetrominoType.五连F1块;
						return true;
					}
					break;
				}
				}
			}
			value = SlidingBlocksDefine.ETetrominoType.I块;
			return false;
		}

		// Token: 0x060344DF RID: 214239 RVA: 0x00D16570 File Offset: 0x00D14770
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"I块",
				"J块",
				"L块",
				"O块",
				"S块",
				"T块",
				"Z块",
				"五连I块",
				"五连T块",
				"五连U块",
				"五连V块",
				"五连W块",
				"五连X块",
				"五连F块",
				"五连F1块",
				"五连S块",
				"五连Z块",
				"五连J块",
				"五连L块",
				"五连Y块",
				"五连Y1块",
				"五连N块",
				"五连N1块",
				"五连P块",
				"五连Q块",
				"三连I块",
				"三连V块",
				"二连方块"
			};
		}

		// Token: 0x060344E0 RID: 214240 RVA: 0x00D16677 File Offset: 0x00D14877
		public static SlidingBlocksDefine.ETetrominoType[] GetValues()
		{
			return new SlidingBlocksDefine.ETetrominoType[]
			{
				SlidingBlocksDefine.ETetrominoType.I块,
				SlidingBlocksDefine.ETetrominoType.J块,
				SlidingBlocksDefine.ETetrominoType.L块,
				SlidingBlocksDefine.ETetrominoType.O块,
				SlidingBlocksDefine.ETetrominoType.S块,
				SlidingBlocksDefine.ETetrominoType.T块,
				SlidingBlocksDefine.ETetrominoType.Z块,
				SlidingBlocksDefine.ETetrominoType.五连I块,
				SlidingBlocksDefine.ETetrominoType.五连T块,
				SlidingBlocksDefine.ETetrominoType.五连U块,
				SlidingBlocksDefine.ETetrominoType.五连V块,
				SlidingBlocksDefine.ETetrominoType.五连W块,
				SlidingBlocksDefine.ETetrominoType.五连X块,
				SlidingBlocksDefine.ETetrominoType.五连F块,
				SlidingBlocksDefine.ETetrominoType.五连F1块,
				SlidingBlocksDefine.ETetrominoType.五连S块,
				SlidingBlocksDefine.ETetrominoType.五连Z块,
				SlidingBlocksDefine.ETetrominoType.五连J块,
				SlidingBlocksDefine.ETetrominoType.五连L块,
				SlidingBlocksDefine.ETetrominoType.五连Y块,
				SlidingBlocksDefine.ETetrominoType.五连Y1块,
				SlidingBlocksDefine.ETetrominoType.五连N块,
				SlidingBlocksDefine.ETetrominoType.五连N1块,
				SlidingBlocksDefine.ETetrominoType.五连P块,
				SlidingBlocksDefine.ETetrominoType.五连Q块,
				SlidingBlocksDefine.ETetrominoType.三连I块,
				SlidingBlocksDefine.ETetrominoType.三连V块,
				SlidingBlocksDefine.ETetrominoType.二连方块
			};
		}

		// Token: 0x060344E1 RID: 214241 RVA: 0x00D1668C File Offset: 0x00D1488C
		public static string[] GetNames()
		{
			return new string[]
			{
				"I块",
				"J块",
				"L块",
				"O块",
				"S块",
				"T块",
				"Z块",
				"五连I块",
				"五连T块",
				"五连U块",
				"五连V块",
				"五连W块",
				"五连X块",
				"五连F块",
				"五连F1块",
				"五连S块",
				"五连Z块",
				"五连J块",
				"五连L块",
				"五连Y块",
				"五连Y1块",
				"五连N块",
				"五连N1块",
				"五连P块",
				"五连Q块",
				"三连I块",
				"三连V块",
				"二连方块"
			};
		}
	}
}
