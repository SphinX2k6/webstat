using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonSignIn
{
	// Token: 0x02006724 RID: 26404
	[NullableContext(1)]
	[Nullable(0)]
	public class MoonSignInData : ActivityBaseData
	{
		// Token: 0x06041DE0 RID: 269792 RVA: 0x010E6048 File Offset: 0x010E4248
		protected override void PhraseEx(ActivityData data)
		{
			MoonPhaseActivityData moonPhaseActivityData = data.MoonPhaseActivityData;
			this.HaveSelectMoonPhaseSelectList = (((moonPhaseActivityData != null) ? moonPhaseActivityData.MoonPhaseSelects.ToList<MoonPhaseSelect>() : null) ?? new List<MoonPhaseSelect>());
			MoonPhaseActivityData moonPhaseActivityData2 = data.MoonPhaseActivityData;
			this.MoonGrandReward = (moonPhaseActivityData2 != null && moonPhaseActivityData2.MoonPhaseSpReward);
			this.SelectMoonPhaseList.Clear();
			foreach (MoonPhaseSelect moonPhaseSelect in this.HaveSelectMoonPhaseSelectList)
			{
				this.SelectMoonPhaseList.Add(moonPhaseSelect.MoonPhaseId);
			}
			IReadOnlyList<PhaseOfMoon> phaseOfMoonList = ConfigBase<MoonSignInConfig>.Instance.GetPhaseOfMoonList();
			this.AllMoonPhaseCount = ((phaseOfMoonList != null) ? phaseOfMoonList.Count : 0);
			MoonPhaseReward? moonPhaseReward;
			this.UseItemId = ((ConfigBase<MoonSignInConfig>.Instance.GetMoonSignReward(base.Id) != null) ? moonPhaseReward.GetValueOrDefault().ItemId : 0);
			MoonPhaseActivityData moonPhaseActivityData3 = data.MoonPhaseActivityData;
			this.CurrentMoonId = ((moonPhaseActivityData3 != null) ? moonPhaseActivityData3.NowMoonParse : 0);
		}

		// Token: 0x06041DE1 RID: 269793 RVA: 0x010E6154 File Offset: 0x010E4354
		public string GetMoonPhaseProgress()
		{
			return this.HaveSelectMoonPhaseSelectList.Count.ToString() + "/" + this.AllMoonPhaseCount.ToString();
		}

		// Token: 0x06041DE2 RID: 269794 RVA: 0x010E6189 File Offset: 0x010E4389
		public override bool GetExDataRedPointShowState()
		{
			return this.GetAnyRedDot();
		}

		// Token: 0x06041DE3 RID: 269795 RVA: 0x010E6191 File Offset: 0x010E4391
		public bool GetAnyRedDot()
		{
			return this.GetCurrentItemCount() > 0 || this.GetCanGetMoonGrandReward();
		}

		// Token: 0x06041DE4 RID: 269796 RVA: 0x010E61A4 File Offset: 0x010E43A4
		public int GetCurrentItemCount()
		{
			if (this.UseItemId == 0)
			{
				return 0;
			}
			return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.UseItemId, 0);
		}

		// Token: 0x06041DE5 RID: 269797 RVA: 0x010E61C4 File Offset: 0x010E43C4
		public bool CheckPhaseLock(int id)
		{
			using (List<MoonPhaseSelect>.Enumerator enumerator = this.HaveSelectMoonPhaseSelectList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.MoonPhaseId == id)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06041DE6 RID: 269798 RVA: 0x010E6220 File Offset: 0x010E4420
		public bool GetCanGetMoonGrandReward()
		{
			if (this.MoonGrandReward)
			{
				return false;
			}
			MoonPhaseReward? moonSignReward = ConfigBase<MoonSignInConfig>.Instance.GetMoonSignReward(base.Id);
			return moonSignReward != null && this.HaveSelectMoonPhaseSelectList.Count >= moonSignReward.Value.NeedMoonNum;
		}

		// Token: 0x06041DE7 RID: 269799 RVA: 0x010E6274 File Offset: 0x010E4474
		public List<int> GetMoonNormalRewardData()
		{
			List<int> list = new List<int>();
			for (int i = 1; i <= 10; i++)
			{
				list.Add(i);
			}
			return list;
		}

		// Token: 0x06041DE8 RID: 269800 RVA: 0x010E629C File Offset: 0x010E449C
		[NullableContext(2)]
		public MoonPhaseSelect GetMoonPhaseSelect(int moonId)
		{
			foreach (MoonPhaseSelect moonPhaseSelect in this.HaveSelectMoonPhaseSelectList)
			{
				if (moonPhaseSelect.MoonPhaseId == moonId)
				{
					return moonPhaseSelect;
				}
			}
			return null;
		}

		// Token: 0x06041DE9 RID: 269801 RVA: 0x010E62F8 File Offset: 0x010E44F8
		protected override bool GetExDataFinishShowState()
		{
			return this.HaveSelectMoonPhaseSelectList.Count >= 10 && this.MoonGrandReward;
		}

		// Token: 0x04024C11 RID: 150545
		private const int MAX_MOON_COUNT = 10;

		// Token: 0x04024C12 RID: 150546
		public List<MoonPhaseSelect> HaveSelectMoonPhaseSelectList = new List<MoonPhaseSelect>();

		// Token: 0x04024C13 RID: 150547
		public bool MoonGrandReward;

		// Token: 0x04024C14 RID: 150548
		private int AllMoonPhaseCount;

		// Token: 0x04024C15 RID: 150549
		public List<int> SelectMoonPhaseList = new List<int>();

		// Token: 0x04024C16 RID: 150550
		public int UseItemId;

		// Token: 0x04024C17 RID: 150551
		public int CurrentMoonId;
	}
}
