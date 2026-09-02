using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200590D RID: 22797
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueDefine
	{
		// Token: 0x06039DD5 RID: 237013 RVA: 0x00EA6B62 File Offset: 0x00EA4D62
		public static int GridLocationToIndex(int x, int y, int width)
		{
			return y * width + x;
		}

		// Token: 0x06039DD6 RID: 237014 RVA: 0x00EA6B6C File Offset: 0x00EA4D6C
		public static MapRogueMapPoint IndexToGridLocation(int index, int width)
		{
			int x = index % width;
			int y = (int)Math.Floor((double)index / (double)width);
			return new MapRogueMapPoint
			{
				X = x,
				Y = y
			};
		}

		// Token: 0x06039DD7 RID: 237015 RVA: 0x00EA6B9C File Offset: 0x00EA4D9C
		public static int[] ParseNumbers(string input, string separator = "#")
		{
			string[] array = input.Split(separator, StringSplitOptions.None);
			List<int> list = new List<int>();
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				int item;
				if (!int.TryParse(array2[i], out item))
				{
					return new int[0];
				}
				list.Add(item);
			}
			return list.ToArray();
		}

		// Token: 0x06039DD8 RID: 237016 RVA: 0x00EA6BE8 File Offset: 0x00EA4DE8
		public static bool InAxisAlignedDiamond(int x, int y, IGridRangeInfo info)
		{
			double num = Math.Abs((double)x - info.CenterX) / info.RadiusX;
			double num2 = Math.Abs((double)y - info.CenterY) / info.RadiusY;
			return num + num2 <= 1.0;
		}

		// Token: 0x06039DD9 RID: 237017 RVA: 0x00EA6C34 File Offset: 0x00EA4E34
		public static GridPopupView popupModelBaseGenerator(MapGridData gridData, MapRogueGameInfo gameInfo)
		{
			GridPopupViewModelBase vm;
			switch (gridData.GridEventType)
			{
			case EGridEventType.Blank:
				vm = new GridPopupViewModelBlank(gridData, gameInfo);
				break;
			case EGridEventType.Event:
				vm = new GridPopupViewModelEvent(gridData, gameInfo);
				break;
			case EGridEventType.Battle:
				vm = new GridPopupViewModelBattle(gridData, gameInfo);
				break;
			case EGridEventType.Boss:
				vm = new GridPopupViewModelBoss(gridData, gameInfo);
				break;
			default:
				vm = new GridPopupViewModelBlank(gridData, gameInfo);
				break;
			}
			return new GridPopupView(vm);
		}

		// Token: 0x04020C9E RID: 134302
		public const int TYPE_EVENT_WEIGHT = 1000000;

		// Token: 0x04020C9F RID: 134303
		public const int THOUSANDTH_RATIO = 1000;
	}
}
