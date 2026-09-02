using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060C7 RID: 24775
	[NullableContext(1)]
	[Nullable(0)]
	internal class SpecialEnergyBarKaTiXiYaStar : UiPanelBase
	{
		// Token: 0x0603E924 RID: 256292 RVA: 0x01001DF0 File Offset: 0x00FFFFF0
		protected override void OnRegisterComponent()
		{
			this.ItemNum = 11;
			for (int i = 0; i < this.ItemNum; i++)
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(i, typeof(UUIItem)));
			}
		}

		// Token: 0x0603E925 RID: 256293 RVA: 0x01001E34 File Offset: 0x01000034
		protected override void OnStart()
		{
			for (int i = 0; i < this.ItemNum; i++)
			{
				this.TargetAlphaList.Add(1f);
				this.CurAlphaList.Add(1f);
			}
			this.AlphaSpeed = 0.0033333334f;
		}

		// Token: 0x0603E926 RID: 256294 RVA: 0x01001E80 File Offset: 0x01000080
		public void SetStarNum(int starNum)
		{
			if (this.CurStarNum == starNum)
			{
				return;
			}
			int num = Math.Max(starNum * 2 - 1, 0);
			if (this.CurStarNum == -1)
			{
				for (int i = 0; i < this.ItemNum; i++)
				{
					base.GetItem(i).SetUIActive(i < num);
					base.GetItem(i).SetAlpha(1f);
				}
			}
			else
			{
				int num2 = Math.Max(this.CurStarNum * 2 - 1, 0);
				if (num2 > num)
				{
					for (int j = num; j < num2; j++)
					{
						this.PlayStarHideAnim(j);
					}
				}
				else
				{
					for (int k = num2; k < num; k++)
					{
						base.GetItem(k).SetUIActive(true);
						this.StopStarHideAnim(k);
					}
				}
			}
			this.CurStarNum = starNum;
		}

		// Token: 0x0603E927 RID: 256295 RVA: 0x01001F37 File Offset: 0x01000137
		private void PlayStarHideAnim(int index)
		{
			this.TargetAlphaList[index] = 0f;
			this.IsAnyEffectPlaying = true;
		}

		// Token: 0x0603E928 RID: 256296 RVA: 0x01001F51 File Offset: 0x01000151
		private void StopStarHideAnim(int index)
		{
			this.TargetAlphaList[index] = 1f;
			this.CurAlphaList[index] = 1f;
			base.GetItem(index).SetAlpha(1f);
		}

		// Token: 0x0603E929 RID: 256297 RVA: 0x01001F88 File Offset: 0x01000188
		public void Tick(float delta)
		{
			if (!this.IsAnyEffectPlaying)
			{
				return;
			}
			this.IsAnyEffectPlaying = false;
			float num = delta * this.AlphaSpeed;
			for (int i = 0; i < this.ItemNum; i++)
			{
				if (this.CurAlphaList[i] != this.TargetAlphaList[i])
				{
					if (this.CurAlphaList[i] < this.TargetAlphaList[i])
					{
						this.CurAlphaList[i] = this.TargetAlphaList[i];
					}
					else
					{
						List<float> curAlphaList = this.CurAlphaList;
						int index = i;
						curAlphaList[index] -= num;
						if (this.CurAlphaList[i] <= this.TargetAlphaList[i])
						{
							this.CurAlphaList[i] = this.TargetAlphaList[i];
						}
						else
						{
							this.IsAnyEffectPlaying = true;
						}
					}
					base.GetItem(i).SetAlpha(this.CurAlphaList[i]);
					if (this.CurAlphaList[i] == 0f)
					{
						base.GetItem(i).SetUIActive(false);
					}
				}
			}
		}

		// Token: 0x0402314F RID: 143695
		private const int ALPHA_ANIM_TIME = 300;

		// Token: 0x04023150 RID: 143696
		public const int StarTotalNum = 6;

		// Token: 0x04023151 RID: 143697
		private int ItemNum;

		// Token: 0x04023152 RID: 143698
		private int CurStarNum = -1;

		// Token: 0x04023153 RID: 143699
		private readonly List<float> TargetAlphaList = new List<float>();

		// Token: 0x04023154 RID: 143700
		private readonly List<float> CurAlphaList = new List<float>();

		// Token: 0x04023155 RID: 143701
		private bool IsAnyEffectPlaying;

		// Token: 0x04023156 RID: 143702
		private float AlphaSpeed = 1f;
	}
}
