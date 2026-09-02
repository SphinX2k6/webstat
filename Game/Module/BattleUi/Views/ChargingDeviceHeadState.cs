using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006025 RID: 24613
	[NullableContext(1)]
	[Nullable(0)]
	public class ChargingDeviceHeadState : HeadStateViewBase
	{
		// Token: 0x0603E085 RID: 254085 RVA: 0x00FD50DC File Offset: 0x00FD32DC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E086 RID: 254086 RVA: 0x00FD5168 File Offset: 0x00FD3368
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x0603E087 RID: 254087 RVA: 0x00FD51A6 File Offset: 0x00FD33A6
		protected override string GetResourceId()
		{
			return "UiItem_HpClean";
		}

		// Token: 0x0603E088 RID: 254088 RVA: 0x00FD51B0 File Offset: 0x00FD33B0
		protected override void ActiveBattleHeadState(HeadStateData headStateData)
		{
			base.ActiveBattleHeadState(headStateData);
			UUITexture texture = base.GetTexture(1);
			UUIText text = base.GetText(0);
			float stretchLeft = texture.GetStretchLeft();
			float width = texture.GetParentAsUIItem().GetWidth();
			this.BarFullWidth = width - 2f * stretchLeft;
			texture.SetUIActive(true);
			text.SetUIActive(true);
			SceneItemProgressControlComponent.TProgressData progressControlData = headStateData.GetProgressControlData();
			if (progressControlData.ProgressCtrlType == EProgressBarControlType.ChargingDevice)
			{
				this.SetProgress(progressControlData.CurrentValue / progressControlData.MaxValue);
			}
		}

		// Token: 0x0603E089 RID: 254089 RVA: 0x00FD5226 File Offset: 0x00FD3426
		protected override void BindCallback()
		{
			base.BindCallback();
			this.HeadStateData.BindOnProgressControlDataChange(new Action<SceneItemProgressControlComponent.TProgressData>(this.OnProgressControlDataChange));
		}

		// Token: 0x0603E08A RID: 254090 RVA: 0x00FD5245 File Offset: 0x00FD3445
		public void OnProgressControlDataChange(SceneItemProgressControlComponent.TProgressData progressData)
		{
			if (progressData.ProgressCtrlType == EProgressBarControlType.ChargingDevice)
			{
				this.SetProgress(progressData.CurrentValue / progressData.MaxValue);
			}
		}

		// Token: 0x0603E08B RID: 254091 RVA: 0x00FD5264 File Offset: 0x00FD3464
		private void SetProgress(float progress)
		{
			base.GetTexture(1).SetFillAmount(progress);
			float inX = Singleton<MathUtils>.Instance.Clamp(progress, 0f, 1f) * this.BarFullWidth - this.BarFullWidth / 2f;
			base.GetTexture(2).SetUIRelativeLocation(new FVector(inX, 0f, 0f));
			int value = (int)Math.Round((double)Singleton<MathUtils>.Instance.RangeClamp(progress, 0f, 1f, 0f, 100f));
			UUIText text = base.GetText(0);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			defaultInterpolatedStringHandler.AppendLiteral("%");
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			if (progress >= 1f && !this.PlayedFullSequence)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.PlayLevelSequenceByName("Full", false, null, false);
				}
				this.PlayedFullSequence = true;
			}
		}

		// Token: 0x04022C80 RID: 142464
		private float BarFullWidth;

		// Token: 0x04022C81 RID: 142465
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04022C82 RID: 142466
		private bool PlayedFullSequence;

		// Token: 0x0200C0D8 RID: 49368
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B5F2 RID: 243186
			TxtProgress,
			// Token: 0x0403B5F3 RID: 243187
			BarProgress,
			// Token: 0x0403B5F4 RID: 243188
			TexHandle
		}
	}
}
