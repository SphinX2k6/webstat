using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Npc.Logics
{
	// Token: 0x020048D2 RID: 18642
	[NullableContext(2)]
	[Nullable(0)]
	public class PlayingMontageInfo
	{
		// Token: 0x06030A5A RID: 199258 RVA: 0x00BFCA4C File Offset: 0x00BFAC4C
		[NullableContext(1)]
		public PlayingMontageInfo(CharacterAnimationComponent animComp, int uid, string path, PlayMontageConfig config, [Nullable(2)] Action<PlayingMontageInfo> onPlay = null, [Nullable(2)] Action<PlayingMontageInfo> onStop = null, [Nullable(2)] Func<PlayingMontageInfo, bool> onCheck = null)
		{
			this.EntityId = animComp.Entity.Id;
			this.AnimComp = animComp;
			this.Uid = uid;
			this.MontagePath = path;
			this.MontageConfig = config;
			this.OnPlayMontage = onPlay;
			this.OnStopMontage = onStop;
			this.OnCheckPlayCondition = onCheck;
		}

		// Token: 0x06030A5B RID: 199259 RVA: 0x00BFCAB0 File Offset: 0x00BFACB0
		public bool CheckPlayCondition()
		{
			return this.OnCheckPlayCondition == null || this.OnCheckPlayCondition(this);
		}

		// Token: 0x06030A5C RID: 199260 RVA: 0x00BFCAC8 File Offset: 0x00BFACC8
		public void OnClearInfo()
		{
			if (this.OnStopMontage != null)
			{
				this.OnStopMontage(this);
			}
			if (this.TimerHandle != null && TimerSystem.Instance.Has(this.TimerHandle))
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
			this.MontageConfig = null;
			this.OnPlayMontage = null;
			this.OnStopMontage = null;
			this.OnCheckPlayCondition = null;
		}

		// Token: 0x06030A5D RID: 199261 RVA: 0x00BFCB37 File Offset: 0x00BFAD37
		public void PlayMontageLoop([Nullable(new byte[]
		{
			1,
			1,
			1,
			2,
			2
		})] Action<BaseAnimationComponent, PlayingMontageInfo, bool?, Action<UAnimMontage, bool>> endCallback)
		{
			if (this.OnPlayMontage != null)
			{
				this.OnPlayMontage(this);
			}
			this.PlayMontageLogic(endCallback);
		}

		// Token: 0x06030A5E RID: 199262 RVA: 0x00BFCB54 File Offset: 0x00BFAD54
		private void PlayMontageLogic([Nullable(new byte[]
		{
			1,
			1,
			1,
			2,
			2
		})] Action<BaseAnimationComponent, PlayingMontageInfo, bool?, Action<UAnimMontage, bool>> endCallback)
		{
			CharacterAnimationComponent animComp = this.AnimComp;
			if (animComp == null || !animComp.Valid)
			{
				return;
			}
			if (this.MontageConfig.IsInfiniteLoop && this.MontageConfig.IsPlayLoop)
			{
				Singleton<PlayMontageUtils>.Instance.Play(this.AnimComp, this.BodyMontage, null);
				return;
			}
			double num;
			if (this.MontageConfig.IsPlayLoop)
			{
				num = this.MontageConfig.PlayMontageTime;
				Singleton<PlayMontageUtils>.Instance.Play(this.AnimComp, this.BodyMontage, null);
			}
			else
			{
				num = this.MontageConfig.OncePlayTime;
				Singleton<PlayMontageUtils>.Instance.PlayOnce(this.AnimComp, this.BodyMontage, null);
			}
			this.MontageConfig.PlayMontageTime = this.MontageConfig.PlayMontageTime - num;
			if (!this.MontageConfig.IsInfiniteLoop && this.MontageConfig.PlayMontageTime <= 20.0)
			{
				this.TimerHandle = TimerSystem.Instance.Delay(delegate(float _)
				{
					this.TimerHandle = null;
					CharacterAnimationComponent animComp2 = this.AnimComp;
					if (animComp2 == null || !animComp2.Valid)
					{
						return;
					}
					endCallback(this.AnimComp, this, null, null);
				}, (float)((int)num), null, null, true, 1f);
				return;
			}
			this.TimerHandle = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.TimerHandle = null;
				this.PlayMontageLoop(endCallback);
			}, (float)((int)num), null, null, true, 1f);
		}

		// Token: 0x0401BF5C RID: 114524
		public int Uid;

		// Token: 0x0401BF5D RID: 114525
		public int EntityId;

		// Token: 0x0401BF5E RID: 114526
		[Nullable(1)]
		public string MontagePath = "";

		// Token: 0x0401BF5F RID: 114527
		public PlayMontageConfig MontageConfig;

		// Token: 0x0401BF60 RID: 114528
		public CharacterAnimationComponent AnimComp;

		// Token: 0x0401BF61 RID: 114529
		public UAnimMontage BodyMontage;

		// Token: 0x0401BF62 RID: 114530
		public TimerHandle TimerHandle;

		// Token: 0x0401BF63 RID: 114531
		private Func<PlayingMontageInfo, bool> OnCheckPlayCondition;

		// Token: 0x0401BF64 RID: 114532
		private Action<PlayingMontageInfo> OnPlayMontage;

		// Token: 0x0401BF65 RID: 114533
		private Action<PlayingMontageInfo> OnStopMontage;
	}
}
