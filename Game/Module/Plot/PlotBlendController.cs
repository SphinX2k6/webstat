using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Plot.Sequence;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x02005350 RID: 21328
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PlotBlendController : ControllerBase<PlotBlendController>
	{
		// Token: 0x06036665 RID: 222821 RVA: 0x00DB741C File Offset: 0x00DB561C
		private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (actionType != InputDistributeDefine.EActionType.Press)
			{
				return;
			}
			if (!this.IsInProtectTime)
			{
				this.EndBlendOutSwitchPose();
			}
		}

		// Token: 0x06036666 RID: 222822 RVA: 0x00DB7430 File Offset: 0x00DB5630
		private void OnInputMoveAxis(string axisName, float axisValue, InputIdentification inputIdentification)
		{
			if (Math.Abs(axisValue) < 0.1f)
			{
				return;
			}
			if (!this.IsInProtectTime)
			{
				this.EndBlendOutSwitchPose();
			}
		}

		// Token: 0x06036667 RID: 222823 RVA: 0x00DB744E File Offset: 0x00DB564E
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x06036668 RID: 222824 RVA: 0x00DB7454 File Offset: 0x00DB5654
		protected override bool OnClear()
		{
			ModelBase<PlotModel>.Instance.IsBlendProcessing = false;
			this.ClearProtectTime();
			this.ClearAnimEndTimer();
			this.CurrentBlendInfo = null;
			this.TriggerSourceId = null;
			this.SetupInfoExecuted = false;
			this.PreloadedAnimationAssets.Clear();
			foreach (KeyValuePair<string, CustomPromise<bool>> keyValuePair in this.PreloadPromises)
			{
				keyValuePair.Value.SetResult(false);
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "[PlotBlend] 取消预加载Promise";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", keyValuePair.Key);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			this.PreloadPromises.Clear();
			return true;
		}

		// Token: 0x06036669 RID: 222825 RVA: 0x00DB751C File Offset: 0x00DB571C
		protected override void OnTick(float delta)
		{
			bool isBlendProcessing = ModelBase<PlotModel>.Instance.IsBlendProcessing;
		}

		// Token: 0x0603666A RID: 222826 RVA: 0x00DB7529 File Offset: 0x00DB5729
		protected override void OnAfterTick(float delta)
		{
		}

		// Token: 0x0603666B RID: 222827 RVA: 0x00DB752C File Offset: 0x00DB572C
		protected override bool OnLeaveLevel()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.YZH, "[PlotBlend] PlotBlendController 离开关卡", default(ReadOnlySpan<ValueTuple<string, object>>));
			ModelBase<PlotModel>.Instance.IsBlendProcessing = false;
			this.ClearProtectTime();
			this.ClearAnimEndTimer();
			this.CurrentBlendInfo = null;
			this.TriggerSourceId = null;
			this.SetupInfoExecuted = false;
			this.PreloadedAnimationAssets.Clear();
			this.PreloadPromises.Clear();
			return true;
		}

		// Token: 0x0603666C RID: 222828 RVA: 0x00DB7598 File Offset: 0x00DB5798
		protected override bool OnChangeMode()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.YZH, "[PlotBlend] PlotBlendController 改变模式", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}

		// Token: 0x0603666D RID: 222829 RVA: 0x00DB75C4 File Offset: 0x00DB57C4
		public void SetupInfo(SetBlendAnim blendInfo, string sourceId)
		{
			this.CurrentBlendInfo = blendInfo;
			this.TriggerSourceId = sourceId;
			this.SetupInfoExecuted = false;
			IBlendAnimTypeBase blendType = blendInfo.BlendType;
			EBlendAnimType type = blendType.Type;
			if (type != EBlendAnimType.StateMachine)
			{
				if (type == EBlendAnimType.AnimSequence)
				{
					this.PreloadAnimSequence(blendType);
					return;
				}
				Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.YZH, "[PlotBlend] SetupInfo: 未知的BlendType", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x0603666E RID: 222830 RVA: 0x00DB7620 File Offset: 0x00DB5820
		private void PreloadAnimSequence(IBlendAnimTypeBase blendType)
		{
			PropertyInfo property = blendType.GetType().GetProperty("AnimSequence");
			if (property == null)
			{
				return;
			}
			string animPath = property.GetValue(blendType) as string;
			if (animPath == null)
			{
				return;
			}
			if (this.PreloadedAnimationAssets.ContainsKey(animPath))
			{
				return;
			}
			if (this.PreloadPromises.ContainsKey(animPath))
			{
				return;
			}
			CustomPromise<bool> preloadPromise = new CustomPromise<bool>();
			this.PreloadPromises.Add(animPath, preloadPromise);
			Singleton<ResourceSystem>.Instance.LoadAsync<UAnimSequence>(animPath, delegate([Nullable(2)] UAnimSequence animAsset, string _)
			{
				if (animAsset != null && animAsset != null)
				{
					this.PreloadedAnimationAssets.Add(animPath, animAsset);
					preloadPromise.SetResult(true);
					return;
				}
				preloadPromise.SetResult(false);
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "[PlotBlend] 动画资源预加载失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", animPath);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}, 100, "js_undefined");
		}

		// Token: 0x0603666F RID: 222831 RVA: 0x00DB76E0 File Offset: 0x00DB58E0
		private void ExecuteStateMachineBlend(WorldEntity entity, CharacterAnimationComponent animComp, EBlendAnimState targetState)
		{
			if (animComp == null)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.YZH, "[PlotBlend] ExecuteStateMachineBlend: animComp不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			CharacterMoveComponent component = entity.GetComponent<CharacterMoveComponent>();
			switch (targetState)
			{
			case EBlendAnimState.CombatIdle:
				animComp.EnterBattleIdle(null);
				return;
			case EBlendAnimState.Fall:
				if (((component != null) ? component.ActorComp : null) != null)
				{
					component.ActorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
					{
						Mode = EMovementMode.MOVE_Falling,
						Context = "[PlotBlendController.ExecuteStateMachineBlend.Fall]"
					});
					return;
				}
				break;
			case EBlendAnimState.Slide:
				if (((component != null) ? component.ActorComp : null) != null)
				{
					component.ActorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
					{
						Mode = EMovementMode.MOVE_Custom,
						CustomMode = 4,
						Context = "[PlotBlendController.ExecuteStateMachineBlend.Slide]"
					});
					CharacterUnifiedStateComponent component2 = entity.GetComponent<CharacterUnifiedStateComponent>();
					if (component2 == null)
					{
						return;
					}
					component2.SetMoveState(ECharMoveState.Slide);
					return;
				}
				break;
			case EBlendAnimState.Run:
				if (((component != null) ? component.MoveController : null) != null && component.ActorComp != null)
				{
					Vector actorLocationProxy = component.ActorComp.ActorLocationProxy;
					Vector actorForwardProxy = component.ActorComp.ActorForwardProxy;
					Vector position = Vector.Create(actorLocationProxy.X + actorForwardProxy.X * 100.0, actorLocationProxy.Y + actorForwardProxy.Y * 100.0, actorLocationProxy.Z + actorForwardProxy.Z * 100.0);
					MoveToPointConfigImpl moveToPointConfigImpl = new MoveToPointConfigImpl();
					moveToPointConfigImpl.Position = position;
					moveToPointConfigImpl.MoveState = new ECharMoveState?(ECharMoveState.Run);
					List<Action<ELevelEventState>> list = new List<Action<ELevelEventState>>();
					list.Add(delegate(ELevelEventState _)
					{
					});
					moveToPointConfigImpl.CallbackList = list;
					MoveToPointConfigImpl moveConfig = moveToPointConfigImpl;
					component.MoveController.NavigateMoveToLocation(moveConfig, null, true, null);
					return;
				}
				break;
			case EBlendAnimState.Walk:
				if (((component != null) ? component.MoveController : null) != null && component.ActorComp != null)
				{
					Vector actorLocationProxy2 = component.ActorComp.ActorLocationProxy;
					Vector actorForwardProxy2 = component.ActorComp.ActorForwardProxy;
					Vector position2 = Vector.Create(actorLocationProxy2.X + actorForwardProxy2.X * 100.0, actorLocationProxy2.Y + actorForwardProxy2.Y * 100.0, actorLocationProxy2.Z + actorForwardProxy2.Z * 100.0);
					CharacterUnifiedStateComponent component3 = entity.GetComponent<CharacterUnifiedStateComponent>();
					if (component3 != null)
					{
						component3.MarkWalkOrRun(true, false, null);
					}
					MoveToPointConfigImpl moveToPointConfigImpl2 = new MoveToPointConfigImpl();
					moveToPointConfigImpl2.Position = position2;
					moveToPointConfigImpl2.MoveState = new ECharMoveState?(ECharMoveState.Walk);
					List<Action<ELevelEventState>> list2 = new List<Action<ELevelEventState>>();
					list2.Add(delegate(ELevelEventState _)
					{
					});
					moveToPointConfigImpl2.CallbackList = list2;
					MoveToPointConfigImpl moveConfig2 = moveToPointConfigImpl2;
					component.MoveController.NavigateMoveToLocation(moveConfig2, null, true, null);
					return;
				}
				break;
			default:
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "[PlotBlend] ExecuteStateMachineBlend: 未知的状态";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("state", targetState);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				break;
			}
			}
		}

		// Token: 0x06036670 RID: 222832 RVA: 0x00DB79F4 File Offset: 0x00DB5BF4
		private void ExecuteAnimSequenceBlend(UAnimInstance animInstance, IBlendAnimTypeBase blendType)
		{
			string animSequence = ((ISetAnimSequenceBlendAnimType)blendType).AnimSequence;
			if (string.IsNullOrEmpty(animSequence))
			{
				return;
			}
			UAnimSequence uanimSequence;
			this.PreloadedAnimationAssets.TryGetValue(animSequence, out uanimSequence);
			if (uanimSequence == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "[PlotBlend] ExecuteAnimSequenceBlend: 动画资源未预加载";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", animSequence);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (animInstance == null)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.YZH, "[PlotBlend] ExecuteAnimSequenceBlend: AnimInstance不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (animInstance != null)
			{
				animInstance.PlaySlotAnimation(uanimSequence, SequenceDefine.DEFAULT_SEQ_SLOT, 0.1f, 0.25f, 1f, 1);
			}
			float num = uanimSequence.SequenceLength + 0.1f;
			if (this.AnimEndTimerHandle != null)
			{
				TimerSystem.Instance.Remove(this.AnimEndTimerHandle);
			}
			this.AnimEndTimerHandle = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.EndBlendOutSwitchPose();
			}, (float)((int)(num * 1000f)), null, null, true, 1f);
			float? protectTime = ((ISetAnimSequenceBlendAnimType)blendType).ProtectTime;
			float? num2 = protectTime;
			float num3 = 0f;
			if (num2.GetValueOrDefault() > num3 & num2 != null)
			{
				this.IsInProtectTime = true;
				this.ProtectTimeTimerHandle = TimerSystem.Instance.Delay(delegate(float _)
				{
					this.IsInProtectTime = false;
					this.ProtectTimeTimerHandle = null;
				}, (float)((int)(protectTime * (float)1000).Value), null, null, true, 1f);
			}
			else
			{
				this.IsInProtectTime = false;
			}
			this.BindInputActions(null);
			this.BindInputAxes(null);
		}

		// Token: 0x06036671 RID: 222833 RVA: 0x00DB7B8C File Offset: 0x00DB5D8C
		[NullableContext(0)]
		public UniTask<bool> TryExecuteBlend([Nullable(2)] string sourceId)
		{
			PlotBlendController.<TryExecuteBlend>d__24 <TryExecuteBlend>d__;
			<TryExecuteBlend>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TryExecuteBlend>d__.<>4__this = this;
			<TryExecuteBlend>d__.sourceId = sourceId;
			<TryExecuteBlend>d__.<>1__state = -1;
			<TryExecuteBlend>d__.<>t__builder.Start<PlotBlendController.<TryExecuteBlend>d__24>(ref <TryExecuteBlend>d__);
			return <TryExecuteBlend>d__.<>t__builder.Task;
		}

		// Token: 0x06036672 RID: 222834 RVA: 0x00DB7BD8 File Offset: 0x00DB5DD8
		public void EndBlendOutSwitchPose()
		{
			if (!ModelBase<PlotModel>.Instance.IsBlendProcessing)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.YZH, "[PlotBlend] 没有正在进行的BlendOut操作", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.UnBindInputActions(null);
			this.UnBindInputAxes(null);
			Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.YZH, "[PlotBlend] 结束BlendOut姿势切换", default(ReadOnlySpan<ValueTuple<string, object>>));
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			WorldEntity worldEntity = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
			if (worldEntity == null)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.YZH, "[PlotBlend] EndBlendOutSwitchPose: 当前角色不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			CharacterAnimationComponent component = worldEntity.GetComponent<CharacterAnimationComponent>();
			UAnimInstance uanimInstance = (component != null) ? component.MainAnimInstance : null;
			if (uanimInstance == null)
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.Plot, ELogAuthor.YZH, "[PlotBlend] EndBlendOutSwitchPose: animInstance不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			uanimInstance.StopSlotAnimation(0.1f, SequenceDefine.DEFAULT_SEQ_SLOT);
			this.ClearProtectTime();
			this.ClearAnimEndTimer();
			ModelBase<PlotModel>.Instance.IsBlendProcessing = false;
		}

		// Token: 0x06036673 RID: 222835 RVA: 0x00DB7CC5 File Offset: 0x00DB5EC5
		private void ClearProtectTime()
		{
			if (this.ProtectTimeTimerHandle != null)
			{
				TimerSystem.Instance.Remove(this.ProtectTimeTimerHandle);
				this.ProtectTimeTimerHandle = null;
			}
			this.IsInProtectTime = false;
		}

		// Token: 0x06036674 RID: 222836 RVA: 0x00DB7CEE File Offset: 0x00DB5EEE
		private void ClearAnimEndTimer()
		{
			if (this.AnimEndTimerHandle != null)
			{
				TimerSystem.Instance.Remove(this.AnimEndTimerHandle);
				this.AnimEndTimerHandle = null;
			}
		}

		// Token: 0x06036675 RID: 222837 RVA: 0x00DB7D10 File Offset: 0x00DB5F10
		private void ClearBlendData()
		{
			this.CurrentBlendInfo = null;
			this.TriggerSourceId = null;
			this.SetupInfoExecuted = false;
			this.PreloadedAnimationAssets.Clear();
			foreach (KeyValuePair<string, CustomPromise<bool>> keyValuePair in this.PreloadPromises)
			{
				keyValuePair.Value.SetResult(false);
			}
			this.PreloadPromises.Clear();
		}

		// Token: 0x17008D66 RID: 36198
		// (get) Token: 0x06036676 RID: 222838 RVA: 0x00DB7D94 File Offset: 0x00DB5F94
		public bool HasBlendInfo
		{
			get
			{
				return this.CurrentBlendInfo != null;
			}
		}

		// Token: 0x17008D67 RID: 36199
		// (get) Token: 0x06036677 RID: 222839 RVA: 0x00DB7D9F File Offset: 0x00DB5F9F
		public bool HasUnexecutedBlendInfo
		{
			get
			{
				return this.HasBlendInfo && !this.SetupInfoExecuted;
			}
		}

		// Token: 0x06036678 RID: 222840 RVA: 0x00DB7DB4 File Offset: 0x00DB5FB4
		public bool IsAnimationPreloaded(string animPath)
		{
			return this.PreloadedAnimationAssets.ContainsKey(animPath);
		}

		// Token: 0x06036679 RID: 222841 RVA: 0x00DB7DC4 File Offset: 0x00DB5FC4
		[NullableContext(0)]
		public UniTask<bool> WaitForAnimationPreload([Nullable(1)] string animPath)
		{
			PlotBlendController.<WaitForAnimationPreload>d__34 <WaitForAnimationPreload>d__;
			<WaitForAnimationPreload>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<WaitForAnimationPreload>d__.<>4__this = this;
			<WaitForAnimationPreload>d__.animPath = animPath;
			<WaitForAnimationPreload>d__.<>1__state = -1;
			<WaitForAnimationPreload>d__.<>t__builder.Start<PlotBlendController.<WaitForAnimationPreload>d__34>(ref <WaitForAnimationPreload>d__);
			return <WaitForAnimationPreload>d__.<>t__builder.Task;
		}

		// Token: 0x0603667A RID: 222842 RVA: 0x00DB7E0F File Offset: 0x00DB600F
		[NullableContext(2)]
		public SetBlendAnim GetCurrentBlendInfo()
		{
			return this.CurrentBlendInfo;
		}

		// Token: 0x0603667B RID: 222843 RVA: 0x00DB7E18 File Offset: 0x00DB6018
		public void ClearBlendInfo()
		{
			this.CurrentBlendInfo = null;
			this.TriggerSourceId = null;
			this.SetupInfoExecuted = false;
			Singleton<global::Log>.Instance.Info(ELogModule.Plot, ELogAuthor.YZH, "[PlotBlend] 手动清理Blend信息", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0603667C RID: 222844 RVA: 0x00DB7E58 File Offset: 0x00DB6058
		public void BindInputActions([Nullable(new byte[]
		{
			2,
			1
		})] string[] actionNames = null)
		{
			string[] array = actionNames ?? this.blendMonitorActions;
			if (array == null || array.Length == 0)
			{
				return;
			}
			ControllerBase<InputDistributeController>.Instance.BindActions(array, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
		}

		// Token: 0x0603667D RID: 222845 RVA: 0x00DB7E90 File Offset: 0x00DB6090
		public void UnBindInputActions([Nullable(new byte[]
		{
			2,
			1
		})] string[] actionNames = null)
		{
			string[] array = actionNames ?? this.blendMonitorActions;
			if (array == null || array.Length == 0)
			{
				return;
			}
			ControllerBase<InputDistributeController>.Instance.UnBindActions(array, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
		}

		// Token: 0x0603667E RID: 222846 RVA: 0x00DB7EC8 File Offset: 0x00DB60C8
		public void BindInputAxes([Nullable(new byte[]
		{
			2,
			1
		})] string[] axisNames = null)
		{
			string[] array = axisNames ?? this.blendMonitorAxes;
			if (array == null || array.Length == 0)
			{
				return;
			}
			ControllerBase<InputDistributeController>.Instance.BindAxes(array, new TInputHandle<float>(this.OnInputMoveAxis));
		}

		// Token: 0x0603667F RID: 222847 RVA: 0x00DB7F00 File Offset: 0x00DB6100
		public void UnBindInputAxes([Nullable(new byte[]
		{
			2,
			1
		})] string[] axisNames = null)
		{
			string[] array = axisNames ?? this.blendMonitorAxes;
			if (array == null || array.Length == 0)
			{
				return;
			}
			ControllerBase<InputDistributeController>.Instance.UnBindAxes(array, new TInputHandle<float>(this.OnInputMoveAxis));
		}

		// Token: 0x0401F485 RID: 128133
		private const float BLEND_IN = 0.1f;

		// Token: 0x0401F486 RID: 128134
		private const float BLEND_OUT = 0.1f;

		// Token: 0x0401F487 RID: 128135
		private readonly string[] blendMonitorActions = new string[]
		{
			"跳跃",
			"攀爬",
			"走跑切换",
			"闪避",
			"下降",
			"攻击",
			"技能1",
			"幻象1",
			"大招",
			"幻象2",
			"切换角色1",
			"切换角色2",
			"切换角色3",
			"切换角色4",
			"通用交互",
			"切换交互",
			"环境特性",
			"锁定目标",
			"瞄准"
		};

		// Token: 0x0401F488 RID: 128136
		private readonly string[] blendMonitorAxes = new string[]
		{
			"MoveForward",
			"MoveRight"
		};

		// Token: 0x0401F489 RID: 128137
		[Nullable(2)]
		private SetBlendAnim CurrentBlendInfo;

		// Token: 0x0401F48A RID: 128138
		private bool SetupInfoExecuted;

		// Token: 0x0401F48B RID: 128139
		[Nullable(2)]
		private string TriggerSourceId;

		// Token: 0x0401F48C RID: 128140
		private readonly Dictionary<string, UAnimSequence> PreloadedAnimationAssets = new Dictionary<string, UAnimSequence>();

		// Token: 0x0401F48D RID: 128141
		private readonly Dictionary<string, CustomPromise<bool>> PreloadPromises = new Dictionary<string, CustomPromise<bool>>();

		// Token: 0x0401F48E RID: 128142
		private bool IsInProtectTime;

		// Token: 0x0401F48F RID: 128143
		[Nullable(2)]
		private TimerHandle ProtectTimeTimerHandle;

		// Token: 0x0401F490 RID: 128144
		[Nullable(2)]
		private TimerHandle AnimEndTimerHandle;
	}
}
