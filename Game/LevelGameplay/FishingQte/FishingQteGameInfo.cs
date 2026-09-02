using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006E90 RID: 28304
	public class FishingQteGameInfo
	{
		// Token: 0x06044A20 RID: 281120 RVA: 0x011D6E5B File Offset: 0x011D505B
		public void CreateRingInfo(EArrowDirection arrowDirection)
		{
			this.RingInfo = new FishingQteRingInfo(arrowDirection);
		}

		// Token: 0x06044A21 RID: 281121 RVA: 0x011D6E69 File Offset: 0x011D5069
		[NullableContext(1)]
		public FishingQteRingInfo GetRingInfo()
		{
			return this.RingInfo;
		}

		// Token: 0x06044A22 RID: 281122 RVA: 0x011D6E71 File Offset: 0x011D5071
		public void Clear()
		{
			FishingQteRingInfo ringInfo = this.RingInfo;
			if (ringInfo != null)
			{
				ringInfo.Clear();
			}
			this.RingInfo = null;
			this.GameStage = EFishingQteStage.None;
			this.CurrentScore = 0f;
			this.CurrentRound = 0;
			this.MaxRound = 0;
		}

		// Token: 0x06044A23 RID: 281123 RVA: 0x011D6EAB File Offset: 0x011D50AB
		public void SetGameStage(EFishingQteStage stage)
		{
			this.GameStage = stage;
			Singleton<EventSystem>.Instance.Emit<EFishingQteStage>(EEventName.OnFishingQteStageUpdate, this.GameStage);
		}

		// Token: 0x06044A24 RID: 281124 RVA: 0x011D6ECA File Offset: 0x011D50CA
		public EFishingQteStage GetGameStage()
		{
			return this.GameStage;
		}

		// Token: 0x06044A25 RID: 281125 RVA: 0x011D6ED2 File Offset: 0x011D50D2
		public bool IsGamePause()
		{
			return this.GameStage != EFishingQteStage.OnGoing;
		}

		// Token: 0x06044A26 RID: 281126 RVA: 0x011D6EE0 File Offset: 0x011D50E0
		public bool IsGameEnd()
		{
			return this.GameStage >= EFishingQteStage.End;
		}

		// Token: 0x04026357 RID: 156503
		[Nullable(2)]
		private FishingQteRingInfo RingInfo;

		// Token: 0x04026358 RID: 156504
		private EFishingQteStage GameStage;

		// Token: 0x04026359 RID: 156505
		public float CurrentScore;

		// Token: 0x0402635A RID: 156506
		public int CurrentRound;

		// Token: 0x0402635B RID: 156507
		public int MaxRound;

		// Token: 0x0402635C RID: 156508
		public float CursorSpeed;

		// Token: 0x0402635D RID: 156509
		public float RingSpeed;

		// Token: 0x0402635E RID: 156510
		public float PerfectAppearRate;
	}
}
