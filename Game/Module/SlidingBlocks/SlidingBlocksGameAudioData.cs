using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Gameplay.Tetris;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004EFF RID: 20223
	[NullableContext(2)]
	[Nullable(0)]
	public class SlidingBlocksGameAudioData
	{
		// Token: 0x06034450 RID: 214096 RVA: 0x00D1313C File Offset: 0x00D1133C
		public void Init()
		{
			Bp_Tetris_C setting = SlidingBlocksGlobal.Setting;
			this.GameSpeedUpAudio = Singleton<AudioSystem>.Instance.parseAudioEventPath(setting.AudioGameSpeedUp);
			this.TetrominoStartFallAudio = Singleton<AudioSystem>.Instance.parseAudioEventPath(setting.AudioTetrominoStartFall);
			this.SuccessAudio = Singleton<AudioSystem>.Instance.parseAudioEventPath(setting.AudioGameSuccess);
			this.FailAudio = Singleton<AudioSystem>.Instance.parseAudioEventPath(setting.AudioGameFail);
			this.RestartAudio = Singleton<AudioSystem>.Instance.parseAudioEventPath(setting.AudioGameRestart);
			this.RotateAudio = Singleton<AudioSystem>.Instance.parseAudioEventPath(setting.AudioTetrominoRotate);
			this.AimingMoveAudio = Singleton<AudioSystem>.Instance.parseAudioEventPath(setting.AudioAimingMove);
		}

		// Token: 0x06034451 RID: 214097 RVA: 0x00D131E9 File Offset: 0x00D113E9
		public void Reset()
		{
			this.GameSpeedUpAudio = null;
			this.TetrominoStartFallAudio = null;
			this.SuccessAudio = null;
			this.FailAudio = null;
			this.RestartAudio = null;
			this.RotateAudio = null;
			this.AimingMoveAudio = null;
		}

		// Token: 0x0401E270 RID: 123504
		public string GameSpeedUpAudio;

		// Token: 0x0401E271 RID: 123505
		public string TetrominoStartFallAudio;

		// Token: 0x0401E272 RID: 123506
		public string SuccessAudio;

		// Token: 0x0401E273 RID: 123507
		public string FailAudio;

		// Token: 0x0401E274 RID: 123508
		public string RestartAudio;

		// Token: 0x0401E275 RID: 123509
		public string RotateAudio;

		// Token: 0x0401E276 RID: 123510
		public string AimingMoveAudio;
	}
}
