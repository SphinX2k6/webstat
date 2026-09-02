using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.ActivityGamePlay.Drinks;

// Token: 0x02000FF7 RID: 4087
[NullableContext(1)]
[Nullable(0)]
public class DrinksData
{
	// Token: 0x06006A0E RID: 27150 RVA: 0x001BADB8 File Offset: 0x001B8FB8
	public unsafe void Init(int roleId, int? requireId = null)
	{
		this.CurStep = EDrinksPlayStep.Drink1;
		this.RoleId = roleId;
		DrinksResultInfo drinksResultInfo = new DrinksResultInfo();
		drinksResultInfo.RequireId = 0;
		int num = 2;
		List<int> list = new List<int>(num);
		CollectionsMarshal.SetCount<int>(list, num);
		Span<int> span = CollectionsMarshal.AsSpan<int>(list);
		int num2 = 0;
		*span[num2] = 0;
		num2++;
		*span[num2] = 0;
		drinksResultInfo.DrinkBase = list;
		drinksResultInfo.Ornament = 0;
		this.Data = drinksResultInfo;
		List<EDrinksPlayStep> list2 = new List<EDrinksPlayStep>(this.SelectedEndMap.Keys);
		for (int i = 0; i < list2.Count; i++)
		{
			this.SelectedEndMap[list2[i]] = false;
		}
		this.FlavorValue = new int[3];
		if (requireId == null)
		{
			IReadOnlyList<DrinksRequireList> requireListByRole = ConfigBase<DrinksConfig>.Instance.GetRequireListByRole(roleId);
			this.RequireId = Singleton<MathUtils>.Instance.GetRandomItem<DrinksRequireList>(requireListByRole).Id;
		}
		else
		{
			this.RequireId = requireId.Value;
		}
		this.Data.RequireId = this.RequireId;
		this.GetRandomSort();
	}

	// Token: 0x06006A0F RID: 27151 RVA: 0x001BAEBF File Offset: 0x001B90BF
	public DrinksResultInfo GetCurData()
	{
		return this.Data;
	}

	// Token: 0x06006A10 RID: 27152 RVA: 0x001BAEC8 File Offset: 0x001B90C8
	public int[] UpdateFlavorValue()
	{
		int[] array = new int[3];
		EDrinksPlayStep curStep = ModelBase<DrinksModel>.Instance.GetCurStep();
		if (curStep > EDrinksPlayStep.Drink1)
		{
			foreach (KeyValuePair<int, int> keyValuePair in ConfigBase<DrinksConfig>.Instance.GetDrinkBase(this.Data.DrinkBase[0]).Value.Flavor())
			{
				array[keyValuePair.Key] += keyValuePair.Value;
			}
		}
		if (curStep > EDrinksPlayStep.Drink2)
		{
			foreach (KeyValuePair<int, int> keyValuePair2 in ConfigBase<DrinksConfig>.Instance.GetDrinkBase(this.Data.DrinkBase[1]).Value.Flavor())
			{
				array[keyValuePair2.Key] += keyValuePair2.Value;
			}
		}
		if (this.Data.Batching != null && curStep > EDrinksPlayStep.Batching)
		{
			foreach (int id in this.Data.Batching)
			{
				foreach (KeyValuePair<int, int> keyValuePair3 in ConfigBase<DrinksConfig>.Instance.GetBatching(id).Value.Flavor())
				{
					array[keyValuePair3.Key] += keyValuePair3.Value;
				}
			}
		}
		for (int i = 0; i < 3; i++)
		{
			this.FlavorValue[i] = array[i];
		}
		return this.FlavorValue;
	}

	// Token: 0x06006A11 RID: 27153 RVA: 0x001BB0D0 File Offset: 0x001B92D0
	public int[] GetFlavorValue()
	{
		return this.FlavorValue;
	}

	// Token: 0x06006A12 RID: 27154 RVA: 0x001BB0D8 File Offset: 0x001B92D8
	public int GetRequireId()
	{
		return this.RequireId;
	}

	// Token: 0x06006A13 RID: 27155 RVA: 0x001BB0E0 File Offset: 0x001B92E0
	public DrinksRequireList GetRequireConfig()
	{
		return ConfigBase<DrinksConfig>.Instance.GetRequireList(this.RequireId).Value;
	}

	// Token: 0x06006A14 RID: 27156 RVA: 0x001BB108 File Offset: 0x001B9308
	public int[] GetCurFlavor(bool force = false)
	{
		int[] array = new int[3];
		if ((this.SelectedEndMap[EDrinksPlayStep.Drink1] || force) && this.Data.DrinkBase[0] != 0)
		{
			foreach (KeyValuePair<int, int> keyValuePair in ConfigBase<DrinksConfig>.Instance.GetDrinkBase(this.Data.DrinkBase[0]).Value.Flavor())
			{
				array[keyValuePair.Key] = array[keyValuePair.Key] + keyValuePair.Value;
			}
		}
		if ((this.SelectedEndMap[EDrinksPlayStep.Drink2] || force) && this.Data.DrinkBase[1] != 0)
		{
			foreach (KeyValuePair<int, int> keyValuePair2 in ConfigBase<DrinksConfig>.Instance.GetDrinkBase(this.Data.DrinkBase[1]).Value.Flavor())
			{
				array[keyValuePair2.Key] = array[keyValuePair2.Key] + keyValuePair2.Value;
			}
		}
		if ((this.SelectedEndMap[EDrinksPlayStep.Batching] || force) && this.Data.Batching != null)
		{
			foreach (int id in this.Data.Batching)
			{
				foreach (KeyValuePair<int, int> keyValuePair3 in ConfigBase<DrinksConfig>.Instance.GetBatching(id).Value.Flavor())
				{
					array[keyValuePair3.Key] = array[keyValuePair3.Key] + keyValuePair3.Value;
				}
			}
		}
		return array;
	}

	// Token: 0x06006A15 RID: 27157 RVA: 0x001BB338 File Offset: 0x001B9538
	public void UpdateBase(int step, int id)
	{
		if (this.Data == null)
		{
			return;
		}
		this.Data.DrinkBase[step] = id;
		for (int i = step + 1; i < this.Data.DrinkBase.Count; i++)
		{
			this.Data.DrinkBase[i] = 0;
		}
	}

	// Token: 0x06006A16 RID: 27158 RVA: 0x001BB38F File Offset: 0x001B958F
	public void UpdateBatching(HashSet<int> set)
	{
		if (this.Data == null || set.Count > 2)
		{
			return;
		}
		this.Data.Batching = new List<int>(set);
	}

	// Token: 0x06006A17 RID: 27159 RVA: 0x001BB3B4 File Offset: 0x001B95B4
	public void UpdateOrnament(int id)
	{
		if (this.Data == null)
		{
			return;
		}
		this.Data.Ornament = id;
		DrinksSceneController sceneController = ModelBase<DrinksModel>.Instance.GetSceneController();
		int roleId = ModelBase<DrinksModel>.Instance.GetRoleId();
		sceneController.OnSetOrnament(id, roleId, null, true);
	}

	// Token: 0x06006A18 RID: 27160 RVA: 0x001BB3F4 File Offset: 0x001B95F4
	public EDrinksPlayStep GetCurStep()
	{
		return this.CurStep;
	}

	// Token: 0x06006A19 RID: 27161 RVA: 0x001BB3FC File Offset: 0x001B95FC
	public void EnterNextStep()
	{
		this.CurStep = DrinksData.NextStep[(int)this.CurStep];
	}

	// Token: 0x06006A1A RID: 27162 RVA: 0x001BB410 File Offset: 0x001B9610
	public void BackToPrevStep()
	{
		if (this.CurStep == EDrinksPlayStep.Drink2)
		{
			this.SelectedEndMap[EDrinksPlayStep.Drink1] = false;
			this.UpdateBase(0, this.GetDrinkBaseShowId(this.Data.DrinkBase[0]));
		}
		else if (this.CurStep == EDrinksPlayStep.Batching)
		{
			this.SelectedEndMap[EDrinksPlayStep.Drink2] = false;
			this.UpdateBatching(new HashSet<int>());
			this.UpdateBase(1, this.GetDrinkBaseShowId(this.Data.DrinkBase[1]));
		}
		else if (this.CurStep == EDrinksPlayStep.Ornament)
		{
			this.UpdateOrnament(0);
			this.SelectedEndMap[EDrinksPlayStep.Batching] = false;
		}
		ModelBase<DrinksModel>.Instance.GetSceneController().OnBackToBeforeOrnament();
		this.CurStep = DrinksData.PrevStep[(int)this.CurStep];
		this.UpdateFlavorValue();
	}

	// Token: 0x06006A1B RID: 27163 RVA: 0x001BB4DC File Offset: 0x001B96DC
	public unsafe void RestartGame()
	{
		DrinksResultInfo data = this.Data;
		int num = 2;
		List<int> list = new List<int>(num);
		CollectionsMarshal.SetCount<int>(list, num);
		Span<int> span = CollectionsMarshal.AsSpan<int>(list);
		int num2 = 0;
		*span[num2] = 0;
		num2++;
		*span[num2] = 0;
		data.DrinkBase = list;
		this.Data.Ornament = 0;
		this.Data.Batching = null;
		this.CurStep = EDrinksPlayStep.Drink1;
		ModelBase<DrinksModel>.Instance.GetSceneController().OnBackToBeforeOrnament();
		List<EDrinksPlayStep> list2 = new List<EDrinksPlayStep>(this.SelectedEndMap.Keys);
		for (int i = 0; i < list2.Count; i++)
		{
			this.SelectedEndMap[list2[i]] = false;
		}
		this.UpdateFlavorValue();
	}

	// Token: 0x06006A1C RID: 27164 RVA: 0x001BB593 File Offset: 0x001B9793
	public int GetDrinkBaseShowId(int id)
	{
		return ModelBase<DrinksModel>.Instance.GetDrinksByBaseId(id).GetMenuBaseId();
	}

	// Token: 0x06006A1D RID: 27165 RVA: 0x001BB5A8 File Offset: 0x001B97A8
	[NullableContext(2)]
	public DrinksDialogBubbleInfo GetDialogBubbleInfo(int inId)
	{
		if (this.CurStep == EDrinksPlayStep.Ornament && inId == 0)
		{
			return null;
		}
		DrinksRequireList requireConfig = this.GetRequireConfig();
		DrinksDialogBubbleInfo drinksDialogBubbleInfo = new DrinksDialogBubbleInfo
		{
			ConfigId = "",
			IsLike = false
		};
		foreach (int id in requireConfig.GetRoleLikeSettingArray() ?? Array.Empty<int>())
		{
			DrinksRoleLikeDrink value = ConfigBase<DrinksConfig>.Instance.GetRoleLikeDrink(id).Value;
			if (this.CurStep <= EDrinksPlayStep.Drink2)
			{
				int id2 = ModelBase<DrinksModel>.Instance.GetDrinksByBaseId(inId).Id;
				foreach (int num in value.GetLinkDrinkBaseArray() ?? Array.Empty<int>())
				{
					if (id2 == num)
					{
						string format = value.LikeStatus ? "Dialog_{0}_Like0{1}" : "Dialog_{0}_Dislike0{1}";
						string randomId = this.GetRandomId();
						drinksDialogBubbleInfo.ConfigId = string.Format(format, this.RoleId.ToString(), randomId);
						drinksDialogBubbleInfo.IsLike = value.LikeStatus;
						return drinksDialogBubbleInfo;
					}
				}
			}
			else if (this.CurStep == EDrinksPlayStep.Batching)
			{
				int[] array2 = value.GetLinkBatchingArray() ?? Array.Empty<int>();
				for (int j = 0; j < array2.Length; j++)
				{
					if (array2[j] == inId)
					{
						string format2 = value.LikeStatus ? "Dialog_{0}_Like0{1}" : "Dialog_{0}_Dislike0{1}";
						string randomId2 = this.GetRandomId();
						drinksDialogBubbleInfo.ConfigId = string.Format(format2, this.RoleId.ToString(), randomId2);
						drinksDialogBubbleInfo.IsLike = value.LikeStatus;
						return drinksDialogBubbleInfo;
					}
				}
			}
			else
			{
				int[] array2 = value.GetLinkOrnamentArray() ?? Array.Empty<int>();
				for (int j = 0; j < array2.Length; j++)
				{
					if (array2[j] == inId)
					{
						string format3 = value.LikeStatus ? "Dialog_{0}_Like0{1}" : "Dialog_{0}_Dislike0{1}";
						string randomId3 = this.GetRandomId();
						drinksDialogBubbleInfo.ConfigId = string.Format(format3, this.RoleId.ToString(), randomId3);
						drinksDialogBubbleInfo.IsLike = value.LikeStatus;
						return drinksDialogBubbleInfo;
					}
				}
			}
		}
		return null;
	}

	// Token: 0x06006A1E RID: 27166 RVA: 0x001BB7B6 File Offset: 0x001B99B6
	[NullableContext(2)]
	public DrinksDialogBubbleInfo GetDialogHintBubbleInfo()
	{
		if (this.CurStep != EDrinksPlayStep.Ornament)
		{
			return null;
		}
		return this.GetDialogBubbleInfoOrnament();
	}

	// Token: 0x06006A1F RID: 27167 RVA: 0x001BB7CC File Offset: 0x001B99CC
	[NullableContext(2)]
	private DrinksDialogBubbleInfo GetDialogBubbleInfoOrnament()
	{
		DrinksRequireList value = ConfigBase<DrinksConfig>.Instance.GetRequireList(this.RequireId).Value;
		string text = "";
		foreach (int id in value.GetRoleLikeSettingArray() ?? Array.Empty<int>())
		{
			DrinksRoleLikeDrink value2 = ConfigBase<DrinksConfig>.Instance.GetRoleLikeDrink(id).Value;
			if (value2.OrnamentHintId != "")
			{
				text = value2.OrnamentHintId;
			}
		}
		if (text == "")
		{
			return null;
		}
		return new DrinksDialogBubbleInfo
		{
			ConfigId = text,
			IsLike = true
		};
	}

	// Token: 0x06006A20 RID: 27168 RVA: 0x001BB875 File Offset: 0x001B9A75
	public void UpdateStepEnd(EDrinksPlayStep step, bool value)
	{
		this.SelectedEndMap[step] = value;
	}

	// Token: 0x06006A21 RID: 27169 RVA: 0x001BB884 File Offset: 0x001B9A84
	private void GetRandomSort()
	{
		this.RandomSort.Clear();
		this.RandomSort = Singleton<MathUtils>.Instance.Shuffle<int>(new int[]
		{
			1,
			2,
			3
		}).ToList<int>();
	}

	// Token: 0x06006A22 RID: 27170 RVA: 0x001BB8B8 File Offset: 0x001B9AB8
	private string GetRandomId()
	{
		if (this.RandomSort.Count == 0)
		{
			this.GetRandomSort();
		}
		int num = this.RandomSort[0];
		this.RandomSort.RemoveAt(0);
		return num.ToString();
	}

	// Token: 0x0400325A RID: 12890
	[StaticVariableRuleIgnore]
	private static EDrinksPlayStep[] PrevStep = new EDrinksPlayStep[]
	{
		EDrinksPlayStep.Drink1,
		EDrinksPlayStep.Drink1,
		EDrinksPlayStep.Drink2,
		EDrinksPlayStep.Drink2,
		EDrinksPlayStep.Batching
	};

	// Token: 0x0400325B RID: 12891
	[StaticVariableRuleIgnore]
	private static EDrinksPlayStep[] NextStep = new EDrinksPlayStep[]
	{
		EDrinksPlayStep.Drink2,
		EDrinksPlayStep.Batching,
		EDrinksPlayStep.Ornament,
		EDrinksPlayStep.Ornament
	};

	// Token: 0x0400325C RID: 12892
	private const string BUBBLE_DRINK_LIKE = "Dialog_{0}_Like0{1}";

	// Token: 0x0400325D RID: 12893
	private const string BUBBLE_DRINK_DISLIKE = "Dialog_{0}_Dislike0{1}";

	// Token: 0x0400325E RID: 12894
	public EDrinksPlayStep CurStep;

	// Token: 0x0400325F RID: 12895
	[Nullable(2)]
	public DrinksResultInfo Data;

	// Token: 0x04003260 RID: 12896
	public int RoleId;

	// Token: 0x04003261 RID: 12897
	public int RequireId;

	// Token: 0x04003262 RID: 12898
	protected int[] FlavorValue = new int[3];

	// Token: 0x04003263 RID: 12899
	protected List<int> RandomSort = new List<int>();

	// Token: 0x04003264 RID: 12900
	public Dictionary<EDrinksPlayStep, bool> SelectedEndMap = new Dictionary<EDrinksPlayStep, bool>
	{
		{
			EDrinksPlayStep.Drink1,
			false
		},
		{
			EDrinksPlayStep.Drink2,
			false
		},
		{
			EDrinksPlayStep.Batching,
			false
		},
		{
			EDrinksPlayStep.Ornament,
			false
		}
	};
}
