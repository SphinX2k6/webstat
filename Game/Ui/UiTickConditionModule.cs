using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A5D RID: 19037
	[NullableContext(1)]
	[Nullable(0)]
	public class UiTickConditionModule
	{
		// Token: 0x06031B94 RID: 203668 RVA: 0x00C643BD File Offset: 0x00C625BD
		public UiTickConditionModule(string tag)
		{
			this.Tag = tag;
		}

		// Token: 0x06031B95 RID: 203669 RVA: 0x00C643D4 File Offset: 0x00C625D4
		public void StartTick(Func<float, bool> checkCondition, Action<float> stopCallback, Action<float> finishCallback)
		{
			this.CheckCondition = checkCondition;
			this.StopCallback = stopCallback;
			this.FinishCallback = finishCallback;
			this.TickId = Singleton<TickSystem>.Instance.Add(new Action<float>(this.Tick), "UiTickConditionModule", ETickingGroup.TG_PrePhysics, true, 0, false).Id;
		}

		// Token: 0x06031B96 RID: 203670 RVA: 0x00C64420 File Offset: 0x00C62620
		public void ManualStopTick()
		{
			if (this.StopCallback == null)
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiTickConditionModule;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "手动停止Tick,执行停止回调";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("标识", this.Tag);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Action<float> stopCallback = this.StopCallback;
			if (stopCallback != null)
			{
				stopCallback(this.CurrentTickTime);
			}
			this.StopTick();
		}

		// Token: 0x06031B97 RID: 203671 RVA: 0x00C64482 File Offset: 0x00C62682
		private void StopTick()
		{
			this.RemoveTick();
			this.CurrentTickTime = 0f;
			this.CheckCondition = null;
			this.StopCallback = null;
			this.FinishCallback = null;
		}

		// Token: 0x06031B98 RID: 203672 RVA: 0x00C644AA File Offset: 0x00C626AA
		private void RemoveTick()
		{
			if (this.TickId != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.TickId);
			}
		}

		// Token: 0x06031B99 RID: 203673 RVA: 0x00C644C8 File Offset: 0x00C626C8
		private void Tick(float deltaTime)
		{
			Func<float, bool> checkCondition = this.CheckCondition;
			if (checkCondition != null && checkCondition(deltaTime))
			{
				Action<float> finishCallback = this.FinishCallback;
				if (finishCallback != null)
				{
					finishCallback(this.CurrentTickTime);
				}
				Action<float> stopCallback = this.StopCallback;
				if (stopCallback != null)
				{
					stopCallback(this.CurrentTickTime);
				}
				this.StopTick();
				return;
			}
			this.CurrentTickTime += deltaTime;
		}

		// Token: 0x0401CEC4 RID: 118468
		private readonly string Tag;

		// Token: 0x0401CEC5 RID: 118469
		private Action<float> FinishCallback;

		// Token: 0x0401CEC6 RID: 118470
		private Action<float> StopCallback;

		// Token: 0x0401CEC7 RID: 118471
		private Func<float, bool> CheckCondition;

		// Token: 0x0401CEC8 RID: 118472
		private float CurrentTickTime;

		// Token: 0x0401CEC9 RID: 118473
		private int TickId = -1;
	}
}
