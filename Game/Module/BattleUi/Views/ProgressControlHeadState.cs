using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006034 RID: 24628
	[NullableContext(1)]
	[Nullable(0)]
	public class ProgressControlHeadState : HeadStateViewBase
	{
		// Token: 0x0603E208 RID: 254472 RVA: 0x00FDB504 File Offset: 0x00FD9704
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E209 RID: 254473 RVA: 0x00FDB56D File Offset: 0x00FD976D
		protected override string GetResourceId()
		{
			return "UiItem_BarInteractive";
		}

		// Token: 0x0603E20A RID: 254474 RVA: 0x00FDB574 File Offset: 0x00FD9774
		protected override void ActiveBattleHeadState(HeadStateData headStateData)
		{
			base.ActiveBattleHeadState(headStateData);
			UUISprite sprite = base.GetSprite(0);
			UUIText text = base.GetText(1);
			float stretchLeft = sprite.GetStretchLeft();
			float width = sprite.GetParentAsUIItem().GetWidth();
			this.BarFullWidth = width - 2f * stretchLeft;
			sprite.SetUIActive(true);
			text.SetUIActive(true);
			SceneItemProgressControlComponent.TProgressData progressControlData = headStateData.GetProgressControlData();
			EProgressBarControlType progressCtrlType = progressControlData.ProgressCtrlType;
			if (progressCtrlType <= EProgressBarControlType.ChargingDevice)
			{
				this.SetProgress(progressControlData.CurrentValue / progressControlData.MaxValue);
			}
		}

		// Token: 0x0603E20B RID: 254475 RVA: 0x00FDB5EE File Offset: 0x00FD97EE
		protected override void BindCallback()
		{
			base.BindCallback();
			this.HeadStateData.BindOnProgressControlDataChange(new Action<SceneItemProgressControlComponent.TProgressData>(this.OnProgressControlDataChange));
		}

		// Token: 0x0603E20C RID: 254476 RVA: 0x00FDB610 File Offset: 0x00FD9810
		public void OnProgressControlDataChange(SceneItemProgressControlComponent.TProgressData progressData)
		{
			EProgressBarControlType progressCtrlType = progressData.ProgressCtrlType;
			if (progressCtrlType <= EProgressBarControlType.ChargingDevice)
			{
				this.SetProgress(progressData.CurrentValue / progressData.MaxValue);
			}
		}

		// Token: 0x0603E20D RID: 254477 RVA: 0x00FDB63C File Offset: 0x00FD983C
		private void SetProgress(float progress)
		{
			float width = Singleton<MathUtils>.Instance.Clamp(progress, 0f, 1f) * this.BarFullWidth;
			base.GetSprite(0).SetWidth(width);
			int num = (int)Math.Round((double)Singleton<MathUtils>.Instance.RangeClamp(progress, 0f, 1f, 0f, 100f));
			base.GetText(1).SetText(num.ToString() + "%", true);
		}

		// Token: 0x04022D35 RID: 142645
		private float BarFullWidth;

		// Token: 0x0200C0E8 RID: 49384
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B693 RID: 243347
			BarProgress,
			// Token: 0x0403B694 RID: 243348
			TxtProgress
		}
	}
}
