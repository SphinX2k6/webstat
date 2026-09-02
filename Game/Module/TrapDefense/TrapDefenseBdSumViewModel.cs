using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E03 RID: 19971
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBdSumViewModel
	{
		// Token: 0x06033A3D RID: 211517 RVA: 0x00CE6D85 File Offset: 0x00CE4F85
		public static TrapDefenseBdSumViewModel Create(TrapDefenseModel model)
		{
			return new TrapDefenseBdSumViewModel
			{
				Model = model
			};
		}

		// Token: 0x06033A3E RID: 211518 RVA: 0x00CE6D93 File Offset: 0x00CE4F93
		private TrapDefenseBdSumViewModel()
		{
		}

		// Token: 0x06033A3F RID: 211519 RVA: 0x00CE6D9C File Offset: 0x00CE4F9C
		public unsafe List<ITrapDefenseTab<ETrapDefenseBdTabType>> GetTabList()
		{
			int num = 2;
			List<ITrapDefenseTab<ETrapDefenseBdTabType>> list = new List<ITrapDefenseTab<ETrapDefenseBdTabType>>(num);
			CollectionsMarshal.SetCount<ITrapDefenseTab<ETrapDefenseBdTabType>>(list, num);
			Span<ITrapDefenseTab<ETrapDefenseBdTabType>> span = CollectionsMarshal.AsSpan<ITrapDefenseTab<ETrapDefenseBdTabType>>(list);
			int num2 = 0;
			*span[num2] = new TrapDefenseTab<ETrapDefenseBdTabType>
			{
				TabType = ETrapDefenseBdTabType.BdProgress,
				TabNameKey = ETrapDefenseTextKey.BdSumTabBdProgress.ToString()
			};
			num2++;
			*span[num2] = new TrapDefenseTab<ETrapDefenseBdTabType>
			{
				TabType = ETrapDefenseBdTabType.BuffSum,
				TabNameKey = ETrapDefenseTextKey.BdSumTabBuffSum.ToString()
			};
			return list;
		}

		// Token: 0x06033A40 RID: 211520 RVA: 0x00CE6E1C File Offset: 0x00CE501C
		public List<TrapDefenseBdData> GetBdListForProgress()
		{
			if (this.IsInstance)
			{
				TrapDefenseLevelData curInstToLevelData = this.Model.GetCurInstToLevelData();
				if (curInstToLevelData != null)
				{
					List<TrapDefenseBdData> showBdList = curInstToLevelData.GetShowBdList();
					showBdList.Sort(new Comparison<TrapDefenseBdData>(this.SortBdProgress));
					return showBdList;
				}
			}
			List<TrapDefenseBdData> bdDataListIgnoreZero = this.Model.RougeModeData.BdDataListIgnoreZero;
			bdDataListIgnoreZero.Sort(new Comparison<TrapDefenseBdData>(this.SortBdUnlock));
			return bdDataListIgnoreZero;
		}

		// Token: 0x06033A41 RID: 211521 RVA: 0x00CE6E7C File Offset: 0x00CE507C
		public int SortBdProgress(TrapDefenseBdData a, TrapDefenseBdData b)
		{
			int currentActiveProgressNum = a.GetCurrentActiveProgressNum();
			int currentActiveProgressNum2 = b.GetCurrentActiveProgressNum();
			if (currentActiveProgressNum != currentActiveProgressNum2)
			{
				return currentActiveProgressNum2 - currentActiveProgressNum;
			}
			return this.SortBdId(a, b);
		}

		// Token: 0x06033A42 RID: 211522 RVA: 0x00CE6EA7 File Offset: 0x00CE50A7
		public int SortBdUnlock(TrapDefenseBdData a, TrapDefenseBdData b)
		{
			if (a.IsUnlock == b.IsUnlock)
			{
				return this.SortBdId(a, b);
			}
			if (!a.IsUnlock)
			{
				return 1;
			}
			return -1;
		}

		// Token: 0x06033A43 RID: 211523 RVA: 0x00CE6ECB File Offset: 0x00CE50CB
		public int SortBdId(TrapDefenseBdData a, TrapDefenseBdData b)
		{
			return a.Id - b.Id;
		}

		// Token: 0x06033A44 RID: 211524 RVA: 0x00CE6EDC File Offset: 0x00CE50DC
		public List<TrapDefenseBdData> GetBdListForBuffSum()
		{
			if (this.IsInstance)
			{
				List<TrapDefenseBdData> bdDataListIsActive = this.Model.RougeModeData.GetBdDataListIsActive();
				bdDataListIsActive.Sort(new Comparison<TrapDefenseBdData>(this.SortBdProgress));
				return bdDataListIsActive;
			}
			List<TrapDefenseBdData> bdDataList = this.Model.RougeModeData.BdDataList;
			bdDataList.Sort(new Comparison<TrapDefenseBdData>(this.SortBdUnlock));
			return bdDataList;
		}

		// Token: 0x06033A45 RID: 211525 RVA: 0x00CE6F36 File Offset: 0x00CE5136
		public void SetIsInstance(bool isInstance)
		{
			this.IsInstance = isInstance;
		}

		// Token: 0x06033A46 RID: 211526 RVA: 0x00CE6F3F File Offset: 0x00CE513F
		public void SetSelectBdBuffData(TrapDefenseBdBuffData data)
		{
			this.CurSelectBdBuffData = data;
		}

		// Token: 0x06033A47 RID: 211527 RVA: 0x00CE6F48 File Offset: 0x00CE5148
		public void SetSelectBdData(TrapDefenseBdData data)
		{
			this.CurSelectBdData = data;
		}

		// Token: 0x06033A48 RID: 211528 RVA: 0x00CE6F51 File Offset: 0x00CE5151
		public void SetJumpTabType(ETrapDefenseBdTabType? tab)
		{
			this.JumpTabType = tab;
		}

		// Token: 0x06033A49 RID: 211529 RVA: 0x00CE6F5A File Offset: 0x00CE515A
		public void SetJumpBdId(int? id)
		{
			this.JumpBdId = id;
		}

		// Token: 0x06033A4A RID: 211530 RVA: 0x00CE6F63 File Offset: 0x00CE5163
		public bool IsShowBuffLockState(TrapDefenseBdBuffData data)
		{
			if (this.IsInstance)
			{
				return !data.IsActive;
			}
			return !data.IsUnlock;
		}

		// Token: 0x06033A4B RID: 211531 RVA: 0x00CE6F80 File Offset: 0x00CE5180
		public void OnViewClose()
		{
			this.CurSelectBdData = null;
			this.CurSelectBdBuffData = null;
			this.IsInstance = false;
		}

		// Token: 0x0401DEA5 RID: 122533
		public TrapDefenseModel Model;

		// Token: 0x0401DEA6 RID: 122534
		public ETrapDefenseBdTabType? JumpTabType;

		// Token: 0x0401DEA7 RID: 122535
		public int? JumpBdBuffId;

		// Token: 0x0401DEA8 RID: 122536
		public int? JumpBdId;

		// Token: 0x0401DEA9 RID: 122537
		public bool IsInstance;

		// Token: 0x0401DEAA RID: 122538
		[Nullable(2)]
		public TrapDefenseBdBuffData CurSelectBdBuffData;

		// Token: 0x0401DEAB RID: 122539
		[Nullable(2)]
		public TrapDefenseBdData CurSelectBdData;
	}
}
