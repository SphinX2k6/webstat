using System;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Utils.CombatStateMachine;

namespace CSharpScript.Game.AI.StateMachine.Task
{
	// Token: 0x020070DD RID: 28893
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineTaskRandomMontage : AiStateMachineTask, IAiTaskMontage
	{
		// Token: 0x1700A5EC RID: 42476
		// (get) Token: 0x060460DB RID: 286939 RVA: 0x01266427 File Offset: 0x01264627
		// (set) Token: 0x060460DC RID: 286940 RVA: 0x0126642F File Offset: 0x0126462F
		public bool Playing { get; set; }

		// Token: 0x1700A5ED RID: 42477
		// (get) Token: 0x060460DD RID: 286941 RVA: 0x01266438 File Offset: 0x01264638
		// (set) Token: 0x060460DE RID: 286942 RVA: 0x01266440 File Offset: 0x01264640
		public float RemainedTrigger { get; set; } = -1f;

		// Token: 0x060460DF RID: 286943 RVA: 0x01266449 File Offset: 0x01264649
		public AiStateMachineTaskRandomMontage(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Task state) : base(stateMachineNode, state)
		{
		}

		// Token: 0x1700A5EE RID: 42478
		// (get) Token: 0x060460E0 RID: 286944 RVA: 0x0126645E File Offset: 0x0126465E
		public bool HasResource
		{
			get
			{
				return this.MontageHandle != null;
			}
		}

		// Token: 0x060460E1 RID: 286945 RVA: 0x0126646C File Offset: 0x0126466C
		protected override bool OnInit(CombatStateMachineDefine.Fsm.Task task)
		{
			this.MontageNames = task.TaskRandomMontage.MontageNames.ToArray();
			this.HideOnLoading = task.TaskRandomMontage.HideOnLoading;
			this.BlendInTime = task.TaskRandomMontage.BlendInTime * 0.001f;
			this.RandomByClient = task.TaskRandomMontage.RandomByClient;
			return true;
		}

		// Token: 0x060460E2 RID: 286946 RVA: 0x012664CC File Offset: 0x012646CC
		public override void OnEnter(long? contextId = null)
		{
			if (this.Node.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"]))
			{
				this.Node.TaskFinished = true;
				return;
			}
			this.Node.SkillComponent.StopGroup1Skill("AiStateMachineTaskRandomMontage.OnEnter");
			this.Node.TaskFinished = false;
			this.Loading = true;
			this.Playing = false;
			this.MontageIndex = (this.RandomByClient ? new int?(Random.Shared.Next(this.MontageNames.Length)) : this.Node.Owner.GetBlackboard(CombatStateMachineDefine.Fsm.EFsmSyncKey.RandomMontageIndex));
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.StateMachineNew;
			Entity entity = this.Node.Entity;
			string message = "随机Montage";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MontageIndex", this.MontageIndex);
			instance.Info(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (this.MontageIndex != null)
			{
				int? montageIndex = this.MontageIndex;
				int num = 0;
				if (!(montageIndex.GetValueOrDefault() < num & montageIndex != null))
				{
					montageIndex = this.MontageIndex;
					num = this.MontageNames.Length;
					if (!(montageIndex.GetValueOrDefault() >= num & montageIndex != null))
					{
						goto IL_16C;
					}
				}
			}
			CombatLog instance2 = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.StateMachineNew;
			Entity entity2 = this.Node.Entity;
			string message2 = "播放随机Montage失败，MontageIndex非法";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("MontageIndex", this.MontageIndex);
			instance2.Error(flag2, entity2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.MontageIndex = new int?(0);
			IL_16C:
			CharacterMontageComponent montageComponent = this.Node.MontageComponent;
			if (this.MontageHandle == null)
			{
				if (this.HideOnLoading && this.DisableHandle == null)
				{
					this.DisableHandle = new int?(this.Node.ActorComponent.DisableActor("状态机加载动作"));
				}
				for (int i = 0; i < this.MontageNames.Length; i++)
				{
					int num2 = (this.MontageIndex.Value + i) % this.MontageNames.Length;
					string montageName = this.MontageNames[num2];
					this.MontageHandle = montageComponent.CreateTaskWithName(montageName, new Action(this.OnLoadCompleted), new Action<bool>(this.OnMontageEnd), this.BlendInTime);
					if (this.MontageHandle != null)
					{
						montageComponent.SetMontageTaskRemainCb(this.MontageHandle.Value, new Action<float>(this.OnMontageRemain));
						break;
					}
				}
			}
			if (this.MontageHandle != null)
			{
				this.Playing = true;
				montageComponent.PlayMontageTaskWhenReady(this.MontageHandle.Value, (float)((double)this.Node.ElapseTime * Singleton<TimeUtil>.Instance.Millisecond), new long?(contextId.Value), this.RemainedTrigger);
				return;
			}
			this.Node.TaskFinished = true;
		}

		// Token: 0x060460E3 RID: 286947 RVA: 0x01266790 File Offset: 0x01264990
		public override void OnExit(long? contextId = null)
		{
			if (this.HideOnLoading && this.Loading && this.DisableHandle != null)
			{
				this.Node.ActorComponent.EnableActor(this.DisableHandle.Value);
				this.DisableHandle = null;
			}
			this.Node.MontageComponent.EndMontageTask(this.MontageHandle.GetValueOrDefault());
			this.MontageHandle = null;
			this.Node.TaskFinished = false;
			this.Playing = false;
		}

		// Token: 0x060460E4 RID: 286948 RVA: 0x0126681C File Offset: 0x01264A1C
		protected override void OnTick(float deltaSeconds, long? contextId = null)
		{
			if (this.MontageHandle != null)
			{
				this.Node.MontageComponent.GetMontageTimeRemaining(this.MontageHandle.Value);
			}
		}

		// Token: 0x060460E5 RID: 286949 RVA: 0x01266847 File Offset: 0x01264A47
		protected override void OnClear()
		{
			if (this.MontageHandle != null)
			{
				this.Node.MontageComponent.EndMontageTask(this.MontageHandle.Value);
			}
			this.MontageHandle = null;
		}

		// Token: 0x060460E6 RID: 286950 RVA: 0x01266880 File Offset: 0x01264A80
		private void OnLoadCompleted()
		{
			this.Loading = false;
			if (!this.Node.Activated)
			{
				return;
			}
			if (this.HideOnLoading && this.DisableHandle != null)
			{
				this.Node.ActorComponent.EnableActor(this.DisableHandle.Value);
				this.DisableHandle = null;
			}
			this.Node.MoveComponent.SetForceSpeed(Vector.ZeroVectorProxy);
		}

		// Token: 0x060460E7 RID: 286951 RVA: 0x012668F4 File Offset: 0x01264AF4
		private void OnMontageEnd(bool isInterrupted)
		{
			this.Node.TaskFinished = true;
		}

		// Token: 0x060460E8 RID: 286952 RVA: 0x01266904 File Offset: 0x01264B04
		private unsafe void OnMontageRemain(float remainTime)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.StateMachine;
			ELogAuthor author = ELogAuthor.PZ;
			string message = "Random Montage Task OnMontageRemain";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("montage", this.GetNameByCurrentHandle());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("remain time", remainTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("remained trigger", this.RemainedTrigger);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			Singleton<EventSystem>.Instance.EmitWithTarget<float>(this, EEventName.OnMontageRemain, remainTime);
		}

		// Token: 0x060460E9 RID: 286953 RVA: 0x012669A2 File Offset: 0x01264BA2
		public double GetTimeRemaining()
		{
			return (double)((this.MontageHandle != null) ? this.Node.MontageComponent.GetMontageTimeRemaining(this.MontageHandle.Value) : -1f);
		}

		// Token: 0x060460EA RID: 286954 RVA: 0x012669D4 File Offset: 0x01264BD4
		public double GetTimeElapsing()
		{
			return (double)((this.MontageHandle != null) ? this.Node.MontageComponent.GetMontageTimeElapsing(this.MontageHandle.Value) : -1f);
		}

		// Token: 0x060460EB RID: 286955 RVA: 0x01266A06 File Offset: 0x01264C06
		public double GetTimeLength()
		{
			return (double)((this.MontageHandle != null) ? this.Node.MontageComponent.GetMontageTimeLength(this.MontageHandle.Value) : -1f);
		}

		// Token: 0x060460EC RID: 286956 RVA: 0x01266A38 File Offset: 0x01264C38
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x060460ED RID: 286957 RVA: 0x01266A41 File Offset: 0x01264C41
		[NullableContext(2)]
		private string GetNameByHandle(int handle)
		{
			return this.Node.MontageComponent.GetMontageTaskNameByHandle(handle);
		}

		// Token: 0x060460EE RID: 286958 RVA: 0x01266A54 File Offset: 0x01264C54
		[NullableContext(2)]
		public string GetNameByCurrentHandle()
		{
			if (this.MontageHandle != null)
			{
				return this.GetNameByHandle(this.MontageHandle.Value);
			}
			return null;
		}

		// Token: 0x040274CF RID: 160975
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public string[] MontageNames;

		// Token: 0x040274D0 RID: 160976
		private bool HideOnLoading;

		// Token: 0x040274D1 RID: 160977
		private float BlendInTime;

		// Token: 0x040274D2 RID: 160978
		private int? DisableHandle;

		// Token: 0x040274D3 RID: 160979
		private int? MontageHandle;

		// Token: 0x040274D4 RID: 160980
		public int? MontageIndex;

		// Token: 0x040274D5 RID: 160981
		private bool Loading;

		// Token: 0x040274D8 RID: 160984
		public bool RandomByClient;
	}
}
