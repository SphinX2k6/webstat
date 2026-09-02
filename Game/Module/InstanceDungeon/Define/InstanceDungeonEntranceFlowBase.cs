using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C22 RID: 23586
	[NullableContext(1)]
	[Nullable(0)]
	public class InstanceDungeonEntranceFlowBase
	{
		// Token: 0x170097D2 RID: 38866
		// (get) Token: 0x0603BA0A RID: 244234 RVA: 0x00F1BD33 File Offset: 0x00F19F33
		private bool IsFinish
		{
			get
			{
				return this.CurrentStep > 0 && this.CurrentStep >= this.StepArray.Count;
			}
		}

		// Token: 0x0603BA0B RID: 244235 RVA: 0x00F1BD56 File Offset: 0x00F19F56
		public InstanceDungeonEntranceFlowBase()
		{
			this.OnCreate();
		}

		// Token: 0x0603BA0C RID: 244236 RVA: 0x00F1BD78 File Offset: 0x00F19F78
		private void DoNextStep()
		{
			this.CurrentStep++;
			if (this.CurrentStep < 0 || this.CurrentStep >= this.StepArray.Count)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.InstanceDungeon;
				ELogAuthor author = ELogAuthor.TL;
				string message = "副本进入流程执行失败，当前步数与总步数不匹配！";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CurrentStep", this.CurrentStep);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.StepArray[this.CurrentStep]();
		}

		// Token: 0x0603BA0D RID: 244237 RVA: 0x00F1BDF7 File Offset: 0x00F19FF7
		public void Reset()
		{
			this.CurrentStep = -1;
		}

		// Token: 0x0603BA0E RID: 244238 RVA: 0x00F1BE00 File Offset: 0x00F1A000
		public void ResetToBeforeLast()
		{
			this.CurrentStep = this.StepArray.Count - 2;
		}

		// Token: 0x0603BA0F RID: 244239 RVA: 0x00F1BE15 File Offset: 0x00F1A015
		public void Start()
		{
			this.Reset();
			this.DoNextStep();
		}

		// Token: 0x0603BA10 RID: 244240 RVA: 0x00F1BE23 File Offset: 0x00F1A023
		public void Flow()
		{
			if (this.IsFinish)
			{
				return;
			}
			this.DoNextStep();
		}

		// Token: 0x0603BA11 RID: 244241 RVA: 0x00F1BE34 File Offset: 0x00F1A034
		public void RevertStep()
		{
			if (this.IsFinish)
			{
				return;
			}
			this.CurrentStep--;
		}

		// Token: 0x0603BA12 RID: 244242 RVA: 0x00F1BE4D File Offset: 0x00F1A04D
		public void OnEditBattleViewClose()
		{
			this.OnEditBattleViewCloseCall();
		}

		// Token: 0x0603BA13 RID: 244243 RVA: 0x00F1BE55 File Offset: 0x00F1A055
		protected void AddStep(Action step)
		{
			this.StepArray.Add(step);
		}

		// Token: 0x0603BA14 RID: 244244 RVA: 0x00F1BE63 File Offset: 0x00F1A063
		protected virtual void OnCreate()
		{
		}

		// Token: 0x0603BA15 RID: 244245 RVA: 0x00F1BE65 File Offset: 0x00F1A065
		protected virtual void OnEditBattleViewCloseCall()
		{
		}

		// Token: 0x040218E1 RID: 137441
		private readonly List<Action> StepArray = new List<Action>();

		// Token: 0x040218E2 RID: 137442
		private int CurrentStep = -1;
	}
}
