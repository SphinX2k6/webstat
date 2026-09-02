using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RacingBets.View.Item.RacingBetsMatchTable
{
	// Token: 0x020052A1 RID: 21153
	public class RacingBetsMatchTableTabItem : GridProxyAbstract<ERacingBetsMatchTableType>
	{
		// Token: 0x06036174 RID: 221556 RVA: 0x00D9E9E8 File Offset: 0x00D9CBE8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
			};
		}

		// Token: 0x06036175 RID: 221557 RVA: 0x00D9EA7C File Offset: 0x00D9CC7C
		public override void Refresh(ERacingBetsMatchTableType data, bool isSelected, int gridIndex)
		{
			this.MatchTableType = data;
			RacingBetsMatch? matchTableConfigById = ConfigBase<RacingBetsConfig>.Instance.GetMatchTableConfigById((int)data);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), matchTableConfigById.Value.Name, Array.Empty<object>());
			int[] groupMatchListArray = matchTableConfigById.Value.GetGroupMatchListArray();
			long num = 0L;
			long num2 = 0L;
			foreach (int matchId in groupMatchListArray)
			{
				ValueTuple<long, long> timeRange = ModelBase<RacingBetsModel>.Instance.GetRacingBetsGroupMatchData(matchId).GetTimeRange();
				long item = timeRange.Item1;
				long item2 = timeRange.Item2;
				if (num == 0L || item < num)
				{
					num = item;
				}
				if (num2 == 0L || item2 > num2)
				{
					num2 = item2;
				}
			}
			string text = Singleton<TimeUtil>.Instance.DateFormat6String((double)num);
			string text2 = Singleton<TimeUtil>.Instance.DateFormat6String((double)num2);
			if (text == text2)
			{
				UUIText text3 = base.GetText(2);
				if (text3 != null)
				{
					text3.SetText(text, true);
				}
			}
			else
			{
				UUIText text4 = base.GetText(2);
				if (text4 != null)
				{
					text4.SetText(text + "-" + text2, true);
				}
			}
			RacingBetsLegMatchData curLegMatchData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData().GetCurLegMatchData();
			if (curLegMatchData != null)
			{
				List<int> list = new List<int>();
				foreach (int matchId2 in groupMatchListArray)
				{
					foreach (RacingBetsLegMatchData racingBetsLegMatchData in ModelBase<RacingBetsModel>.Instance.GetRacingBetsGroupMatchData(matchId2).GetLegMatchList())
					{
						list.Add(racingBetsLegMatchData.Id);
					}
				}
				bool uiactive = list.Contains(curLegMatchData.Id);
				UUIItem item3 = base.GetItem(3);
				if (item3 == null)
				{
					return;
				}
				item3.SetUIActive(uiactive);
			}
		}

		// Token: 0x06036176 RID: 221558 RVA: 0x00D9EC44 File Offset: 0x00D9CE44
		public void SetToggleState(bool state)
		{
			EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleState(state2, false, false, false);
		}

		// Token: 0x06036177 RID: 221559 RVA: 0x00D9EC6A File Offset: 0x00D9CE6A
		public override void OnSelected(bool fireEvent)
		{
			this.SetToggleState(true);
		}

		// Token: 0x06036178 RID: 221560 RVA: 0x00D9EC73 File Offset: 0x00D9CE73
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleState(false);
		}

		// Token: 0x06036179 RID: 221561 RVA: 0x00D9EC7C File Offset: 0x00D9CE7C
		[NullableContext(1)]
		public override object GetKey(ERacingBetsMatchTableType data, int displayIndex)
		{
			return data;
		}

		// Token: 0x0603617A RID: 221562 RVA: 0x00D9EC84 File Offset: 0x00D9CE84
		private void OnClickToggle(EToggleState state)
		{
			Action<ERacingBetsMatchTableType> onToggleCallBack = this.OnToggleCallBack;
			if (onToggleCallBack == null)
			{
				return;
			}
			onToggleCallBack(this.MatchTableType);
		}

		// Token: 0x0401F139 RID: 127289
		private ERacingBetsMatchTableType MatchTableType = ERacingBetsMatchTableType.GroupMatch;

		// Token: 0x0401F13A RID: 127290
		[Nullable(2)]
		public Action<ERacingBetsMatchTableType> OnToggleCallBack;

		// Token: 0x0200B216 RID: 45590
		private class EComponent
		{
			// Token: 0x04037357 RID: 226135
			public const int ToggleRoot = 0;

			// Token: 0x04037358 RID: 226136
			public const int TextName = 1;

			// Token: 0x04037359 RID: 226137
			public const int TextDate = 2;

			// Token: 0x0403735A RID: 226138
			public const int ItemRacing = 3;
		}
	}
}
