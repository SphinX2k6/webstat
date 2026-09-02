using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Battle;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200609A RID: 24730
	[NullableContext(1)]
	[Nullable(0)]
	public class FarmGoldScoreItem : BaseScoreItem
	{
		// Token: 0x0603E6C3 RID: 255683 RVA: 0x00FF28BC File Offset: 0x00FF0ABC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIArtText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E6C4 RID: 255684 RVA: 0x00FF2904 File Offset: 0x00FF0B04
		protected override void OnStart()
		{
			base.OnStart();
			this.ShowCurrentTextByIndexArray(this.CurrentScoreIndexArray);
			foreach (KeyValuePair<int, int> keyValuePair in ModelBase<BattleScoreModel>.Instance.GetScoreMap())
			{
				int num;
				int num2;
				keyValuePair.Deconstruct(out num, out num2);
				int scoreId = num;
				int num3 = num2;
				if (num3 > 0 && this.IsValidScore(scoreId))
				{
					this.OnBattleScoreChanged(scoreId, num3);
				}
			}
		}

		// Token: 0x0603E6C5 RID: 255685 RVA: 0x00FF2988 File Offset: 0x00FF0B88
		public override bool IsValidScore(int scoreId)
		{
			BattleScoreConf? scoreConfig = ModelBase<BattleScoreModel>.Instance.GetScoreConfig(scoreId, false);
			return scoreConfig != null && scoreConfig.Value.Type == 0;
		}

		// Token: 0x0603E6C6 RID: 255686 RVA: 0x00FF29C0 File Offset: 0x00FF0BC0
		public override void OnTick(float delta)
		{
			if (!this.RunState)
			{
				return;
			}
			this.RefreshLowerIndexScoreText(this.CounterValueIndex, this.CurrentScoreIndexArray);
			this.RefreshHigherIndexScoreText(this.CounterValueIndex, this.CurrentScoreIndexArray);
			this.RunState = !this.CheckCounterValueIndexIfSame(this.CounterValueIndex, this.CurrentScoreIndexArray, this.TargetScoreIndexArray);
			if (!this.RunState)
			{
				this.CurrentScoreIndexArray = new List<int>(this.TargetScoreIndexArray);
			}
			this.ShowCurrentTextByIndexArray(this.CurrentScoreIndexArray);
		}

		// Token: 0x0603E6C7 RID: 255687 RVA: 0x00FF2A40 File Offset: 0x00FF0C40
		private void ShowCurrentTextByIndexArray(List<int> indexArray)
		{
			string text = string.Empty;
			foreach (int num in indexArray)
			{
				text += num.ToString();
			}
			text = ((text == string.Empty) ? "0" : text);
			UUIArtText artText = base.GetArtText(0);
			if (artText == null)
			{
				return;
			}
			artText.SetText(text);
		}

		// Token: 0x0603E6C8 RID: 255688 RVA: 0x00FF2AC4 File Offset: 0x00FF0CC4
		private void RefreshLowerIndexScoreText(int counterIndex, List<int> currentIndexArray)
		{
			int count = currentIndexArray.Count;
			for (int i = counterIndex + 1; i < count; i++)
			{
				int index = i;
				currentIndexArray[index]++;
				if (currentIndexArray[i] > 9)
				{
					currentIndexArray[i] = 0;
				}
			}
		}

		// Token: 0x0603E6C9 RID: 255689 RVA: 0x00FF2B10 File Offset: 0x00FF0D10
		private void RefreshHigherIndexScoreText(int counterIndex, List<int> currentIndexArray)
		{
			for (int i = counterIndex; i >= 0; i--)
			{
				int index = i;
				currentIndexArray[index]++;
				if (currentIndexArray[i] <= 9)
				{
					break;
				}
				currentIndexArray[i] = 0;
			}
		}

		// Token: 0x0603E6CA RID: 255690 RVA: 0x00FF2B50 File Offset: 0x00FF0D50
		private bool CheckCounterValueIndexIfSame(int counterIndex, List<int> currentIndexArray, List<int> targetIndexArray)
		{
			for (int i = 0; i <= counterIndex; i++)
			{
				if (currentIndexArray[i] != targetIndexArray[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603E6CB RID: 255691 RVA: 0x00FF2B7C File Offset: 0x00FF0D7C
		private int GetNumValueByIndexArray(List<int> indexArray)
		{
			int count = indexArray.Count;
			int num = 0;
			for (int i = 0; i < count; i++)
			{
				num += indexArray[i] * (int)Math.Pow(10.0, (double)(count - i - 1));
			}
			return num;
		}

		// Token: 0x0603E6CC RID: 255692 RVA: 0x00FF2BC0 File Offset: 0x00FF0DC0
		protected override void OnBattleScoreChanged(int scoreId, int score)
		{
			List<int> list = new List<int>(this.TargetScoreIndexArray);
			string text = score.ToString();
			int length = text.Length;
			this.TargetScoreIndexArray.Clear();
			for (int i = 0; i < length; i++)
			{
				this.TargetScoreIndexArray.Add(int.Parse(text[i].ToString()));
			}
			int numValueByIndexArray = this.GetNumValueByIndexArray(this.CurrentScoreIndexArray);
			this.CurrentScoreIndexArray.Clear();
			if (score < numValueByIndexArray)
			{
				this.CurrentScoreIndexArray = new List<int>(this.TargetScoreIndexArray);
				this.RunState = false;
				this.ShowCurrentTextByIndexArray(this.CurrentScoreIndexArray);
				return;
			}
			this.CurrentScoreIndexArray = new List<int>(list);
			for (int j = 0; j < length - list.Count; j++)
			{
				this.CurrentScoreIndexArray.Insert(0, 0);
			}
			this.CounterValueIndex = ((length - 2 >= 0) ? (length - 2) : 0);
			this.RunState = !this.CheckCounterValueIndexIfSame(this.CounterValueIndex, this.CurrentScoreIndexArray, this.TargetScoreIndexArray);
			this.ShowCurrentTextByIndexArray(this.CurrentScoreIndexArray);
		}

		// Token: 0x04022FC9 RID: 143305
		private bool RunState;

		// Token: 0x04022FCA RID: 143306
		private int CounterValueIndex;

		// Token: 0x04022FCB RID: 143307
		private List<int> CurrentScoreIndexArray = new List<int>();

		// Token: 0x04022FCC RID: 143308
		private readonly List<int> TargetScoreIndexArray = new List<int>();

		// Token: 0x0200C194 RID: 49556
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403B9C3 RID: 244163
			ScoreText
		}
	}
}
