using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using CSharpScript.Game.Module.WuwaGo.Controller.Role;
using CSharpScript.Game.Module.WuwaGo.Model;
using CSharpScript.Game.Module.WuwaGo.Model.Role;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Round
{
	// Token: 0x02004AC6 RID: 19142
	[NullableContext(1)]
	[Nullable(0)]
	public class RoundManager : IStaticVariableResetter
	{
		// Token: 0x06031E74 RID: 204404 RVA: 0x00C7CF9B File Offset: 0x00C7B19B
		static RoundManager()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(RoundManager.CreateStaticDefaultValue), new Action(RoundManager.ResetStaticDefaultValue));
		}

		// Token: 0x06031E75 RID: 204405 RVA: 0x00C7CFBC File Offset: 0x00C7B1BC
		public static void CreateStaticDefaultValue()
		{
			List<RoundManager.RoundSequenceNode> list = new List<RoundManager.RoundSequenceNode>();
			list.Add(new RoundManager.RoundSequenceNode(ERoundStep.SpikeTrap, "Normal", null));
			list.Add(new RoundManager.RoundSequenceNode(ERoundStep.PressureTrigger, "Normal", null));
			list.Add(new RoundManager.RoundSequenceNode(ERoundStep.MovableFloor, "Normal", null));
			list.Add(new RoundManager.RoundSequenceNode(ERoundStep.MonsterAction, "Normal", null));
			list.Add(new RoundManager.RoundSequenceNode(ERoundStep.SpikeTrap, "PostMoveMonster", (RoundManager manager) => manager.HasMoveMonsterActed));
			list.Add(new RoundManager.RoundSequenceNode(ERoundStep.PressureTrigger, "PostMoveMonster", (RoundManager manager) => manager.HasMoveMonsterActed));
			list.Add(new RoundManager.RoundSequenceNode(ERoundStep.MovableFloor, "PostMoveMonster", (RoundManager manager) => manager.HasMoveMonsterActed));
			list.Add(new RoundManager.RoundSequenceNode(ERoundStep.GearTrap, "Normal", null));
			list.Add(new RoundManager.RoundSequenceNode(ERoundStep.BowTrap, "Normal", null));
			RoundManager._resolutionSequence = list;
		}

		// Token: 0x06031E76 RID: 204406 RVA: 0x00C7D0CF File Offset: 0x00C7B2CF
		public static void ResetStaticDefaultValue()
		{
			RoundManager._resolutionSequence = null;
		}

		// Token: 0x17008518 RID: 34072
		// (get) Token: 0x06031E77 RID: 204407 RVA: 0x00C7D0D8 File Offset: 0x00C7B2D8
		[Nullable(2)]
		public WuWaGoRoleController CurProcessUnit
		{
			[NullableContext(2)]
			get
			{
				WuWaGoRoleController wuWaGoRoleController = this.CurProcess as WuWaGoRoleController;
				if (wuWaGoRoleController == null)
				{
					return null;
				}
				return wuWaGoRoleController;
			}
		}

		// Token: 0x17008519 RID: 34073
		// (get) Token: 0x06031E78 RID: 204408 RVA: 0x00C7D0F7 File Offset: 0x00C7B2F7
		// (set) Token: 0x06031E79 RID: 204409 RVA: 0x00C7D0FF File Offset: 0x00C7B2FF
		public bool IsBusy { get; private set; }

		// Token: 0x1700851A RID: 34074
		// (get) Token: 0x06031E7A RID: 204410 RVA: 0x00C7D108 File Offset: 0x00C7B308
		// (set) Token: 0x06031E7B RID: 204411 RVA: 0x00C7D110 File Offset: 0x00C7B310
		public ERoundStep? CurrentStep { get; private set; }

		// Token: 0x1700851B RID: 34075
		// (get) Token: 0x06031E7C RID: 204412 RVA: 0x00C7D119 File Offset: 0x00C7B319
		// (set) Token: 0x06031E7D RID: 204413 RVA: 0x00C7D121 File Offset: 0x00C7B321
		[Nullable(2)]
		public string CurrentProcessDebugName { [NullableContext(2)] get; [NullableContext(2)] private set; }

		// Token: 0x06031E7E RID: 204414 RVA: 0x00C7D12C File Offset: 0x00C7B32C
		public void Init(WuWaGoGameData gameData, IWuWaGoGridMutationService gridMutationService, [Nullable(new byte[]
		{
			2,
			1
		})] Func<IWuWaGoMovableFloorBatchResult, UniTask> onMovableFloorBatchFinished = null)
		{
			RoundManager.<>c__DisplayClass26_0 CS$<>8__locals1 = new RoundManager.<>c__DisplayClass26_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.onMovableFloorBatchFinished = onMovableFloorBatchFinished;
			this.GameData = gameData;
			this.ExecutionToken++;
			GearAndBowTrapRoundStepExecutor value = new GearAndBowTrapRoundStepExecutor((ERoundStep step) => CS$<>8__locals1.<>4__this.StepUnits.GetValueOrDefault(step), () => CS$<>8__locals1.<>4__this.ExecutionToken, new Action<IExecutableUnit, string>(this.SetCurrentProcess));
			this.DefaultStepExecutor = new SequentialRoundStepExecutor((ERoundStep step) => CS$<>8__locals1.<>4__this.StepUnits.GetValueOrDefault(step), () => CS$<>8__locals1.<>4__this.ExecutionToken, new Action<IExecutableUnit, string>(this.SetCurrentProcess), new Func<int, bool>(this.ShouldAbortRound));
			this.StepExecutors.Clear();
			this.StepExecutors[ERoundStep.MovableFloor] = new MovableFloorRoundStepExecutor(gridMutationService, () => CS$<>8__locals1.<>4__this.ExecutionToken, new Action<IExecutableUnit, string>(this.SetCurrentProcess), delegate(IWuWaGoMovableFloorBatchResult result, int movableFloorExecutionToken)
			{
				RoundManager.<>c__DisplayClass26_0.<<Init>b__5>d <<Init>b__5>d;
				<<Init>b__5>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<Init>b__5>d.<>4__this = CS$<>8__locals1;
				<<Init>b__5>d.result = result;
				<<Init>b__5>d.movableFloorExecutionToken = movableFloorExecutionToken;
				<<Init>b__5>d.<>1__state = -1;
				<<Init>b__5>d.<>t__builder.Start<RoundManager.<>c__DisplayClass26_0.<<Init>b__5>d>(ref <<Init>b__5>d);
				return <<Init>b__5>d.<>t__builder.Task;
			});
			this.StepExecutors[ERoundStep.GearTrap] = value;
			this.StepExecutors[ERoundStep.BowTrap] = value;
		}

		// Token: 0x06031E7F RID: 204415 RVA: 0x00C7D224 File Offset: 0x00C7B424
		public void RegisterUnit(ERoundStep step, IExecutableUnit unit)
		{
			List<IExecutableUnit> list;
			if (this.StepUnits.TryGetValue(step, out list))
			{
				list.Add(unit);
			}
		}

		// Token: 0x06031E80 RID: 204416 RVA: 0x00C7D248 File Offset: 0x00C7B448
		public void Clear()
		{
			this.ExecutionToken++;
			foreach (KeyValuePair<ERoundStep, List<IExecutableUnit>> keyValuePair in this.StepUnits)
			{
				ERoundStep eroundStep;
				List<IExecutableUnit> list;
				keyValuePair.Deconstruct(out eroundStep, out list);
				list.Clear();
			}
			this.IsBusy = false;
			this.CurProcess = null;
			this.CurrentStep = null;
			this.CurrentProcessDebugName = null;
			this.HasMoveMonsterActed = false;
		}

		// Token: 0x06031E81 RID: 204417 RVA: 0x00C7D2E0 File Offset: 0x00C7B4E0
		public void ResetForRollback()
		{
			this.ExecutionToken++;
			this.IsBusy = false;
			this.CurProcess = null;
			this.CurrentStep = null;
			this.CurrentProcessDebugName = null;
			this.HasMoveMonsterActed = false;
		}

		// Token: 0x06031E82 RID: 204418 RVA: 0x00C7D328 File Offset: 0x00C7B528
		public unsafe void RemoveController(WuWaGoRoleController controller)
		{
			ERoundStep eroundStep = controller.BaseRole.IsMonster ? ERoundStep.MonsterAction : ERoundStep.PlayerAction;
			List<IExecutableUnit> list;
			if (!this.StepUnits.TryGetValue(eroundStep, out list))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.WuWaGo;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "尝试移除未注册步骤的 Controller";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("controllerId", controller.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("step", eroundStep);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			int num = list.IndexOf(controller);
			if (num >= 0)
			{
				list.RemoveAt(num);
			}
		}

		// Token: 0x06031E83 RID: 204419 RVA: 0x00C7D3D0 File Offset: 0x00C7B5D0
		public void Tick(float delta)
		{
			if (!this.IsBusy)
			{
				this.EnterNextRound();
			}
		}

		// Token: 0x06031E84 RID: 204420 RVA: 0x00C7D3E0 File Offset: 0x00C7B5E0
		public void EnterNextRound()
		{
			this.GameData.Round++;
			this.IsBusy = true;
			this.HasMoveMonsterActed = false;
			int num = this.ExecutionToken + 1;
			this.ExecutionToken = num;
			int executionToken = num;
			this.ProcessCurrentRound(executionToken).Forget();
		}

		// Token: 0x06031E85 RID: 204421 RVA: 0x00C7D42C File Offset: 0x00C7B62C
		private UniTask ProcessCurrentRound(int executionToken)
		{
			RoundManager.<ProcessCurrentRound>d__33 <ProcessCurrentRound>d__;
			<ProcessCurrentRound>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ProcessCurrentRound>d__.<>4__this = this;
			<ProcessCurrentRound>d__.executionToken = executionToken;
			<ProcessCurrentRound>d__.<>1__state = -1;
			<ProcessCurrentRound>d__.<>t__builder.Start<RoundManager.<ProcessCurrentRound>d__33>(ref <ProcessCurrentRound>d__);
			return <ProcessCurrentRound>d__.<>t__builder.Task;
		}

		// Token: 0x06031E86 RID: 204422 RVA: 0x00C7D478 File Offset: 0x00C7B678
		private UniTask ProcessPlayerPhase(int executionToken)
		{
			RoundManager.<ProcessPlayerPhase>d__34 <ProcessPlayerPhase>d__;
			<ProcessPlayerPhase>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ProcessPlayerPhase>d__.<>4__this = this;
			<ProcessPlayerPhase>d__.executionToken = executionToken;
			<ProcessPlayerPhase>d__.<>1__state = -1;
			<ProcessPlayerPhase>d__.<>t__builder.Start<RoundManager.<ProcessPlayerPhase>d__34>(ref <ProcessPlayerPhase>d__);
			return <ProcessPlayerPhase>d__.<>t__builder.Task;
		}

		// Token: 0x06031E87 RID: 204423 RVA: 0x00C7D4C4 File Offset: 0x00C7B6C4
		private UniTask ProcessResolutionPhase(int executionToken)
		{
			RoundManager.<ProcessResolutionPhase>d__35 <ProcessResolutionPhase>d__;
			<ProcessResolutionPhase>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ProcessResolutionPhase>d__.<>4__this = this;
			<ProcessResolutionPhase>d__.executionToken = executionToken;
			<ProcessResolutionPhase>d__.<>1__state = -1;
			<ProcessResolutionPhase>d__.<>t__builder.Start<RoundManager.<ProcessResolutionPhase>d__35>(ref <ProcessResolutionPhase>d__);
			return <ProcessResolutionPhase>d__.<>t__builder.Task;
		}

		// Token: 0x06031E88 RID: 204424 RVA: 0x00C7D510 File Offset: 0x00C7B710
		public UniTask RunResolutionPhaseAsync()
		{
			RoundManager.<RunResolutionPhaseAsync>d__36 <RunResolutionPhaseAsync>d__;
			<RunResolutionPhaseAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunResolutionPhaseAsync>d__.<>4__this = this;
			<RunResolutionPhaseAsync>d__.<>1__state = -1;
			<RunResolutionPhaseAsync>d__.<>t__builder.Start<RoundManager.<RunResolutionPhaseAsync>d__36>(ref <RunResolutionPhaseAsync>d__);
			return <RunResolutionPhaseAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031E89 RID: 204425 RVA: 0x00C7D554 File Offset: 0x00C7B754
		private UniTask ProcessSequence(IReadOnlyList<RoundManager.RoundSequenceNode> sequence, int executionToken)
		{
			RoundManager.<ProcessSequence>d__37 <ProcessSequence>d__;
			<ProcessSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ProcessSequence>d__.<>4__this = this;
			<ProcessSequence>d__.sequence = sequence;
			<ProcessSequence>d__.executionToken = executionToken;
			<ProcessSequence>d__.<>1__state = -1;
			<ProcessSequence>d__.<>t__builder.Start<RoundManager.<ProcessSequence>d__37>(ref <ProcessSequence>d__);
			return <ProcessSequence>d__.<>t__builder.Task;
		}

		// Token: 0x06031E8A RID: 204426 RVA: 0x00C7D5A8 File Offset: 0x00C7B7A8
		private UniTask ProcessStep(ERoundStep step, int executionToken)
		{
			RoundManager.<ProcessStep>d__38 <ProcessStep>d__;
			<ProcessStep>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ProcessStep>d__.<>4__this = this;
			<ProcessStep>d__.step = step;
			<ProcessStep>d__.executionToken = executionToken;
			<ProcessStep>d__.<>1__state = -1;
			<ProcessStep>d__.<>t__builder.Start<RoundManager.<ProcessStep>d__38>(ref <ProcessStep>d__);
			return <ProcessStep>d__.<>t__builder.Task;
		}

		// Token: 0x06031E8B RID: 204427 RVA: 0x00C7D5FB File Offset: 0x00C7B7FB
		public bool ShouldAbortCurrentRound()
		{
			return this.ShouldAbortRound(this.ExecutionToken);
		}

		// Token: 0x06031E8C RID: 204428 RVA: 0x00C7D60C File Offset: 0x00C7B80C
		private bool ShouldAbortRound(int executionToken)
		{
			if (this.ExecutionToken != executionToken)
			{
				return true;
			}
			WuWaGoMainControlRole mainControlRole = this.GameData.MainControlRole;
			if (mainControlRole == null)
			{
				return false;
			}
			if (mainControlRole.IsDead)
			{
				return true;
			}
			WuWaGoGrid gridById = this.GameData.GetGridById(mainControlRole.StandGridId);
			return gridById != null && gridById.IsEndPoint;
		}

		// Token: 0x06031E8D RID: 204429 RVA: 0x00C7D65B File Offset: 0x00C7B85B
		public void NotifyMoveMonsterActed()
		{
			this.HasMoveMonsterActed = true;
		}

		// Token: 0x06031E8E RID: 204430 RVA: 0x00C7D664 File Offset: 0x00C7B864
		private IRoundStepExecutor GetStepExecutor(ERoundStep step)
		{
			return this.StepExecutors.GetValueOrDefault(step) ?? this.DefaultStepExecutor;
		}

		// Token: 0x06031E8F RID: 204431 RVA: 0x00C7D67C File Offset: 0x00C7B87C
		[NullableContext(2)]
		private void SetCurrentProcess(IExecutableUnit unit = null, string debugName = null)
		{
			this.CurProcess = unit;
			string currentProcessDebugName = debugName;
			if (debugName == null)
			{
				if (unit == null)
				{
					currentProcessDebugName = null;
				}
				else
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
					defaultInterpolatedStringHandler.AppendFormatted<Enum>(unit.Type);
					defaultInterpolatedStringHandler.AppendLiteral(":");
					defaultInterpolatedStringHandler.AppendFormatted<int>(unit.Id);
					currentProcessDebugName = defaultInterpolatedStringHandler.ToStringAndClear();
				}
			}
			this.CurrentProcessDebugName = currentProcessDebugName;
		}

		// Token: 0x06031E90 RID: 204432 RVA: 0x00C7D6D8 File Offset: 0x00C7B8D8
		public RoundManager()
		{
			Dictionary<ERoundStep, List<IExecutableUnit>> dictionary = new Dictionary<ERoundStep, List<IExecutableUnit>>();
			dictionary[ERoundStep.PlayerAction] = new List<IExecutableUnit>();
			dictionary[ERoundStep.SpikeTrap] = new List<IExecutableUnit>();
			dictionary[ERoundStep.PressureTrigger] = new List<IExecutableUnit>();
			dictionary[ERoundStep.BowTrap] = new List<IExecutableUnit>();
			dictionary[ERoundStep.MovableFloor] = new List<IExecutableUnit>();
			dictionary[ERoundStep.MonsterAction] = new List<IExecutableUnit>();
			dictionary[ERoundStep.GearTrap] = new List<IExecutableUnit>();
			this.StepUnits = dictionary;
			this.StepExecutors = new Dictionary<ERoundStep, IRoundStepExecutor>();
			base..ctor();
		}

		// Token: 0x0401D344 RID: 119620
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static IReadOnlyList<RoundManager.RoundSequenceNode> _resolutionSequence;

		// Token: 0x0401D345 RID: 119621
		protected WuWaGoGameData GameData;

		// Token: 0x0401D346 RID: 119622
		private readonly Dictionary<ERoundStep, List<IExecutableUnit>> StepUnits;

		// Token: 0x0401D347 RID: 119623
		[Nullable(2)]
		private IExecutableUnit CurProcess;

		// Token: 0x0401D348 RID: 119624
		private bool HasMoveMonsterActed;

		// Token: 0x0401D349 RID: 119625
		private int ExecutionToken;

		// Token: 0x0401D34A RID: 119626
		private readonly Dictionary<ERoundStep, IRoundStepExecutor> StepExecutors;

		// Token: 0x0401D34B RID: 119627
		private IRoundStepExecutor DefaultStepExecutor;

		// Token: 0x0200AB33 RID: 43827
		[Nullable(0)]
		private class RoundSequenceNode : IEquatable<RoundManager.RoundSequenceNode>
		{
			// Token: 0x0604BA6D RID: 309869 RVA: 0x01491026 File Offset: 0x0148F226
			public RoundSequenceNode(ERoundStep Step, string PhaseTag, [Nullable(new byte[]
			{
				2,
				1
			})] Func<RoundManager, bool> ShouldExecute = null)
			{
				this.Step = Step;
				this.PhaseTag = PhaseTag;
				this.ShouldExecute = ShouldExecute;
				base..ctor();
			}

			// Token: 0x1700A94C RID: 43340
			// (get) Token: 0x0604BA6E RID: 309870 RVA: 0x01491043 File Offset: 0x0148F243
			[CompilerGenerated]
			protected virtual Type EqualityContract
			{
				[CompilerGenerated]
				get
				{
					return typeof(RoundManager.RoundSequenceNode);
				}
			}

			// Token: 0x1700A94D RID: 43341
			// (get) Token: 0x0604BA6F RID: 309871 RVA: 0x0149104F File Offset: 0x0148F24F
			// (set) Token: 0x0604BA70 RID: 309872 RVA: 0x01491057 File Offset: 0x0148F257
			public ERoundStep Step { get; set; }

			// Token: 0x1700A94E RID: 43342
			// (get) Token: 0x0604BA71 RID: 309873 RVA: 0x01491060 File Offset: 0x0148F260
			// (set) Token: 0x0604BA72 RID: 309874 RVA: 0x01491068 File Offset: 0x0148F268
			public string PhaseTag { get; set; }

			// Token: 0x1700A94F RID: 43343
			// (get) Token: 0x0604BA73 RID: 309875 RVA: 0x01491071 File Offset: 0x0148F271
			// (set) Token: 0x0604BA74 RID: 309876 RVA: 0x01491079 File Offset: 0x0148F279
			[Nullable(new byte[]
			{
				2,
				1
			})]
			public Func<RoundManager, bool> ShouldExecute { [return: Nullable(new byte[]
			{
				2,
				1
			})] get; [param: Nullable(new byte[]
			{
				2,
				1
			})] set; }

			// Token: 0x0604BA75 RID: 309877 RVA: 0x01491084 File Offset: 0x0148F284
			[CompilerGenerated]
			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("RoundSequenceNode");
				stringBuilder.Append(" { ");
				if (this.PrintMembers(stringBuilder))
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append('}');
				return stringBuilder.ToString();
			}

			// Token: 0x0604BA76 RID: 309878 RVA: 0x014910D0 File Offset: 0x0148F2D0
			[CompilerGenerated]
			protected virtual bool PrintMembers(StringBuilder builder)
			{
				RuntimeHelpers.EnsureSufficientExecutionStack();
				builder.Append("Step = ");
				builder.Append(this.Step.ToString());
				builder.Append(", PhaseTag = ");
				builder.Append(this.PhaseTag);
				builder.Append(", ShouldExecute = ");
				builder.Append(this.ShouldExecute);
				return true;
			}

			// Token: 0x0604BA77 RID: 309879 RVA: 0x0149113C File Offset: 0x0148F33C
			[NullableContext(2)]
			[CompilerGenerated]
			public static bool operator !=(RoundManager.RoundSequenceNode left, RoundManager.RoundSequenceNode right)
			{
				return !(left == right);
			}

			// Token: 0x0604BA78 RID: 309880 RVA: 0x01491148 File Offset: 0x0148F348
			[NullableContext(2)]
			[CompilerGenerated]
			public static bool operator ==(RoundManager.RoundSequenceNode left, RoundManager.RoundSequenceNode right)
			{
				return left == right || (left != null && left.Equals(right));
			}

			// Token: 0x0604BA79 RID: 309881 RVA: 0x0149115C File Offset: 0x0148F35C
			[CompilerGenerated]
			public override int GetHashCode()
			{
				return ((EqualityComparer<Type>.Default.GetHashCode(this.EqualityContract) * -1521134295 + EqualityComparer<ERoundStep>.Default.GetHashCode(this.<Step>k__BackingField)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.<PhaseTag>k__BackingField)) * -1521134295 + EqualityComparer<Func<RoundManager, bool>>.Default.GetHashCode(this.<ShouldExecute>k__BackingField);
			}

			// Token: 0x0604BA7A RID: 309882 RVA: 0x014911BE File Offset: 0x0148F3BE
			[NullableContext(2)]
			[CompilerGenerated]
			public override bool Equals(object obj)
			{
				return this.Equals(obj as RoundManager.RoundSequenceNode);
			}

			// Token: 0x0604BA7B RID: 309883 RVA: 0x014911CC File Offset: 0x0148F3CC
			[NullableContext(2)]
			[CompilerGenerated]
			public virtual bool Equals(RoundManager.RoundSequenceNode other)
			{
				return this == other || (other != null && this.EqualityContract == other.EqualityContract && EqualityComparer<ERoundStep>.Default.Equals(this.<Step>k__BackingField, other.<Step>k__BackingField) && EqualityComparer<string>.Default.Equals(this.<PhaseTag>k__BackingField, other.<PhaseTag>k__BackingField) && EqualityComparer<Func<RoundManager, bool>>.Default.Equals(this.<ShouldExecute>k__BackingField, other.<ShouldExecute>k__BackingField));
			}

			// Token: 0x0604BA7D RID: 309885 RVA: 0x01491245 File Offset: 0x0148F445
			[CompilerGenerated]
			protected RoundSequenceNode(RoundManager.RoundSequenceNode original)
			{
				this.Step = original.<Step>k__BackingField;
				this.PhaseTag = original.<PhaseTag>k__BackingField;
				this.ShouldExecute = original.<ShouldExecute>k__BackingField;
			}

			// Token: 0x0604BA7E RID: 309886 RVA: 0x01491271 File Offset: 0x0148F471
			[CompilerGenerated]
			public void Deconstruct(out ERoundStep Step, out string PhaseTag, [Nullable(new byte[]
			{
				2,
				1
			})] out Func<RoundManager, bool> ShouldExecute)
			{
				Step = this.Step;
				PhaseTag = this.PhaseTag;
				ShouldExecute = this.ShouldExecute;
			}
		}
	}
}
