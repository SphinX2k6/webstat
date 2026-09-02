using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo.Controller.GameMode;
using CSharpScript.Game.Module.WuwaGo.Model;
using CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Controller.GameplayEntity
{
	// Token: 0x02004B11 RID: 19217
	[NullableContext(1)]
	[Nullable(0)]
	public class PressureTriggerController : GameplayEntityControllerBase
	{
		// Token: 0x060321EC RID: 205292 RVA: 0x00C8AF0C File Offset: 0x00C8910C
		public PressureTriggerController(WuWaGoGameplayEntityBase entity, WuWaGoGameData gameData, WuWaGoGameModeBase gameMode) : base(entity, gameData, gameMode)
		{
		}

		// Token: 0x17008590 RID: 34192
		// (get) Token: 0x060321ED RID: 205293 RVA: 0x00C8AF17 File Offset: 0x00C89117
		private WuWaGoPressureTriggerEntity PressureTrigger
		{
			get
			{
				return this.Entity as WuWaGoPressureTriggerEntity;
			}
		}

		// Token: 0x060321EE RID: 205294 RVA: 0x00C8AF24 File Offset: 0x00C89124
		protected override bool OnCreate()
		{
			if (!base.OnCreate())
			{
				return false;
			}
			base.RegisterAttachedGridMoveParticipant();
			return true;
		}

		// Token: 0x060321EF RID: 205295 RVA: 0x00C8AF37 File Offset: 0x00C89137
		protected override void OnDestroy()
		{
			base.OnDestroy();
			base.UnregisterAttachedGridMoveParticipant();
		}

		// Token: 0x060321F0 RID: 205296 RVA: 0x00C8AF48 File Offset: 0x00C89148
		protected override UniTask OnExecuteAction()
		{
			PressureTriggerController.<OnExecuteAction>d__5 <OnExecuteAction>d__;
			<OnExecuteAction>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnExecuteAction>d__.<>4__this = this;
			<OnExecuteAction>d__.<>1__state = -1;
			<OnExecuteAction>d__.<>t__builder.Start<PressureTriggerController.<OnExecuteAction>d__5>(ref <OnExecuteAction>d__);
			return <OnExecuteAction>d__.<>t__builder.Task;
		}

		// Token: 0x060321F1 RID: 205297 RVA: 0x00C8AF8B File Offset: 0x00C8918B
		protected override void OnAfterExecuteAction()
		{
			this.ExecuteDirtyChange().Forget();
		}

		// Token: 0x060321F2 RID: 205298 RVA: 0x00C8AF98 File Offset: 0x00C89198
		private UniTask ExecuteDirtyChange()
		{
			PressureTriggerController.<ExecuteDirtyChange>d__7 <ExecuteDirtyChange>d__;
			<ExecuteDirtyChange>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ExecuteDirtyChange>d__.<>4__this = this;
			<ExecuteDirtyChange>d__.<>1__state = -1;
			<ExecuteDirtyChange>d__.<>t__builder.Start<PressureTriggerController.<ExecuteDirtyChange>d__7>(ref <ExecuteDirtyChange>d__);
			return <ExecuteDirtyChange>d__.<>t__builder.Task;
		}
	}
}
