using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200608F RID: 24719
	[NullableContext(2)]
	[Nullable(0)]
	public class QuickHackBuffItem : BuffItemBase
	{
		// Token: 0x0603E5E8 RID: 255464 RVA: 0x00FEDC04 File Offset: 0x00FEBE04
		[NullableContext(1)]
		public QuickHackBuffItem(USceneComponent parentItem)
		{
			AActor quickHackBuffItem = ControllerBase<BattleUiControl>.Instance.Pool.GetQuickHackBuffItem(parentItem);
			base.CreateThenShowByActor(quickHackBuffItem, null);
		}

		// Token: 0x0603E5E9 RID: 255465 RVA: 0x00FEDC30 File Offset: 0x00FEBE30
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E5EA RID: 255466 RVA: 0x00FEDCDC File Offset: 0x00FEBEDC
		protected override void OnStart()
		{
			this.BarTexture = base.GetTexture(1);
			this.BarTexture.SetFillAmount(0f);
			this.IconTexture = base.GetTexture(2);
			this.IconMaskTexture = base.GetTexture(3);
			this.IconMaskTexture.SetFillAmount(0f);
		}

		// Token: 0x0603E5EB RID: 255467 RVA: 0x00FEDD30 File Offset: 0x00FEBF30
		public override void Activate(GameplayCue buffCueConfig, IActiveBuff buff, bool playAnim, int buffNum)
		{
			this.Buff = buff;
			if (playAnim)
			{
				this.FillFinishTime = Singleton<Time>.Instance.Now + 200.0;
				this.SetPercent(0f);
				this.StartLoopAudio();
			}
			else
			{
				this.FillFinishTime = 0.0;
				float percent = (buff != null && buff.Duration > 0f) ? (buff.GetRemainDuration() / buff.Duration) : 1f;
				this.SetPercent(percent);
			}
			base.SetUiActive(true);
			string path = buffCueConfig.Path;
			this.IconTexture.SetUIActive(false);
			base.SetTextureByPath(path, this.IconTexture, null, delegate(bool result)
			{
				if (result)
				{
					UUITexture iconTexture = this.IconTexture;
					if (iconTexture == null)
					{
						return;
					}
					iconTexture.SetUIActive(true);
				}
			});
			this.IconMaskTexture.SetUIActive(false);
			base.SetTextureByPath(path, this.IconMaskTexture, null, delegate(bool result)
			{
				if (result)
				{
					UUITexture iconMaskTexture = this.IconMaskTexture;
					if (iconMaskTexture == null)
					{
						return;
					}
					iconMaskTexture.SetUIActive(true);
				}
			});
		}

		// Token: 0x0603E5EC RID: 255468 RVA: 0x00FEDE1C File Offset: 0x00FEC01C
		public override void Tick(float delta)
		{
			if (this.FillFinishTime > 0.0)
			{
				this.TickFill();
				return;
			}
			if (this.Buff != null && this.Buff.Duration > 0f)
			{
				this.SetPercent(this.Buff.GetRemainDuration() / this.Buff.Duration);
			}
		}

		// Token: 0x0603E5ED RID: 255469 RVA: 0x00FEDE78 File Offset: 0x00FEC078
		private void TickFill()
		{
			double now = Singleton<Time>.Instance.Now;
			float num = (float)(1.0 - (this.FillFinishTime - now) / 200.0);
			if (num >= 1f)
			{
				this.SetPercent(1f);
				this.FillFinishTime = 0.0;
				this.StopLoopAudio();
				Singleton<AudioSystem>.Instance.PostEvent("play_role_lucy_bat_burst01_qh_done");
				return;
			}
			this.SetPercent(num);
		}

		// Token: 0x0603E5EE RID: 255470 RVA: 0x00FEDEEE File Offset: 0x00FEC0EE
		private void SetPercent(float percent)
		{
			if (percent == this.Percent)
			{
				return;
			}
			this.Percent = percent;
			UUITexture barTexture = this.BarTexture;
			if (barTexture != null)
			{
				barTexture.SetFillAmount(percent);
			}
			UUITexture iconMaskTexture = this.IconMaskTexture;
			if (iconMaskTexture == null)
			{
				return;
			}
			iconMaskTexture.SetFillAmount(percent);
		}

		// Token: 0x0603E5EF RID: 255471 RVA: 0x00FEDF24 File Offset: 0x00FEC124
		public override bool TickHiding(float delta)
		{
			if (this.FillFinishTime > 0.0)
			{
				this.TickFill();
				return true;
			}
			base.SetUiActive(false);
			return false;
		}

		// Token: 0x0603E5F0 RID: 255472 RVA: 0x00FEDF47 File Offset: 0x00FEC147
		public override void Deactivate()
		{
			base.SetUiActive(false);
			this.FillFinishTime = 0.0;
		}

		// Token: 0x0603E5F1 RID: 255473 RVA: 0x00FEDF5F File Offset: 0x00FEC15F
		public override void DeactivateWithCloseAnim()
		{
		}

		// Token: 0x0603E5F2 RID: 255474 RVA: 0x00FEDF61 File Offset: 0x00FEC161
		protected override bool DestroyOverride()
		{
			if (this.RootActor != null)
			{
				ControllerBase<BattleUiControl>.Instance.Pool.RecycleQuickHackBuffItem(this.RootActor);
			}
			return true;
		}

		// Token: 0x0603E5F3 RID: 255475 RVA: 0x00FEDF84 File Offset: 0x00FEC184
		private void StartLoopAudio()
		{
			if (this.LoopAudioEventHandle != 0)
			{
				return;
			}
			int num = Singleton<AudioSystem>.Instance.PostEvent("play_role_lucy_bat_burst01_qh_loop");
			if (num != 0)
			{
				this.LoopAudioEventHandle = num;
				Singleton<EventSystem>.Instance.Add(EEventName.OnQuickHackClose, new Action(this.OnQuickHackClose));
			}
		}

		// Token: 0x0603E5F4 RID: 255476 RVA: 0x00FEDFD0 File Offset: 0x00FEC1D0
		private void OnQuickHackClose()
		{
			this.StopLoopAudio();
		}

		// Token: 0x0603E5F5 RID: 255477 RVA: 0x00FEDFD8 File Offset: 0x00FEC1D8
		private void StopLoopAudio()
		{
			if (this.LoopAudioEventHandle == 0)
			{
				return;
			}
			Singleton<AudioSystem>.Instance.ExecuteAction(this.LoopAudioEventHandle, EAudioActionType.Stop, null);
			this.LoopAudioEventHandle = 0;
			Singleton<EventSystem>.Instance.Remove(EEventName.OnQuickHackClose, new Action(this.OnQuickHackClose));
		}

		// Token: 0x04022F40 RID: 143168
		private const double ACTIVATE_FILL_TIME = 200.0;

		// Token: 0x04022F41 RID: 143169
		private IActiveBuff Buff;

		// Token: 0x04022F42 RID: 143170
		private UUITexture BarTexture;

		// Token: 0x04022F43 RID: 143171
		private UUITexture IconTexture;

		// Token: 0x04022F44 RID: 143172
		private UUITexture IconMaskTexture;

		// Token: 0x04022F45 RID: 143173
		private float Percent;

		// Token: 0x04022F46 RID: 143174
		private double FillFinishTime;

		// Token: 0x04022F47 RID: 143175
		private int LoopAudioEventHandle;

		// Token: 0x0200C17C RID: 49532
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x0403B94E RID: 244046
			public const int BgTexture = 0;

			// Token: 0x0403B94F RID: 244047
			public const int BarTexture = 1;

			// Token: 0x0403B950 RID: 244048
			public const int IconTexture = 2;

			// Token: 0x0403B951 RID: 244049
			public const int IconMaskTexture = 3;
		}
	}
}
