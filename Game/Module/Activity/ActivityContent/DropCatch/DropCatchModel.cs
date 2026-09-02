using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068C4 RID: 26820
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class DropCatchModel : ModelBase<DropCatchModel>
	{
		// Token: 0x06042B4C RID: 273228 RVA: 0x0111EDC4 File Offset: 0x0111CFC4
		public void AddGameplayScoreRecord(int gameplayId, float score)
		{
			if (this.GameplayScoreRecord.ContainsKey(gameplayId))
			{
				this.GameplayScoreRecord[gameplayId] = score;
				return;
			}
			this.GameplayScoreRecord.Add(gameplayId, score);
		}

		// Token: 0x06042B4D RID: 273229 RVA: 0x0111EDF0 File Offset: 0x0111CFF0
		public float GetGameplayScoreRecord(int gameplayId)
		{
			float result;
			if (this.GameplayScoreRecord.TryGetValue(gameplayId, out result))
			{
				return result;
			}
			return 0f;
		}

		// Token: 0x06042B4E RID: 273230 RVA: 0x0111EE14 File Offset: 0x0111D014
		protected override bool OnClear()
		{
			this.GameplayScoreRecord.Clear();
			return true;
		}

		// Token: 0x040252AC RID: 152236
		private readonly Dictionary<int, float> GameplayScoreRecord = new Dictionary<int, float>();
	}
}
