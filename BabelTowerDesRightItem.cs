using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200120F RID: 4623
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerDesRightItem : UiPanelBase
{
	// Token: 0x06007A65 RID: 31333 RVA: 0x001FEC1C File Offset: 0x001FCE1C
	public void SetLevelId(int levelId)
	{
		BabelTowerLevel? config = ConfigBabelTowerLevelById.GetConfig(levelId, true);
		if (config != null)
		{
			BabelTowerLevel valueOrDefault = config.GetValueOrDefault();
			this.MonstMaxLifeAddRatioMap = new Dictionary<int, int>();
			for (int i = 0; i < valueOrDefault.MonstMaxLifeAddRatioLength; i++)
			{
				DicIntInt? dicIntInt = valueOrDefault.MonstMaxLifeAddRatio(i);
				if (dicIntInt != null)
				{
					DicIntInt valueOrDefault2 = dicIntInt.GetValueOrDefault();
					this.MonstMaxLifeAddRatioMap[valueOrDefault2.Key] = valueOrDefault2.Value;
				}
			}
		}
		else
		{
			this.MonstMaxLifeAddRatioMap = new Dictionary<int, int>();
		}
		if (this.MonstMaxLifeAddRatioMap.Count <= 0)
		{
			UUIItem item = base.GetItem(9);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}
	}

	// Token: 0x06007A66 RID: 31334 RVA: 0x001FECC4 File Offset: 0x001FCEC4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickGoBtnHandler));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007A67 RID: 31335 RVA: 0x001FEE96 File Offset: 0x001FD096
	protected override void OnStart()
	{
		this.BuffScrollView = new GenericScrollViewNew<DesRightBuffGridItem, int>(base.GetScrollViewWithScrollbar(2), new Func<DesRightBuffGridItem>(this.InitBuffItem), base.GetItem(3).GetOwner() as AUIBaseActor, false, null);
	}

	// Token: 0x06007A68 RID: 31336 RVA: 0x001FEEC9 File Offset: 0x001FD0C9
	private DesRightBuffGridItem InitBuffItem()
	{
		return new DesRightBuffGridItem
		{
			SkipDestroyActor = true,
			OnClickCallBack = delegate(int deTermId)
			{
				Action<int> onBuffClick = this.OnBuffClick;
				if (onBuffClick == null)
				{
					return;
				}
				onBuffClick(deTermId);
			}
		};
	}

	// Token: 0x06007A69 RID: 31337 RVA: 0x001FEEEC File Offset: 0x001FD0EC
	public void RefreshBuffList(int scrollToDeTermId = 0)
	{
		List<int> list = this.BuildDeTermIdList();
		GenericScrollViewNew<DesRightBuffGridItem, int> buffScrollView = this.BuffScrollView;
		UUIItem item;
		if (buffScrollView != null)
		{
			buffScrollView.RefreshByData(list, delegate
			{
				if (scrollToDeTermId > 0)
				{
					using (List<DesRightBuffGridItem>.Enumerator enumerator = this.BuffScrollView.GetScrollItemList().GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							DesRightBuffGridItem item = enumerator.Current;
							if (item.DeTermId == scrollToDeTermId)
							{
								this.BuffScrollView.LateScrollTo(item.GetRootItem(), delegate
								{
									item.PlayStartSequence();
								}, false);
								break;
							}
						}
					}
				}
			}, false);
		}
		int count = list.Count;
		this.SetDeBuffItemNum(count);
		item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(list.Count <= 0);
		}
		this.UpdateTipInfo(list);
	}

	// Token: 0x06007A6A RID: 31338 RVA: 0x001FEF68 File Offset: 0x001FD168
	private void UpdateTipInfo(List<int> deTermIdList)
	{
		if (deTermIdList.Count <= 0)
		{
			this.SetTipInfoText("");
			return;
		}
		int num = 0;
		foreach (int p0Id in deTermIdList)
		{
			BabelTowerDeTerm? config = ConfigBabelTowerDeTermById.GetConfig(p0Id, true);
			if (config != null)
			{
				num += config.GetValueOrDefault().Star;
			}
		}
		int? ratioValue = this.GetRatioValue(num);
		if (ratioValue != null)
		{
			this.SetTipInfoText(((float)ratioValue.Value / 100f + 100f).ToString() ?? "");
			return;
		}
		this.SetTipInfoText("");
	}

	// Token: 0x06007A6B RID: 31339 RVA: 0x001FF034 File Offset: 0x001FD234
	private int? GetRatioValue(int starNum)
	{
		int value;
		if (this.MonstMaxLifeAddRatioMap.TryGetValue(starNum, out value))
		{
			return new int?(value);
		}
		int num = int.MinValue;
		foreach (int num2 in this.MonstMaxLifeAddRatioMap.Keys)
		{
			if (num2 > num)
			{
				num = num2;
			}
		}
		if (num != -2147483648 && starNum > num)
		{
			return new int?(this.MonstMaxLifeAddRatioMap[num]);
		}
		return null;
	}

	// Token: 0x06007A6C RID: 31340 RVA: 0x001FF0D0 File Offset: 0x001FD2D0
	private void SetTipInfoText(string text)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "Babelstar_xueliang", new <>z__ReadOnlySingleElementList<object>(text));
	}

	// Token: 0x06007A6D RID: 31341 RVA: 0x001FF0F0 File Offset: 0x001FD2F0
	public void ScrollToDeTerm(int deTermId)
	{
		if (this.BuffScrollView == null || deTermId == 0)
		{
			return;
		}
		int num = this.BuildDeTermIdList().IndexOf(deTermId);
		if (num >= 0)
		{
			this.BuffScrollView.ScrollToTopByIndex(num);
		}
	}

	// Token: 0x06007A6E RID: 31342 RVA: 0x001FF128 File Offset: 0x001FD328
	private List<int> BuildDeTermIdList()
	{
		Dictionary<int, IBabelTowerSelectInfo> map = ModelBase<BabelTowerModel>.Instance.DeTermSelectInfo;
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, IBabelTowerSelectInfo> keyValuePair in map)
		{
			int key = keyValuePair.Key;
			IBabelTowerSelectInfo value = keyValuePair.Value;
			if (key != 0 && (value.State == EBabelTowerDeTermState.Select || value.State == EBabelTowerDeTermState.StaticSelect))
			{
				list.Add(key);
			}
		}
		list.Sort(delegate(int a, int b)
		{
			IBabelTowerSelectInfo valueOrDefault = map.GetValueOrDefault(a);
			IBabelTowerSelectInfo valueOrDefault2 = map.GetValueOrDefault(b);
			if (valueOrDefault == null || valueOrDefault2 == null)
			{
				return 0;
			}
			return valueOrDefault2.SelectIndex - valueOrDefault.SelectIndex;
		});
		return list;
	}

	// Token: 0x06007A6F RID: 31343 RVA: 0x001FF1D8 File Offset: 0x001FD3D8
	public void SetStarNum(int starNum)
	{
		UUIArtText artText = base.GetArtText(4);
		if (artText != null)
		{
			artText.SetText(((starNum < 10) ? "0" : "") + starNum.ToString());
		}
	}

	// Token: 0x06007A70 RID: 31344 RVA: 0x001FF214 File Offset: 0x001FD414
	public void SetMaxRecordText(int starNum)
	{
		UUIText text = base.GetText(7);
		if (text != null)
		{
			text.SetText(starNum.ToString() ?? "", true);
		}
	}

	// Token: 0x06007A71 RID: 31345 RVA: 0x001FF243 File Offset: 0x001FD443
	public void SetColorBg(FColor color)
	{
		UUITexture texture = base.GetTexture(5);
		if (texture == null)
		{
			return;
		}
		texture.SetColor(color);
	}

	// Token: 0x06007A72 RID: 31346 RVA: 0x001FF257 File Offset: 0x001FD457
	public void SetDifficultyText(string textKey)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), textKey, Array.Empty<object>());
	}

	// Token: 0x06007A73 RID: 31347 RVA: 0x001FF270 File Offset: 0x001FD470
	private void SetDeBuffItemNum(int count)
	{
		UUIText text = base.GetText(0);
		if (text != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "BabelLoad_Quantity", new <>z__ReadOnlySingleElementList<object>(count));
		}
	}

	// Token: 0x06007A74 RID: 31348 RVA: 0x001FF2A3 File Offset: 0x001FD4A3
	private void OnClickGoBtnHandler()
	{
		Action onClickGoBtn = this.OnClickGoBtn;
		if (onClickGoBtn == null)
		{
			return;
		}
		onClickGoBtn();
	}

	// Token: 0x04003AC7 RID: 15047
	[Nullable(2)]
	public Action OnClickGoBtn;

	// Token: 0x04003AC8 RID: 15048
	[Nullable(2)]
	public Action<int> OnBuffClick;

	// Token: 0x04003AC9 RID: 15049
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<DesRightBuffGridItem, int> BuffScrollView;

	// Token: 0x04003ACA RID: 15050
	private Dictionary<int, int> MonstMaxLifeAddRatioMap = new Dictionary<int, int>();

	// Token: 0x0200755C RID: 30044
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x040287F3 RID: 165875
		public const int ItemNumText = 0;

		// Token: 0x040287F4 RID: 165876
		public const int EmptyTextTips = 1;

		// Token: 0x040287F5 RID: 165877
		public const int LoopScrollView = 2;

		// Token: 0x040287F6 RID: 165878
		public const int BuffInfoItem = 3;

		// Token: 0x040287F7 RID: 165879
		public const int BuffLevelTextArt = 4;

		// Token: 0x040287F8 RID: 165880
		public const int TexBgColor = 5;

		// Token: 0x040287F9 RID: 165881
		public const int TxtDiffTitle = 6;

		// Token: 0x040287FA RID: 165882
		public const int TxtBestStar = 7;

		// Token: 0x040287FB RID: 165883
		public const int BtnConfirmB = 8;

		// Token: 0x040287FC RID: 165884
		public const int BottomTips = 9;

		// Token: 0x040287FD RID: 165885
		public const int TxtTipInfo = 10;
	}
}
