using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004796 RID: 18326
	[NullableContext(1)]
	[Nullable(0)]
	public class ThreeSectionTimeline
	{
		// Token: 0x0602F8E4 RID: 194788 RVA: 0x00B54F58 File Offset: 0x00B53158
		public void Setup(double start, double loop, double end, bool enableLoop = true, bool ignoreTimeDilation = false)
		{
			this.Start = start;
			this.Loop = loop;
			this.End = end;
			this.WholeTime = start + loop + end;
			this.EnableLoop = enableLoop;
			this.CurrTime = 0.0;
			this.Ending = false;
			this.Dead = false;
			this.IgnoreTimeDilation = ignoreTimeDilation;
			this.CurrState = new EThreeSectionTimelineSection?(EThreeSectionTimelineSection.Start);
			this.CurrFactor = 0.0;
			double value = 0.001;
			if (Singleton<MathUtils>.Instance.IsNearlyEqual(loop, 0.0, new double?(value)))
			{
				this.LoopAsZero = true;
			}
			else
			{
				this.LoopAsZero = false;
			}
			if (Singleton<MathUtils>.Instance.IsNearlyEqual(end, 0.0, new double?(value)))
			{
				this.EndAsZero = true;
				return;
			}
			this.EndAsZero = false;
		}

		// Token: 0x0602F8E5 RID: 194789 RVA: 0x00B55030 File Offset: 0x00B53230
		public void Update(double delta)
		{
			if (this.Dead)
			{
				return;
			}
			double timeDelta = this.GetTimeDelta(delta);
			this.CurrTime += timeDelta;
			if (this.Ending)
			{
				if (this.CurrTime >= this.WholeTime)
				{
					this.Dead = true;
				}
			}
			else if (this.CurrTime >= this.Start + this.Loop)
			{
				if (this.EnableLoop)
				{
					if (this.LoopAsZero)
					{
						this.CurrTime = this.Start;
					}
					else
					{
						double num = this.CurrTime - this.Start;
						this.CurrTime = this.Start + (num - Math.Floor(num / this.Loop) * this.Loop);
					}
				}
				else
				{
					this.Ending = true;
					if (this.EndAsZero || this.CurrTime >= this.WholeTime)
					{
						this.Dead = true;
					}
				}
			}
			this.UpdateStateAndFactor();
		}

		// Token: 0x0602F8E6 RID: 194790 RVA: 0x00B55111 File Offset: 0x00B53311
		public void TriggerEnd()
		{
			this.Ending = true;
			this.CurrTime = this.Start + this.Loop;
			if (this.EndAsZero)
			{
				this.Dead = true;
			}
			this.UpdateStateAndFactor();
		}

		// Token: 0x0602F8E7 RID: 194791 RVA: 0x00B55142 File Offset: 0x00B53342
		public void SetLoop(bool enableLoop)
		{
			this.EnableLoop = enableLoop;
		}

		// Token: 0x0602F8E8 RID: 194792 RVA: 0x00B5514B File Offset: 0x00B5334B
		public EThreeSectionTimelineSection? GetCurrState()
		{
			return this.CurrState;
		}

		// Token: 0x0602F8E9 RID: 194793 RVA: 0x00B55153 File Offset: 0x00B53353
		public bool IsDead()
		{
			return this.Dead;
		}

		// Token: 0x0602F8EA RID: 194794 RVA: 0x00B5515B File Offset: 0x00B5335B
		public double GetCurrFactor()
		{
			return this.CurrFactor;
		}

		// Token: 0x0602F8EB RID: 194795 RVA: 0x00B55164 File Offset: 0x00B53364
		public float GetFloatFromGroup(SMaterialControllerFloatGroup floatGroup)
		{
			EThreeSectionTimelineSection? currState = this.CurrState;
			FKuroCurveFloat fkuroCurveFloat;
			if (currState != null)
			{
				EThreeSectionTimelineSection valueOrDefault = currState.GetValueOrDefault();
				if (valueOrDefault == EThreeSectionTimelineSection.Start)
				{
					fkuroCurveFloat = floatGroup.Start;
					return UKuroCurveLibrary.GetValue_Float(fkuroCurveFloat, (float)this.GetCurrFactor());
				}
				if (valueOrDefault == EThreeSectionTimelineSection.Loop)
				{
					fkuroCurveFloat = floatGroup.Loop;
					return UKuroCurveLibrary.GetValue_Float(fkuroCurveFloat, (float)this.GetCurrFactor());
				}
			}
			fkuroCurveFloat = floatGroup.End;
			return UKuroCurveLibrary.GetValue_Float(fkuroCurveFloat, (float)this.GetCurrFactor());
		}

		// Token: 0x0602F8EC RID: 194796 RVA: 0x00B551D4 File Offset: 0x00B533D4
		public FLinearColor GetColorFromGroup(SMaterialControllerColorGroup colorGroup)
		{
			EThreeSectionTimelineSection? currState = this.CurrState;
			FKuroCurveLinearColor fkuroCurveLinearColor;
			if (currState != null)
			{
				EThreeSectionTimelineSection valueOrDefault = currState.GetValueOrDefault();
				if (valueOrDefault == EThreeSectionTimelineSection.Start)
				{
					fkuroCurveLinearColor = colorGroup.Start;
					return UKuroCurveLibrary.GetValue_LinearColor(fkuroCurveLinearColor, (float)this.GetCurrFactor());
				}
				if (valueOrDefault == EThreeSectionTimelineSection.Loop)
				{
					fkuroCurveLinearColor = colorGroup.Loop;
					return UKuroCurveLibrary.GetValue_LinearColor(fkuroCurveLinearColor, (float)this.GetCurrFactor());
				}
			}
			fkuroCurveLinearColor = colorGroup.End;
			return UKuroCurveLibrary.GetValue_LinearColor(fkuroCurveLinearColor, (float)this.GetCurrFactor());
		}

		// Token: 0x0602F8ED RID: 194797 RVA: 0x00B55244 File Offset: 0x00B53444
		private double GetTimeDelta(double delta)
		{
			if (!this.IgnoreTimeDilation && ControllerBase<RenderModuleController>.Instance.IsGamePaused)
			{
				return 0.0;
			}
			if (this.IgnoreTimeDilation)
			{
				float globalTimeDilation = ControllerBase<RenderModuleController>.Instance.GlobalTimeDilation;
				if (!Singleton<MathUtils>.Instance.IsNearlyEqual((double)globalTimeDilation, 1.0, null))
				{
					return delta * (double)(1f / globalTimeDilation);
				}
			}
			return delta;
		}

		// Token: 0x0602F8EE RID: 194798 RVA: 0x00B552B0 File Offset: 0x00B534B0
		private void UpdateStateAndFactor()
		{
			if (this.Dead)
			{
				this.CurrState = new EThreeSectionTimelineSection?(EThreeSectionTimelineSection.Dead);
				this.CurrFactor = 1.0;
				return;
			}
			if (this.Ending)
			{
				this.CurrState = new EThreeSectionTimelineSection?(EThreeSectionTimelineSection.End);
				this.CurrFactor = (this.CurrTime - this.Start - this.Loop) / this.End;
				return;
			}
			if (this.CurrTime < this.Start)
			{
				this.CurrState = new EThreeSectionTimelineSection?(EThreeSectionTimelineSection.Start);
				this.CurrFactor = this.CurrTime / this.Start;
				return;
			}
			this.CurrState = new EThreeSectionTimelineSection?(EThreeSectionTimelineSection.Loop);
			if (this.LoopAsZero)
			{
				this.CurrFactor = 1.0;
			}
			this.CurrFactor = (this.CurrTime - this.Start) / this.Loop;
		}

		// Token: 0x0401B328 RID: 111400
		private double Start;

		// Token: 0x0401B329 RID: 111401
		private double Loop;

		// Token: 0x0401B32A RID: 111402
		private double End;

		// Token: 0x0401B32B RID: 111403
		private bool LoopAsZero;

		// Token: 0x0401B32C RID: 111404
		private bool EndAsZero;

		// Token: 0x0401B32D RID: 111405
		private double WholeTime;

		// Token: 0x0401B32E RID: 111406
		private bool EnableLoop;

		// Token: 0x0401B32F RID: 111407
		private double CurrTime;

		// Token: 0x0401B330 RID: 111408
		private bool Ending;

		// Token: 0x0401B331 RID: 111409
		private bool Dead = true;

		// Token: 0x0401B332 RID: 111410
		private bool IgnoreTimeDilation;

		// Token: 0x0401B333 RID: 111411
		private EThreeSectionTimelineSection? CurrState;

		// Token: 0x0401B334 RID: 111412
		private double CurrFactor;
	}
}
