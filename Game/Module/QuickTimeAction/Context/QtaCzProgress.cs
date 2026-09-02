using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.QuickTimeAction.Customization;

namespace CSharpScript.Game.Module.QuickTimeAction.Context
{
	// Token: 0x020052BC RID: 21180
	[NullableContext(1)]
	[Nullable(0)]
	public class QtaCzProgress
	{
		// Token: 0x0603624C RID: 221772 RVA: 0x00DA304C File Offset: 0x00DA124C
		public void InitByConfig(SQtaCustomizationParam_Progress cfg, EQtaCustomization_ProgressResetType resetType = EQtaCustomization_ProgressResetType.停止)
		{
			this.ProgressCfg.InitByConfig(cfg);
			this.ResetType = resetType;
			if (this.ProgressCfg.Max < 0f)
			{
				float max = this.ProgressCfg.Max;
				this.ProgressCfg.Max = ((max < 0f) ? (1f - Math.Abs(this.ProgressCfg.Max)) : max);
			}
			if (this.ProgressCfg.Init < 0f)
			{
				float init = this.ProgressCfg.Init;
				this.CurProgress = Singleton<MathUtils>.Instance.Clamp((init < 0f) ? (this.ProgressCfg.Max + init) : init, 0f, this.ProgressCfg.Max);
			}
		}

		// Token: 0x0603624D RID: 221773 RVA: 0x00DA310C File Offset: 0x00DA130C
		public void SetSpeed(float speed)
		{
			this.ProgressCfg.AutoSpeed = speed;
		}

		// Token: 0x17008CF8 RID: 36088
		// (get) Token: 0x0603624E RID: 221774 RVA: 0x00DA311A File Offset: 0x00DA131A
		public bool IsFinish
		{
			get
			{
				return this.Finish;
			}
		}

		// Token: 0x17008CF9 RID: 36089
		// (get) Token: 0x0603624F RID: 221775 RVA: 0x00DA3122 File Offset: 0x00DA1322
		public float Progress
		{
			get
			{
				return this.CurProgress;
			}
		}

		// Token: 0x06036250 RID: 221776 RVA: 0x00DA312C File Offset: 0x00DA132C
		public void Update(float delta, bool isPressed = false)
		{
			float num = (this.ProgressCfg.AutoSpeed + (isPressed ? this.ProgressCfg.AdditionSpeed : 0f)) * delta * 0.001f * (float)this.Dir;
			this.CurProgress = Singleton<MathUtils>.Instance.Clamp(this.CurProgress + num, 0f, this.ProgressCfg.Max);
			if (this.CurProgress >= this.ProgressCfg.Max || this.CurProgress <= 0f)
			{
				switch (this.ResetType)
				{
				case EQtaCustomization_ProgressResetType.停止:
					break;
				case EQtaCustomization_ProgressResetType.重置:
				{
					float num2 = this.ProgressCfg.AutoSpeed + this.ProgressCfg.AdditionSpeed;
					this.CurProgress = ((num2 > 0f) ? 0f : this.ProgressCfg.Max);
					this.Dir = 1;
					return;
				}
				case EQtaCustomization_ProgressResetType.倒转:
					this.Dir = -this.Dir;
					return;
				case EQtaCustomization_ProgressResetType.结束:
					this.Finish = true;
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x0401F1AD RID: 127405
		private readonly QtaCzProgressData ProgressCfg = new QtaCzProgressData();

		// Token: 0x0401F1AE RID: 127406
		private EQtaCustomization_ProgressResetType ResetType;

		// Token: 0x0401F1AF RID: 127407
		private float CurProgress;

		// Token: 0x0401F1B0 RID: 127408
		private int Dir = 1;

		// Token: 0x0401F1B1 RID: 127409
		private bool Finish;
	}
}
