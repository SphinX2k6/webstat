using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F4D RID: 24397
	public class BattleUiAudioData
	{
		// Token: 0x0603D490 RID: 251024 RVA: 0x00F96A2D File Offset: 0x00F94C2D
		public void Init()
		{
		}

		// Token: 0x0603D491 RID: 251025 RVA: 0x00F96A30 File Offset: 0x00F94C30
		public void OnLeaveLevel()
		{
			foreach (BattleUiAudioInfo battleUiAudioInfo in this.AudioInfoMap.Values)
			{
				battleUiAudioInfo.Reset();
			}
		}

		// Token: 0x0603D492 RID: 251026 RVA: 0x00F96A88 File Offset: 0x00F94C88
		public void Clear()
		{
		}

		// Token: 0x0603D493 RID: 251027 RVA: 0x00F96A8C File Offset: 0x00F94C8C
		public void PlayAudio(EBattleUiAudioType type, EBattleUiChild uiChildType = EBattleUiChild.Common)
		{
			BattleUiAudioInfo battleUiAudioInfo;
			if (!this.AudioInfoMap.TryGetValue(type, out battleUiAudioInfo))
			{
				battleUiAudioInfo = new BattleUiAudioInfo
				{
					AudioType = type
				};
				this.AudioInfoMap[type] = battleUiAudioInfo;
			}
			battleUiAudioInfo.UiChildType = uiChildType;
			battleUiAudioInfo.PlayAudio();
		}

		// Token: 0x04022612 RID: 140818
		[Nullable(1)]
		private readonly Dictionary<EBattleUiAudioType, BattleUiAudioInfo> AudioInfoMap = new Dictionary<EBattleUiAudioType, BattleUiAudioInfo>();
	}
}
