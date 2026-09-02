using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052E0 RID: 21216
	[NullableContext(2)]
	[Nullable(0)]
	public class QuickHackMarkInstance
	{
		// Token: 0x060362EC RID: 221932 RVA: 0x00DA5D04 File Offset: 0x00DA3F04
		[NullableContext(1)]
		public void StartMark(int id, EntityHandle entityHandle, double uploadTime, double duration, string iconPath)
		{
			if (uploadTime > 0.0)
			{
				this.UploadTime = uploadTime;
				this.UploadEnableTimeScale = true;
			}
			else
			{
				this.UploadTime = 300.0;
				this.UploadEnableTimeScale = false;
			}
			this.Id = id;
			this.Owner = entityHandle;
			this.Duration = duration;
			this.IconPath = iconPath;
			this.CurrentProgress = 0.0;
			this.StartUpload();
		}

		// Token: 0x060362ED RID: 221933 RVA: 0x00DA5D76 File Offset: 0x00DA3F76
		public void ClearMark()
		{
			this.FinishPerform();
		}

		// Token: 0x060362EE RID: 221934 RVA: 0x00DA5D80 File Offset: 0x00DA3F80
		public void UpdateMark()
		{
			if (this.CurrentState == EQuickHackMarkState.Finish)
			{
				return;
			}
			double num = Singleton<MathUtils>.Instance.RangeClamp(this.GetTimeStamp(), this.ProgressStartTime, this.ProgressEndTime, this.ProgressFrom, this.ProgressTo);
			this.CurrentProgress = num;
			if (num != this.ProgressTo)
			{
				Action<double> onProgressChange = this.OnProgressChange;
				if (onProgressChange == null)
				{
					return;
				}
				onProgressChange(num);
				return;
			}
			else
			{
				if (this.CurrentState != EQuickHackMarkState.Upload || this.Duration <= 0.0)
				{
					this.FinishPerform();
					return;
				}
				this.StartDuration();
				Action<double> onProgressChange2 = this.OnProgressChange;
				if (onProgressChange2 == null)
				{
					return;
				}
				onProgressChange2(num);
				return;
			}
		}

		// Token: 0x060362EF RID: 221935 RVA: 0x00DA5E19 File Offset: 0x00DA4019
		public int GetId()
		{
			return this.Id;
		}

		// Token: 0x060362F0 RID: 221936 RVA: 0x00DA5E21 File Offset: 0x00DA4021
		public EntityHandle GetOwner()
		{
			return this.Owner;
		}

		// Token: 0x060362F1 RID: 221937 RVA: 0x00DA5E29 File Offset: 0x00DA4029
		public double GetCurrentProgress()
		{
			return this.CurrentProgress;
		}

		// Token: 0x060362F2 RID: 221938 RVA: 0x00DA5E31 File Offset: 0x00DA4031
		public EQuickHackMarkState GetCurrentState()
		{
			return this.CurrentState;
		}

		// Token: 0x060362F3 RID: 221939 RVA: 0x00DA5E39 File Offset: 0x00DA4039
		public bool IsFinish()
		{
			return this.CurrentState == EQuickHackMarkState.Finish;
		}

		// Token: 0x060362F4 RID: 221940 RVA: 0x00DA5E44 File Offset: 0x00DA4044
		public string GetIconPath()
		{
			return this.IconPath;
		}

		// Token: 0x060362F5 RID: 221941 RVA: 0x00DA5E4C File Offset: 0x00DA404C
		[NullableContext(1)]
		public void RegisterOnProgressChange(Action<double> onProgressChange)
		{
			this.OnProgressChange = onProgressChange;
		}

		// Token: 0x060362F6 RID: 221942 RVA: 0x00DA5E55 File Offset: 0x00DA4055
		public void UnRegisterOnProgressChange()
		{
			this.OnProgressChange = null;
		}

		// Token: 0x060362F7 RID: 221943 RVA: 0x00DA5E5E File Offset: 0x00DA405E
		[NullableContext(1)]
		public void RegisterOnStateChange(Action<EQuickHackMarkState, EQuickHackMarkState> onStateChange)
		{
			this.OnStateChange = onStateChange;
		}

		// Token: 0x060362F8 RID: 221944 RVA: 0x00DA5E67 File Offset: 0x00DA4067
		public void UnRegisterOnStateChange()
		{
			this.OnStateChange = null;
		}

		// Token: 0x060362F9 RID: 221945 RVA: 0x00DA5E70 File Offset: 0x00DA4070
		private void StartUpload()
		{
			EQuickHackMarkState currentState = this.CurrentState;
			this.CurrentState = EQuickHackMarkState.Upload;
			Action<EQuickHackMarkState, EQuickHackMarkState> onStateChange = this.OnStateChange;
			if (onStateChange != null)
			{
				onStateChange(currentState, this.CurrentState);
			}
			this.ProgressStartTime = this.GetTimeStamp();
			this.ProgressEndTime = this.ProgressStartTime + this.UploadTime;
			this.ProgressFrom = 0.0;
			this.ProgressTo = 1.0;
		}

		// Token: 0x060362FA RID: 221946 RVA: 0x00DA5EE0 File Offset: 0x00DA40E0
		private void StartDuration()
		{
			EQuickHackMarkState currentState = this.CurrentState;
			this.CurrentState = EQuickHackMarkState.Duration;
			Action<EQuickHackMarkState, EQuickHackMarkState> onStateChange = this.OnStateChange;
			if (onStateChange != null)
			{
				onStateChange(currentState, this.CurrentState);
			}
			this.ProgressStartTime = this.GetTimeStamp();
			this.ProgressEndTime = this.ProgressStartTime + this.Duration;
			this.ProgressFrom = 1.0;
			this.ProgressTo = 0.0;
		}

		// Token: 0x060362FB RID: 221947 RVA: 0x00DA5F50 File Offset: 0x00DA4150
		private void FinishPerform()
		{
			EQuickHackMarkState currentState = this.CurrentState;
			this.CurrentState = EQuickHackMarkState.Finish;
			this.Owner = null;
			Action<double> onProgressChange = this.OnProgressChange;
			if (onProgressChange != null)
			{
				onProgressChange(this.ProgressTo);
			}
			this.OnProgressChange = null;
			Action<EQuickHackMarkState, EQuickHackMarkState> onStateChange = this.OnStateChange;
			if (onStateChange != null)
			{
				onStateChange(currentState, this.CurrentState);
			}
			this.OnStateChange = null;
		}

		// Token: 0x060362FC RID: 221948 RVA: 0x00DA5FAF File Offset: 0x00DA41AF
		private double GetTimeStamp()
		{
			if (this.CurrentState != EQuickHackMarkState.Upload || this.UploadEnableTimeScale)
			{
				return Singleton<Time>.Instance.FlowTime;
			}
			return Singleton<Time>.Instance.PlayerTime;
		}

		// Token: 0x0401F21F RID: 127519
		private const int DEFAULT_UPLOAD_TIME = 300;

		// Token: 0x0401F220 RID: 127520
		private int Id;

		// Token: 0x0401F221 RID: 127521
		private EntityHandle Owner;

		// Token: 0x0401F222 RID: 127522
		private string IconPath;

		// Token: 0x0401F223 RID: 127523
		private double UploadTime;

		// Token: 0x0401F224 RID: 127524
		private bool UploadEnableTimeScale;

		// Token: 0x0401F225 RID: 127525
		private double Duration;

		// Token: 0x0401F226 RID: 127526
		private EQuickHackMarkState CurrentState;

		// Token: 0x0401F227 RID: 127527
		private double ProgressStartTime;

		// Token: 0x0401F228 RID: 127528
		private double ProgressEndTime;

		// Token: 0x0401F229 RID: 127529
		private double ProgressFrom;

		// Token: 0x0401F22A RID: 127530
		private double ProgressTo;

		// Token: 0x0401F22B RID: 127531
		private double CurrentProgress;

		// Token: 0x0401F22C RID: 127532
		private Action<double> OnProgressChange;

		// Token: 0x0401F22D RID: 127533
		private Action<EQuickHackMarkState, EQuickHackMarkState> OnStateChange;
	}
}
