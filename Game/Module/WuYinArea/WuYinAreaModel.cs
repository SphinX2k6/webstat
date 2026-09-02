using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Battle;
using CSharpScript.Game.Render;

namespace CSharpScript.Game.Module.WuYinArea
{
	// Token: 0x02004A93 RID: 19091
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class WuYinAreaModel : ModelBase<WuYinAreaModel>
	{
		// Token: 0x06031CE6 RID: 204006 RVA: 0x00C79788 File Offset: 0x00C77988
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x06031CE7 RID: 204007 RVA: 0x00C7978B File Offset: 0x00C7798B
		protected override bool OnClear()
		{
			this.WuYinLevelSequenceState.Clear();
			return true;
		}

		// Token: 0x06031CE8 RID: 204008 RVA: 0x00C7979C File Offset: 0x00C7799C
		public EWuYinSequencePlayState? GetWuYinLevelSequenceState(string sequenceName)
		{
			if (!this.WuYinLevelSequenceState.ContainsKey(sequenceName))
			{
				return null;
			}
			return new EWuYinSequencePlayState?(this.WuYinLevelSequenceState[sequenceName]);
		}

		// Token: 0x06031CE9 RID: 204009 RVA: 0x00C797D4 File Offset: 0x00C779D4
		public void PlayWuYinSequence(string sequenceName, string playState)
		{
			EWuYinQuState state = (playState == "Play") ? EWuYinQuState.StateFighting1 : EWuYinQuState.StateIdle;
			ControllerBase<RenderModuleController>.Instance.SetBattleState(sequenceName, state, false);
		}

		// Token: 0x0401D2A4 RID: 119460
		private readonly Dictionary<string, EWuYinSequencePlayState> WuYinLevelSequenceState = new Dictionary<string, EWuYinSequencePlayState>();
	}
}
