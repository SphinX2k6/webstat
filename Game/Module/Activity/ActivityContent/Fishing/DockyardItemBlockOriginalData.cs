using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200679E RID: 26526
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardItemBlockOriginalData
	{
		// Token: 0x1700A0E0 RID: 41184
		// (get) Token: 0x06042251 RID: 270929 RVA: 0x010F84EA File Offset: 0x010F66EA
		public int IncId
		{
			get
			{
				return this.ServerData.IncrId;
			}
		}

		// Token: 0x1700A0E1 RID: 41185
		// (get) Token: 0x06042252 RID: 270930 RVA: 0x010F84F7 File Offset: 0x010F66F7
		public int ItemId
		{
			get
			{
				return this.ServerData.ItemId;
			}
		}

		// Token: 0x1700A0E2 RID: 41186
		// (get) Token: 0x06042253 RID: 270931 RVA: 0x010F8504 File Offset: 0x010F6704
		public int Quality
		{
			get
			{
				return this.ServerData.Quality;
			}
		}

		// Token: 0x1700A0E3 RID: 41187
		// (get) Token: 0x06042254 RID: 270932 RVA: 0x010F8511 File Offset: 0x010F6711
		public int Size
		{
			get
			{
				return this.ServerData.Size;
			}
		}

		// Token: 0x1700A0E4 RID: 41188
		// (get) Token: 0x06042255 RID: 270933 RVA: 0x010F851E File Offset: 0x010F671E
		public int Price
		{
			get
			{
				return this.ServerData.Price;
			}
		}

		// Token: 0x1700A0E5 RID: 41189
		// (get) Token: 0x06042256 RID: 270934 RVA: 0x010F852B File Offset: 0x010F672B
		public int Cup
		{
			get
			{
				return (int)this.ServerData.Cup;
			}
		}

		// Token: 0x1700A0E6 RID: 41190
		// (get) Token: 0x06042257 RID: 270935 RVA: 0x010F8538 File Offset: 0x010F6738
		public FishingItemRotate Rotate
		{
			get
			{
				return this.ServerData.Rotate;
			}
		}

		// Token: 0x1700A0E7 RID: 41191
		// (get) Token: 0x06042258 RID: 270936 RVA: 0x010F8545 File Offset: 0x010F6745
		public int PosX
		{
			get
			{
				return this.ServerData.Pos.X;
			}
		}

		// Token: 0x1700A0E8 RID: 41192
		// (get) Token: 0x06042259 RID: 270937 RVA: 0x010F8557 File Offset: 0x010F6757
		public int PosY
		{
			get
			{
				return this.ServerData.Pos.Y;
			}
		}

		// Token: 0x1700A0E9 RID: 41193
		// (get) Token: 0x0604225A RID: 270938 RVA: 0x010F8569 File Offset: 0x010F6769
		public bool IsCanSell
		{
			get
			{
				return this.ServerData.Price > 0;
			}
		}

		// Token: 0x0604225B RID: 270939 RVA: 0x010F857C File Offset: 0x010F677C
		public DockyardItemBlockOriginalData(FishingItemInfo data)
		{
			this.ServerData = data;
			FishingItem? fishingItemConfig = ConfigBase<FishingConfig>.Instance.GetFishingItemConfig(this.ServerData.ItemId);
			IntArray[] array = ConfigBase<FishingConfig>.Instance.GetFishingShapeConfig(fishingItemConfig.Value.Shap).FillState();
			int num = -1;
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			int i = 0;
			int num5 = array.Length;
			while (i < num5)
			{
				this.PosDoublyList.Add(new List<int>());
				int j = 0;
				int arrayIntLength = array[i].ArrayIntLength;
				while (j < arrayIntLength)
				{
					int num6 = array[i].ArrayInt(j);
					this.PosDoublyList[i].Add(num6);
					this.PosDataList.Add(new PanelPos
					{
						RowIndex = i,
						ColIndex = j
					});
					if (num6 == 1)
					{
						num = ((num == -1) ? i : Math.Min(num, i));
						num2 = ((num2 == -1) ? i : Math.Max(num2, i));
						num3 = ((num3 == -1) ? j : Math.Min(num3, j));
						num4 = ((num4 == -1) ? j : Math.Max(num4, j));
					}
					j++;
				}
				i++;
			}
			this.ValidStartPos = new PanelPos
			{
				RowIndex = num,
				ColIndex = num3
			};
			for (int k = 0; k < num2 - num + 1; k++)
			{
				this.ValidDoublyList.Add(new List<int>());
				for (int l = 0; l < num4 - num3 + 1; l++)
				{
					this.ValidDoublyList[k].Add(this.PosDoublyList[k + num][l + num3]);
				}
			}
		}

		// Token: 0x0604225C RID: 270940 RVA: 0x010F877D File Offset: 0x010F697D
		public FishingItemInfo GetServerData()
		{
			return this.ServerData;
		}

		// Token: 0x04024DB2 RID: 150962
		private readonly FishingItemInfo ServerData;

		// Token: 0x04024DB3 RID: 150963
		public List<List<int>> PosDoublyList = new List<List<int>>();

		// Token: 0x04024DB4 RID: 150964
		public List<List<int>> ValidDoublyList = new List<List<int>>();

		// Token: 0x04024DB5 RID: 150965
		public readonly List<IPanelPos> PosDataList = new List<IPanelPos>();

		// Token: 0x04024DB6 RID: 150966
		public IPanelPos ValidStartPos = new PanelPos
		{
			RowIndex = -1,
			ColIndex = -1
		};
	}
}
