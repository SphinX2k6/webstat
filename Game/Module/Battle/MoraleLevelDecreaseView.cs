using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F38 RID: 24376
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleLevelDecreaseView : UiTickViewBase
	{
		// Token: 0x0603D3DC RID: 250844 RVA: 0x00F93054 File Offset: 0x00F91254
		public MoraleLevelDecreaseView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603D3DD RID: 250845 RVA: 0x00F93080 File Offset: 0x00F91280
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

		// Token: 0x0603D3DE RID: 250846 RVA: 0x00F930C8 File Offset: 0x00F912C8
		protected override void OnStart()
		{
			this.LevelText = base.GetArtText(0);
			this.StartLevel = ModelBase<MoraleBattleModel>.Instance.GetLastMoraleLevel();
			this.EndLevel = 1;
			UUIArtText levelText = this.LevelText;
			if (levelText != null)
			{
				levelText.SetText(this.StartLevel.ToString());
			}
			this.CurrentLevel = this.StartLevel;
			this.ProgressLevel = (float)this.CurrentLevel;
			int num = this.EndLevel - this.StartLevel;
			if (num != 0)
			{
				this.AnimSpeed = (float)num / 500f;
			}
		}

		// Token: 0x0603D3DF RID: 250847 RVA: 0x00F9314D File Offset: 0x00F9134D
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x0603D3E0 RID: 250848 RVA: 0x00F93150 File Offset: 0x00F91350
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<PlotInfo>(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnSequenceNetworkStart));
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.AddSequenceFinishEvent("Start", new Action<string>(this.OnStartAnimEnd), false);
			}
			UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
			if (uiViewSequence2 == null)
			{
				return;
			}
			uiViewSequence2.AddSequenceFinishEvent("Close", new Action<string>(this.OnCloseAnimEnd), false);
		}

		// Token: 0x0603D3E1 RID: 250849 RVA: 0x00F931C0 File Offset: 0x00F913C0
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnSequenceNetworkStart));
			this.UiViewSequence.RemoveSequenceFinishEvent("Start", new Action<string>(this.OnStartAnimEnd));
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.RemoveSequenceFinishEvent("Close", new Action<string>(this.OnCloseAnimEnd));
		}

		// Token: 0x0603D3E2 RID: 250850 RVA: 0x00F93228 File Offset: 0x00F91428
		protected override void OnTick(float delta)
		{
			if (!this.IsEnableTick)
			{
				return;
			}
			float num = delta * this.AnimSpeed;
			this.PassTime += delta;
			this.ProgressLevel += num;
			this.CurrentLevel = Math.Max(this.EndLevel, (int)Math.Round((double)this.ProgressLevel));
			UUIArtText levelText = this.LevelText;
			if (levelText != null)
			{
				levelText.SetText(this.CurrentLevel.ToString());
			}
			if (this.CurrentLevel == this.EndLevel || this.PassTime > 5000f)
			{
				this.AnimSpeed = 0f;
				this.IsEnableTick = false;
				this.IsLevelAnimFinished = true;
				this.TryCloseMe();
			}
		}

		// Token: 0x0603D3E3 RID: 250851 RVA: 0x00F932D7 File Offset: 0x00F914D7
		private void OnStartAnimEnd(string s)
		{
			if (this.AnimSpeed < 0f)
			{
				this.IsEnableTick = true;
				return;
			}
			this.TryCloseMe();
		}

		// Token: 0x0603D3E4 RID: 250852 RVA: 0x00F932F4 File Offset: 0x00F914F4
		private void OnCloseAnimEnd(string s)
		{
			if (this.IsLevelAnimFinished && ModelBase<MoraleBattleModel>.Instance.GetMoraleIndomitableLevel() > 1)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.MoraleIndomitableLevelView, null, null);
			}
		}

		// Token: 0x0603D3E5 RID: 250853 RVA: 0x00F9331C File Offset: 0x00F9151C
		private void OnSequenceNetworkStart(PlotInfo plotInfo)
		{
			this.TryCloseMe();
		}

		// Token: 0x0603D3E6 RID: 250854 RVA: 0x00F93324 File Offset: 0x00F91524
		private void TryCloseMe()
		{
			this.IsEnableTick = false;
			if (!base.IsHideOrHiding)
			{
				base.CloseMe(null);
			}
		}

		// Token: 0x04022586 RID: 140678
		private const float LEVEL_ANIM_DURATION = 500f;

		// Token: 0x04022587 RID: 140679
		private const float LEVEL_ANIM_EXPIRED_TIME = 5000f;

		// Token: 0x04022588 RID: 140680
		[StaticVariableRuleIgnore]
		private static readonly Stat TickStatsObject = Stat.Create("[MoraleLevelDecreaseView]OnTick", "", "");

		// Token: 0x04022589 RID: 140681
		[Nullable(2)]
		private UUIArtText LevelText;

		// Token: 0x0402258A RID: 140682
		private int StartLevel = 1;

		// Token: 0x0402258B RID: 140683
		private int EndLevel = 1;

		// Token: 0x0402258C RID: 140684
		private int CurrentLevel = 1;

		// Token: 0x0402258D RID: 140685
		private float ProgressLevel = 1f;

		// Token: 0x0402258E RID: 140686
		private float AnimSpeed;

		// Token: 0x0402258F RID: 140687
		private bool IsEnableTick;

		// Token: 0x04022590 RID: 140688
		private bool IsLevelAnimFinished;

		// Token: 0x04022591 RID: 140689
		private float PassTime;

		// Token: 0x0200BF5C RID: 48988
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403AE71 RID: 241265
			LevelText
		}
	}
}
