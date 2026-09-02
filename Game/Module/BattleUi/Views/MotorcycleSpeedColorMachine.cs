using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006089 RID: 24713
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorcycleSpeedColorMachine
	{
		// Token: 0x0603E59B RID: 255387 RVA: 0x00FEC634 File Offset: 0x00FEA834
		public void Init(string color, int? duration = null)
		{
			this.TargetColor = color;
			this.ParseColorValues(color, this.TargetColorValues);
			for (int i = 0; i < 4; i++)
			{
				this.CurrentColorValues[i] = this.TargetColorValues[i];
			}
			if (duration != null)
			{
				this.Duration = duration.Value;
				for (int j = 0; j < 4; j++)
				{
					this.Speed[j] = 0.0;
				}
			}
			this.IsLerpFinish = true;
			this.UpdateColorByCurrentColor();
		}

		// Token: 0x0603E59C RID: 255388 RVA: 0x00FEC6B4 File Offset: 0x00FEA8B4
		private void UpdateColorByCurrentColor()
		{
			this.Color.R = (float)(this.CurrentColorValues[0] / 255.0);
			this.Color.G = (float)(this.CurrentColorValues[1] / 255.0);
			this.Color.B = (float)(this.CurrentColorValues[2] / 255.0);
			this.Color.A = (float)(this.CurrentColorValues[3] / 255.0);
		}

		// Token: 0x0603E59D RID: 255389 RVA: 0x00FEC73C File Offset: 0x00FEA93C
		private void ParseColorValues(string color, double[] outValues)
		{
			for (int i = 0; i < 4; i++)
			{
				int num = i * 2;
				if (num + 2 <= color.Length)
				{
					outValues[i] = (double)int.Parse(color.Substring(num, 2), NumberStyles.HexNumber);
				}
				else
				{
					outValues[i] = 255.0;
				}
			}
		}

		// Token: 0x0603E59E RID: 255390 RVA: 0x00FEC788 File Offset: 0x00FEA988
		public void SetTargetColor(string color)
		{
			if (color == this.TargetColor)
			{
				return;
			}
			this.TargetColor = color;
			this.ParseColorValues(color, this.TargetColorValues);
			for (int i = 0; i < 4; i++)
			{
				this.Speed[i] = (this.TargetColorValues[i] - this.CurrentColorValues[i]) / (double)this.Duration;
			}
			this.IsLerpFinish = false;
		}

		// Token: 0x0603E59F RID: 255391 RVA: 0x00FEC7EC File Offset: 0x00FEA9EC
		public bool Update(double delta)
		{
			if (this.IsLerpFinish)
			{
				return false;
			}
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				double num2 = this.Speed[i];
				if (num2 == 0.0)
				{
					num++;
				}
				else
				{
					this.CurrentColorValues[i] += num2 * delta;
					if (num2 > 0.0)
					{
						if (this.CurrentColorValues[i] >= this.TargetColorValues[i])
						{
							this.CurrentColorValues[i] = this.TargetColorValues[i];
							this.Speed[i] = 0.0;
							num++;
						}
					}
					else if (this.CurrentColorValues[i] <= this.TargetColorValues[i])
					{
						this.CurrentColorValues[i] = this.TargetColorValues[i];
						this.Speed[i] = 0.0;
						num++;
					}
				}
			}
			this.UpdateColorByCurrentColor();
			if (num == 4)
			{
				this.IsLerpFinish = true;
			}
			return true;
		}

		// Token: 0x0603E5A0 RID: 255392 RVA: 0x00FEC8D6 File Offset: 0x00FEAAD6
		public FLinearColor GetColor()
		{
			return this.Color;
		}

		// Token: 0x04022F1A RID: 143130
		private const int COLOR_NUM = 4;

		// Token: 0x04022F1B RID: 143131
		private const int DURATION = 350;

		// Token: 0x04022F1C RID: 143132
		private readonly double[] CurrentColorValues = new double[4];

		// Token: 0x04022F1D RID: 143133
		private readonly double[] TargetColorValues = new double[4];

		// Token: 0x04022F1E RID: 143134
		private readonly double[] Speed = new double[4];

		// Token: 0x04022F1F RID: 143135
		private string TargetColor = string.Empty;

		// Token: 0x04022F20 RID: 143136
		private FLinearColor Color;

		// Token: 0x04022F21 RID: 143137
		private bool IsLerpFinish;

		// Token: 0x04022F22 RID: 143138
		public int Duration = 350;
	}
}
