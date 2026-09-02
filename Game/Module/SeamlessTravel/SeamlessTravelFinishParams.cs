using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.SeamlessTravel
{
	// Token: 0x02005002 RID: 20482
	[NullableContext(1)]
	[Nullable(0)]
	public class SeamlessTravelFinishParams
	{
		// Token: 0x06034CBD RID: 216253 RVA: 0x00D3FA34 File Offset: 0x00D3DC34
		public void ParseFinishParamsByProto(SeamlessTeleportFinishConfigPb config)
		{
			this.NotStopScreenEffect = config.IsNotStopScreenEffect;
			this.ScreenEffectExtraState = config.EffectExtraState;
		}

		// Token: 0x06034CBE RID: 216254 RVA: 0x00D3FA50 File Offset: 0x00D3DC50
		public void ParseFinishParamsByConfig(ISeamlessTeleportFinishConfig config)
		{
			this.NotStopScreenEffect = config.IsNotStopScreenEffect.GetValueOrDefault();
			this.ScreenEffectExtraState = config.EffectExtraState.GetValueOrDefault(-1);
		}

		// Token: 0x0401E695 RID: 124565
		public bool NotStopScreenEffect;

		// Token: 0x0401E696 RID: 124566
		public int ScreenEffectExtraState = -1;
	}
}
