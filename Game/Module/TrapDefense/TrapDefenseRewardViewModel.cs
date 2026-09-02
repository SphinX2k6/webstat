using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E08 RID: 19976
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseRewardViewModel
	{
		// Token: 0x06033A91 RID: 211601 RVA: 0x00CE925B File Offset: 0x00CE745B
		public static TrapDefenseRewardViewModel Create()
		{
			return new TrapDefenseRewardViewModel();
		}

		// Token: 0x06033A92 RID: 211602 RVA: 0x00CE9262 File Offset: 0x00CE7462
		public void Clear()
		{
			this.CurSelectRewardType = ETrapDefenseRewardType.Default;
			this.OnSelectRewardTypeChangeDelegates.Clear();
		}

		// Token: 0x06033A93 RID: 211603 RVA: 0x00CE9276 File Offset: 0x00CE7476
		public void RegisterOnSelectRewardTypeChange(Action<ETrapDefenseRewardType> @delegate)
		{
			if (this.OnSelectRewardTypeChangeDelegates.Contains(@delegate))
			{
				return;
			}
			this.OnSelectRewardTypeChangeDelegates.Add(@delegate);
		}

		// Token: 0x06033A94 RID: 211604 RVA: 0x00CE9294 File Offset: 0x00CE7494
		public void UnregisterOnSelectRewardTypeChange(Action<ETrapDefenseRewardType> @delegate)
		{
			int num = this.OnSelectRewardTypeChangeDelegates.IndexOf(@delegate);
			if (num >= 0)
			{
				this.OnSelectRewardTypeChangeDelegates.RemoveAt(num);
			}
		}

		// Token: 0x06033A95 RID: 211605 RVA: 0x00CE92BE File Offset: 0x00CE74BE
		public void SetCurSelectRewardType(ETrapDefenseRewardType type)
		{
			if (this.CurSelectRewardType == type)
			{
				return;
			}
			this.CurSelectRewardType = type;
			this.NotifyOnSelectRewardTypeChange(type);
		}

		// Token: 0x06033A96 RID: 211606 RVA: 0x00CE92D8 File Offset: 0x00CE74D8
		public List<TrapDefenseRewardTabData> GetRewardTypeDataList()
		{
			List<TrapDefenseRewardTabData> list = new List<TrapDefenseRewardTabData>();
			for (int i = 1; i < 5; i++)
			{
				ETrapDefenseRewardType type = (ETrapDefenseRewardType)i;
				if (ModelBase<TrapDefenseModel>.Instance.RewardData.GetRewardListByType(type).Count != 0)
				{
					list.Add(new TrapDefenseRewardTabData(type));
				}
			}
			return list;
		}

		// Token: 0x06033A97 RID: 211607 RVA: 0x00CE9320 File Offset: 0x00CE7520
		private void NotifyOnSelectRewardTypeChange(ETrapDefenseRewardType type)
		{
			foreach (Action<ETrapDefenseRewardType> action in this.OnSelectRewardTypeChangeDelegates)
			{
				action(type);
			}
		}

		// Token: 0x0401DECC RID: 122572
		public ETrapDefenseRewardType CurSelectRewardType;

		// Token: 0x0401DECD RID: 122573
		private readonly List<Action<ETrapDefenseRewardType>> OnSelectRewardTypeChangeDelegates = new List<Action<ETrapDefenseRewardType>>();
	}
}
