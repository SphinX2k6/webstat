using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FD3 RID: 24531
	public class BattleSkillLongPressItem : UiPanelBase
	{
		// Token: 0x0603DB9D RID: 252829 RVA: 0x00FB98EC File Offset: 0x00FB7AEC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DB9E RID: 252830 RVA: 0x00FB9934 File Offset: 0x00FB7B34
		protected override void OnStart()
		{
			this.ProgressTex = base.GetTexture(0);
			UUITexture progressTex = this.ProgressTex;
			if (progressTex != null)
			{
				progressTex.SetFillAmount(0f);
			}
			this.SetComponentActive(this.TargetActive);
		}

		// Token: 0x0603DB9F RID: 252831 RVA: 0x00FB9965 File Offset: 0x00FB7B65
		protected override void OnBeforeShow()
		{
			this.BindEvents();
		}

		// Token: 0x0603DBA0 RID: 252832 RVA: 0x00FB996D File Offset: 0x00FB7B6D
		protected override void OnAfterHide()
		{
			this.UnbindEvents();
			this.ClearTimer();
		}

		// Token: 0x0603DBA1 RID: 252833 RVA: 0x00FB997B File Offset: 0x00FB7B7B
		protected override void OnBeforeDestroy()
		{
			this.UnbindEvents();
			this.ClearTimer();
		}

		// Token: 0x0603DBA2 RID: 252834 RVA: 0x00FB998C File Offset: 0x00FB7B8C
		private void BindEvents()
		{
			if (this.IsBindEvent)
			{
				return;
			}
			this.IsBindEvent = true;
			Singleton<EventSystem>.Instance.Add(EEventName.SkillLongPressStart, new Action<EInputAction>(this.OnSkillLongPressStart));
			Singleton<EventSystem>.Instance.Add(EEventName.SkillLongPressEnd, new Action<EInputAction>(this.OnSkillLongPressEnd));
		}

		// Token: 0x0603DBA3 RID: 252835 RVA: 0x00FB99E4 File Offset: 0x00FB7BE4
		private void UnbindEvents()
		{
			if (!this.IsBindEvent)
			{
				return;
			}
			this.IsBindEvent = false;
			Singleton<EventSystem>.Instance.Remove(EEventName.SkillLongPressStart, new Action<EInputAction>(this.OnSkillLongPressStart));
			Singleton<EventSystem>.Instance.Remove(EEventName.SkillLongPressEnd, new Action<EInputAction>(this.OnSkillLongPressEnd));
		}

		// Token: 0x0603DBA4 RID: 252836 RVA: 0x00FB9A39 File Offset: 0x00FB7C39
		private void ClearTimer()
		{
			if (this.Timer == null)
			{
				return;
			}
			TimerSystem.Instance.Remove(this.Timer);
			this.Timer = null;
		}

		// Token: 0x0603DBA5 RID: 252837 RVA: 0x00FB9A5C File Offset: 0x00FB7C5C
		public void SetComponentActive(bool visibility)
		{
			if (this.TargetActive == visibility && !this.IsFirstShow)
			{
				return;
			}
			this.TargetActive = visibility;
			if (base.InAsyncLoading())
			{
				return;
			}
			this.IsFirstShow = false;
			this.SetActive(visibility);
			UUITexture progressTex = this.ProgressTex;
			if (progressTex == null)
			{
				return;
			}
			progressTex.SetFillAmount(0f);
		}

		// Token: 0x0603DBA6 RID: 252838 RVA: 0x00FB9AAE File Offset: 0x00FB7CAE
		public void SetAction(in EInputAction action)
		{
			this.Action = new EInputAction?(action);
		}

		// Token: 0x0603DBA7 RID: 252839 RVA: 0x00FB9AC1 File Offset: 0x00FB7CC1
		public void SetDuration(float duration)
		{
			this.Duration = duration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		}

		// Token: 0x0603DBA8 RID: 252840 RVA: 0x00FB9AD8 File Offset: 0x00FB7CD8
		private void OnSkillLongPressStart(EInputAction action)
		{
			if (this.Action != action)
			{
				return;
			}
			if (this.Duration <= 0f)
			{
				return;
			}
			this.StartProgress();
		}

		// Token: 0x0603DBA9 RID: 252841 RVA: 0x00FB9B20 File Offset: 0x00FB7D20
		private void OnSkillLongPressEnd(EInputAction action)
		{
			if (this.Action != action)
			{
				return;
			}
			this.StopProgress();
			UUITexture progressTex = this.ProgressTex;
			if (progressTex == null)
			{
				return;
			}
			progressTex.SetFillAmount(0f);
		}

		// Token: 0x0603DBAA RID: 252842 RVA: 0x00FB9B70 File Offset: 0x00FB7D70
		public void StartProgress()
		{
			this.ClearTimer();
			this.StartTime = (float)Singleton<Time>.Instance.WorldTime;
			int num = 20;
			this.Timer = TimerSystem.Instance.Forever(delegate(float _)
			{
				float num2 = (float)Singleton<Time>.Instance.WorldTime - this.StartTime;
				float num3 = Math.Min(1f, num2 / this.Duration);
				UUITexture progressTex = this.ProgressTex;
				if (progressTex != null)
				{
					progressTex.SetFillAmount(num3);
				}
				if (num3 == 1f)
				{
					this.StopProgress();
				}
			}, (float)num, 1f, null, null, true);
		}

		// Token: 0x0603DBAB RID: 252843 RVA: 0x00FB9BBD File Offset: 0x00FB7DBD
		private void StopProgress()
		{
			this.ClearTimer();
		}

		// Token: 0x04022A1C RID: 141852
		public bool TargetActive;

		// Token: 0x04022A1D RID: 141853
		[Nullable(2)]
		private UUITexture ProgressTex;

		// Token: 0x04022A1E RID: 141854
		private bool IsBindEvent;

		// Token: 0x04022A1F RID: 141855
		private EInputAction? Action;

		// Token: 0x04022A20 RID: 141856
		private float Duration;

		// Token: 0x04022A21 RID: 141857
		[Nullable(2)]
		private TimerHandle Timer;

		// Token: 0x04022A22 RID: 141858
		private float StartTime;

		// Token: 0x04022A23 RID: 141859
		private bool IsFirstShow = true;

		// Token: 0x0200C041 RID: 49217
		private enum ESkillLongPressItem
		{
			// Token: 0x0403B2E8 RID: 242408
			ProgressTex
		}
	}
}
