using System;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Utils.CombatStateMachine;
using UnrealEngine;

namespace CSharpScript.Game.AI.StateMachine.Task
{
	// Token: 0x020070D9 RID: 28889
	[NullableContext(1)]
	[Nullable(0)]
	public class AiStateMachineTaskMontage : AiStateMachineTask, IAiTaskMontage
	{
		// Token: 0x1700A5E9 RID: 42473
		// (get) Token: 0x060460B2 RID: 286898 RVA: 0x01264E92 File Offset: 0x01263092
		// (set) Token: 0x060460B3 RID: 286899 RVA: 0x01264E9A File Offset: 0x0126309A
		public bool Playing { get; set; }

		// Token: 0x1700A5EA RID: 42474
		// (get) Token: 0x060460B4 RID: 286900 RVA: 0x01264EA3 File Offset: 0x012630A3
		// (set) Token: 0x060460B5 RID: 286901 RVA: 0x01264EAB File Offset: 0x012630AB
		public float RemainedTrigger { get; set; } = -1f;

		// Token: 0x060460B6 RID: 286902 RVA: 0x01264EB4 File Offset: 0x012630B4
		public AiStateMachineTaskMontage(AiStateMachineBase stateMachineNode, CombatStateMachineDefine.Fsm.Task state) : base(stateMachineNode, state)
		{
		}

		// Token: 0x1700A5EB RID: 42475
		// (get) Token: 0x060460B7 RID: 286903 RVA: 0x01264EF1 File Offset: 0x012630F1
		public bool HasResource
		{
			get
			{
				return this.MontageHandle != null || this.Node.TaskFinished;
			}
		}

		// Token: 0x060460B8 RID: 286904 RVA: 0x01264F10 File Offset: 0x01263110
		protected unsafe override bool OnInit(CombatStateMachineDefine.Fsm.Task task)
		{
			AiStateMachineBase node = this.Node;
			if (((node != null) ? node.MontageComponent : null) == null)
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.StateMachineNew;
				AiStateMachineBase node2 = this.Node;
				Entity entity = (node2 != null) ? node2.Entity : null;
				string message = "注册蒙太奇到ForcePushMontageSet失败，Node或Node的蒙太奇组件不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MontageName", this.MontageName);
				instance.Error(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			if (task.TaskMontage != null)
			{
				this.MontageName = task.TaskMontage.MontageName;
				this.HideOnLoading = task.TaskMontage.HideOnLoading;
				this.BlendInTime = task.TaskMontage.BlendInTime * 0.001f;
				this.ForcePush2Server = task.TaskMontage.ForcePush2Server;
				this.ConfigReplaceTagId = task.TaskMontage.ConfigReplaceTagId;
				this.ConfigReplaceTagName = task.TaskMontage.ConfigReplaceTagName;
				this.ForcePushRegistered = false;
			}
			if (!string.IsNullOrEmpty(this.ConfigReplaceTagName) && this.ConfigReplaceTagName != "None")
			{
				this.ReplaceConfig = this.Node.FindStateRepPerfConfig(this.ConfigReplaceTagName);
				IStateRepPerfBase replaceConfig = this.ReplaceConfig;
				if (replaceConfig != null && replaceConfig.Type == EStateRepPerfType.MontagePath)
				{
					IStateRepPerfMontagePath stateRepPerfMontagePath = this.ReplaceConfig as IStateRepPerfMontagePath;
					if (!string.IsNullOrEmpty((stateRepPerfMontagePath != null) ? stateRepPerfMontagePath.MontagePath : null))
					{
						string baseFilename = UBlueprintPathsLibrary.GetBaseFilename(stateRepPerfMontagePath.MontagePath, true);
						if (!string.IsNullOrEmpty(baseFilename))
						{
							string montageName = this.MontageName;
							this.MontageName = baseFilename;
							CombatLog instance2 = Singleton<CombatLog>.Instance;
							CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.StateMachineNew;
							AiStateMachineBase node3 = this.Node;
							Entity entity2 = (node3 != null) ? node3.Entity : null;
							string message2 = "MontageTask蒙太奇替换成功";
							<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("原MontageName", montageName);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("新MontageName", baseFilename);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Path", stateRepPerfMontagePath.MontagePath);
							instance2.Info(flag2, entity2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
						}
					}
				}
				else if (this.ReplaceConfig != null)
				{
					CombatLog instance3 = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag3 = CombatLog.EDebugModule.StateMachineNew;
					AiStateMachineBase node4 = this.Node;
					Entity entity3 = (node4 != null) ? node4.Entity : null;
					string message3 = "MontageTask替换配置错误，替换配置不生效";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("节点", this.Node.Name);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ConfigReplaceTagName", this.ConfigReplaceTagName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("配置覆盖Type", this.ReplaceConfig.Type);
					instance3.Error(flag3, entity3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				}
			}
			string montagePathByName = this.Node.MontageComponent.GetMontagePathByName(this.MontageName, true, false);
			if (!string.IsNullOrEmpty(montagePathByName))
			{
				this.MontageHash = UGASBPLibrary.FnvHash(montagePathByName);
			}
			else
			{
				this.MontageHash = -1;
				CombatLog instance4 = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag4 = CombatLog.EDebugModule.StateMachineNew;
				AiStateMachineBase node5 = this.Node;
				Entity entity4 = (node5 != null) ? node5.Entity : null;
				string message4 = "MontageTask获取蒙太奇HashID失败";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("MontageName", this.MontageName);
				instance4.Warn(flag4, entity4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			return true;
		}

		// Token: 0x060460B9 RID: 286905 RVA: 0x01265230 File Offset: 0x01263430
		public unsafe override void OnEnter(long? contextId = null)
		{
			if (this.ForcePush2Server && !this.ForcePushRegistered)
			{
				this.Node.MontageComponent.AddForcePushMontage(this.MontageName);
				this.ForcePushRegistered = true;
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.StateMachineNew;
				AiStateMachineBase node = this.Node;
				Entity entity = (node != null) ? node.Entity : null;
				string message = "注册蒙太奇到ForcePushMontageSet";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MontageName", this.MontageName);
				instance.Info(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			AiStateMachineBase node2 = this.Node;
			if (((node2 != null) ? node2.TagComponent : null) == null)
			{
				return;
			}
			if (this.Node.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"]))
			{
				this.Node.TaskFinished = true;
				return;
			}
			CharacterSkillComponent skillComponent = this.Node.SkillComponent;
			if (skillComponent != null)
			{
				skillComponent.StopGroup1Skill("AiStateMachineTaskMontage.OnEnter");
			}
			this.Node.TaskFinished = false;
			this.Loading = true;
			this.Playing = false;
			this.PredictEndDuration = -1f;
			if (this.MontageHash != -1)
			{
				AiStateMachineGroup owner = this.Node.Owner;
				if (owner.HasValidMontagePredictEndParams() && owner.GetMontagePredictEndHash() == this.MontageHash)
				{
					CombatLog instance2 = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.StateMachineNew;
					AiStateMachineBase node3 = this.Node;
					Entity entity2 = (node3 != null) ? node3.Entity : null;
					string message2 = "MontageTask OnEnter清除残留的先行结束参数";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("montage", this.MontageName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MontageHash", this.MontageHash);
					instance2.Info(flag2, entity2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					owner.ClearMontagePredictEndParams();
				}
			}
			if (this.Node.MontageComponent == null)
			{
				return;
			}
			CharacterMontageComponent montageComponent = this.Node.MontageComponent;
			if (this.MontageHandle == null)
			{
				if (this.HideOnLoading && this.DisableHandle == null)
				{
					this.DisableHandle = new int?(this.Node.ActorComponent.DisableActor("状态机加载动作"));
				}
				this.MontageHandle = montageComponent.CreateTaskWithName(this.MontageName, new Action(this.OnLoadCompleted), new Action<bool>(this.OnMontageEnd), this.BlendInTime);
				if (this.MontageHandle != null)
				{
					montageComponent.SetMontageTaskRemainCb(this.MontageHandle.Value, new Action<float>(this.OnMontageRemain));
				}
			}
			if (this.MontageHandle != null)
			{
				this.Playing = true;
				float num = (float)((double)this.Node.ElapseTime * Singleton<TimeUtil>.Instance.Millisecond);
				float montageTimeLength = montageComponent.GetMontageTimeLength(this.MontageHandle.Value);
				if (montageTimeLength > 0f && num > montageTimeLength)
				{
					num %= montageTimeLength;
				}
				montageComponent.PlayMontageTaskWhenReady(this.MontageHandle.Value, num, new long?(contextId.Value), this.RemainedTrigger);
				return;
			}
			this.Node.TaskFinished = true;
		}

		// Token: 0x060460BA RID: 286906 RVA: 0x01265514 File Offset: 0x01263714
		public unsafe override void OnExit(long? contextId = null)
		{
			if (this.Node != null)
			{
				if (this.Node.ActorComponent != null && this.HideOnLoading && this.Loading && this.DisableHandle != null)
				{
					this.Node.ActorComponent.EnableActor(this.DisableHandle.Value);
					this.DisableHandle = null;
				}
				if (this.MontageHash != -1)
				{
					AiStateMachineGroup owner = this.Node.Owner;
					if (owner.HasValidMontagePredictEndParams() && owner.GetMontagePredictEndHash() == this.MontageHash)
					{
						CombatLog instance = Singleton<CombatLog>.Instance;
						CombatLog.EDebugModule flag = CombatLog.EDebugModule.StateMachineNew;
						AiStateMachineBase node = this.Node;
						Entity entity = (node != null) ? node.Entity : null;
						string message = "MontageTask OnExit清除残留的先行结束参数";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("montage", this.MontageName);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MontageHash", this.MontageHash);
						instance.Info(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						owner.ClearMontagePredictEndParams();
					}
				}
				if (this.Node.MontageComponent != null && this.MontageHandle != null)
				{
					this.Node.MontageComponent.EndMontageTask(this.MontageHandle.Value);
				}
			}
			this.MontageHandle = null;
			this.Node.TaskFinished = false;
			this.Playing = false;
		}

		// Token: 0x060460BB RID: 286907 RVA: 0x0126567C File Offset: 0x0126387C
		protected override void OnTick(float deltaSeconds, long? contextId = null)
		{
			if (this.Node != null && this.Node.MontageComponent != null && this.MontageHandle != null)
			{
				this.Node.MontageComponent.GetMontageTimeRemaining(this.MontageHandle.Value);
			}
			this.CheckPredictEnd(deltaSeconds);
		}

		// Token: 0x060460BC RID: 286908 RVA: 0x012656D0 File Offset: 0x012638D0
		protected override void OnClear()
		{
			if (this.Node != null && this.Node.MontageComponent != null && this.MontageHandle != null)
			{
				this.Node.MontageComponent.EndMontageTask(this.MontageHandle.Value);
			}
			this.MontageHandle = null;
		}

		// Token: 0x060460BD RID: 286909 RVA: 0x01265728 File Offset: 0x01263928
		private void OnLoadCompleted()
		{
			this.Loading = false;
			if (this.Node == null || !this.Node.Activated)
			{
				return;
			}
			if (this.Node.ActorComponent != null && this.HideOnLoading && this.DisableHandle != null)
			{
				this.Node.ActorComponent.EnableActor(this.DisableHandle.Value);
				this.DisableHandle = null;
			}
			CharacterMoveComponent moveComponent = this.Node.MoveComponent;
			if (moveComponent == null)
			{
				return;
			}
			moveComponent.SetForceSpeed(Vector.ZeroVectorProxy);
		}

		// Token: 0x060460BE RID: 286910 RVA: 0x012657B6 File Offset: 0x012639B6
		private void OnMontageEnd(bool isInterrupted)
		{
			this.Node.TaskFinished = true;
			this.MontageHandle = null;
		}

		// Token: 0x060460BF RID: 286911 RVA: 0x012657D0 File Offset: 0x012639D0
		private unsafe void OnMontageRemain(float remainTime)
		{
			CombatLog instance = Singleton<CombatLog>.Instance;
			CombatLog.EDebugModule flag = CombatLog.EDebugModule.StateMachineNew;
			AiStateMachineBase node = this.Node;
			Entity entity = (node != null) ? node.Entity : null;
			string message = "Montage Task OnMontageRemain";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("montage", this.GetNameByCurrentHandle() ?? "");
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("remain time", remainTime);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("remained trigger", this.RemainedTrigger);
			instance.Info(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			Singleton<EventSystem>.Instance.EmitWithTarget<float>(this, EEventName.OnMontageRemain, remainTime);
		}

		// Token: 0x060460C0 RID: 286912 RVA: 0x01265888 File Offset: 0x01263A88
		public double GetTimeRemaining()
		{
			if (this.Node == null || this.Node.MontageComponent == null)
			{
				return -1.0;
			}
			return (double)((this.MontageHandle != null) ? this.Node.MontageComponent.GetMontageTimeRemaining(this.MontageHandle.Value) : -1f);
		}

		// Token: 0x060460C1 RID: 286913 RVA: 0x012658E4 File Offset: 0x01263AE4
		public double GetTimeElapsing()
		{
			if (this.Node == null || this.Node.MontageComponent == null)
			{
				return -1.0;
			}
			return (double)((this.MontageHandle != null) ? this.Node.MontageComponent.GetMontageTimeElapsing(this.MontageHandle.Value) : -1f);
		}

		// Token: 0x060460C2 RID: 286914 RVA: 0x01265940 File Offset: 0x01263B40
		public double GetTimeLength()
		{
			if (this.Node == null || this.Node.MontageComponent == null)
			{
				return -1.0;
			}
			return (double)((this.MontageHandle != null) ? this.Node.MontageComponent.GetMontageTimeLength(this.MontageHandle.Value) : -1f);
		}

		// Token: 0x060460C3 RID: 286915 RVA: 0x0126599C File Offset: 0x01263B9C
		public override void ToString(StringBuilder outBuilder, int depth = 0)
		{
			AiStateMachineHelper.AppendDepthSpace(outBuilder, depth);
		}

		// Token: 0x060460C4 RID: 286916 RVA: 0x012659A5 File Offset: 0x01263BA5
		[NullableContext(2)]
		private string GetNameByHandle(int handle)
		{
			if (this.Node == null || this.Node.MontageComponent == null)
			{
				return null;
			}
			return this.Node.MontageComponent.GetMontageTaskNameByHandle(handle);
		}

		// Token: 0x060460C5 RID: 286917 RVA: 0x012659CF File Offset: 0x01263BCF
		[NullableContext(2)]
		public string GetNameByCurrentHandle()
		{
			if (this.MontageHandle != null)
			{
				return this.GetNameByHandle(this.MontageHandle.Value);
			}
			return null;
		}

		// Token: 0x060460C6 RID: 286918 RVA: 0x012659F4 File Offset: 0x01263BF4
		private unsafe void CheckPredictEnd(float deltaSeconds)
		{
			if (!this.Playing || this.Loading)
			{
				return;
			}
			if (this.PredictEndDuration == -1f && this.MontageHash != -1)
			{
				AiStateMachineGroup owner = this.Node.Owner;
				if (owner.HasValidMontagePredictEndParams() && owner.GetMontagePredictEndHash() == this.MontageHash)
				{
					this.PredictEndDuration = owner.GetMontagePredictEndDuration();
					CombatLog instance = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag = CombatLog.EDebugModule.StateMachineNew;
					AiStateMachineBase node = this.Node;
					Entity entity = (node != null) ? node.Entity : null;
					string message = "MontageTask先行结束时间应用";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("montage", this.MontageName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MontageHash", this.MontageHash);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("duration", this.PredictEndDuration);
					instance.Info(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					owner.ClearMontagePredictEndParams();
				}
			}
			if (this.PredictEndDuration > 0f && this.Node.ElapseTime >= this.PredictEndDuration)
			{
				CombatLog instance2 = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.StateMachineNew;
				AiStateMachineBase node2 = this.Node;
				Entity entity2 = (node2 != null) ? node2.Entity : null;
				string message2 = "MontageTask先行结束时间到，结束蒙太奇";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("montage", this.MontageName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("MontageHash", this.MontageHash);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("elapsed", this.Node.ElapseTime);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("duration", this.PredictEndDuration);
				instance2.Info(flag2, entity2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
				if (this.HideOnLoading && this.Loading && this.DisableHandle != null)
				{
					if (this.Node != null && this.Node.ActorComponent != null)
					{
						this.Node.ActorComponent.EnableActor(this.DisableHandle.Value);
					}
					this.DisableHandle = null;
				}
				if (this.Node != null && this.Node.MontageComponent != null && this.MontageHandle != null)
				{
					this.Node.MontageComponent.EndMontageTask(this.MontageHandle.Value);
				}
				this.OnMontageEnd(true);
			}
		}

		// Token: 0x040274A9 RID: 160937
		private string MontageName = "";

		// Token: 0x040274AA RID: 160938
		private bool HideOnLoading;

		// Token: 0x040274AB RID: 160939
		private float BlendInTime;

		// Token: 0x040274AC RID: 160940
		private bool ForcePush2Server;

		// Token: 0x040274AD RID: 160941
		public int ConfigReplaceTagId;

		// Token: 0x040274AE RID: 160942
		public string ConfigReplaceTagName = "";

		// Token: 0x040274AF RID: 160943
		[Nullable(2)]
		private IStateRepPerfBase ReplaceConfig;

		// Token: 0x040274B0 RID: 160944
		private bool ForcePushRegistered;

		// Token: 0x040274B1 RID: 160945
		private int? DisableHandle;

		// Token: 0x040274B2 RID: 160946
		private int? MontageHandle;

		// Token: 0x040274B3 RID: 160947
		private bool Loading;

		// Token: 0x040274B6 RID: 160950
		private int MontageHash = -1;

		// Token: 0x040274B7 RID: 160951
		private float PredictEndDuration = -1f;
	}
}
