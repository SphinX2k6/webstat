using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001006 RID: 4102
[NullableContext(1)]
[Nullable(0)]
public class DrinksSoftDrinkData
{
	// Token: 0x06006A90 RID: 27280 RVA: 0x001BD591 File Offset: 0x001BB791
	public DrinksSoftDrinkData(int id)
	{
		this._id = id;
	}

	// Token: 0x17000842 RID: 2114
	// (get) Token: 0x06006A91 RID: 27281 RVA: 0x001BD5B6 File Offset: 0x001BB7B6
	public int Id
	{
		get
		{
			return this._id;
		}
	}

	// Token: 0x06006A92 RID: 27282 RVA: 0x001BD5BE File Offset: 0x001BB7BE
	public void UpdateConfig(int count, int configId)
	{
		this.CountMap[count] = configId;
	}

	// Token: 0x06006A93 RID: 27283 RVA: 0x001BD5D0 File Offset: 0x001BB7D0
	public Dictionary<int, int[]> GetFlavorRange()
	{
		if (this.FlavorRange.Count > 0)
		{
			return this.FlavorRange;
		}
		foreach (KeyValuePair<int, int> keyValuePair in this.CountMap)
		{
			int value = keyValuePair.Value;
			foreach (KeyValuePair<int, int> keyValuePair2 in ConfigBase<DrinksConfig>.Instance.GetDrinkBase(value).Value.Flavor())
			{
				int key = keyValuePair2.Key;
				int value2 = keyValuePair2.Value;
				int[] array;
				if (!this.FlavorRange.TryGetValue(key, out array))
				{
					this.FlavorRange[key] = new int[]
					{
						value2,
						value2
					};
				}
				else
				{
					int num = array[0];
					int num2 = array[1];
					if (value2 < num)
					{
						this.FlavorRange[key] = new int[]
						{
							value2,
							num2
						};
					}
					else if (value2 > num2)
					{
						this.FlavorRange[key] = new int[]
						{
							num,
							value2
						};
					}
				}
			}
		}
		return this.FlavorRange;
	}

	// Token: 0x06006A94 RID: 27284 RVA: 0x001BD74C File Offset: 0x001BB94C
	public int GetMenuBaseId()
	{
		return this.CountMap[1];
	}

	// Token: 0x06006A95 RID: 27285 RVA: 0x001BD75C File Offset: 0x001BB95C
	public int[] GetAllBaseId()
	{
		int[] array = (this.CountMap.Count == 2) ? new int[2] : new int[3];
		foreach (KeyValuePair<int, int> keyValuePair in this.CountMap)
		{
			array[keyValuePair.Key - 1] = keyValuePair.Value;
		}
		return array;
	}

	// Token: 0x04003296 RID: 12950
	protected Dictionary<int, int> CountMap = new Dictionary<int, int>();

	// Token: 0x04003297 RID: 12951
	protected Dictionary<int, int[]> FlavorRange = new Dictionary<int, int[]>();

	// Token: 0x04003298 RID: 12952
	private readonly int _id;
}
