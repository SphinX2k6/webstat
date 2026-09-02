using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay
{
	// Token: 0x020068F4 RID: 26868
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class DropCatchGameplayController : UiControllerBase<DropCatchGameplayController>
	{
		// Token: 0x1700A1CB RID: 41419
		// (get) Token: 0x06042C1F RID: 273439 RVA: 0x01121DAC File Offset: 0x0111FFAC
		// (set) Token: 0x06042C1E RID: 273438 RVA: 0x01121DA3 File Offset: 0x0111FFA3
		public bool EnableDebug
		{
			get
			{
				return !Singleton<Info>.Instance.IsBuildShipping && this.EnableDebugInternal;
			}
			set
			{
				this.EnableDebugInternal = value;
			}
		}

		// Token: 0x06042C20 RID: 273440 RVA: 0x01121DC2 File Offset: 0x0111FFC2
		public void StartGameplay(int gameplayId)
		{
			if (this.GameplayProxy == null)
			{
				this.GameplayProxy = new DropCatchGameplayProxy();
			}
			this.GameplayProxy.StartGameplay(gameplayId);
		}

		// Token: 0x06042C21 RID: 273441 RVA: 0x01121DE4 File Offset: 0x0111FFE4
		public int GetCurrentGameplayId()
		{
			DropCatchGameplayProxy gameplayProxy = this.GameplayProxy;
			int? num;
			if (gameplayProxy == null)
			{
				num = null;
			}
			else
			{
				DropCatchGameplayViewModel gameplayViewModel = gameplayProxy.GetGameplayViewModel();
				num = ((gameplayViewModel != null) ? new int?(gameplayViewModel.GetCurGameplayId()) : null);
			}
			int? num2 = num;
			return num2.GetValueOrDefault();
		}

		// Token: 0x06042C22 RID: 273442 RVA: 0x01121E2C File Offset: 0x0112002C
		public void SettleGameplay(IDropCatchSettleGameplay @params, Action successCallback)
		{
			DropCatchLevelFinishRequest dropCatchLevelFinishRequest = DropCatchLevelFinishRequest.Create();
			dropCatchLevelFinishRequest.DropCatchId = @params.GameplayId;
			dropCatchLevelFinishRequest.Score = (int)Singleton<MathUtils>.Instance.Clamp(@params.Score, 0f, 2.1474836E+09f);
			Singleton<Net>.Instance.Call<DropCatchLevelFinishResponse>(ERequestMessageId.DropCatchLevelFinishRequest, dropCatchLevelFinishRequest, delegate(DropCatchLevelFinishResponse response, [Nullable(2)] Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.Error != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Error, 29501, null, true, true);
				}
				successCallback();
			}, 0);
		}

		// Token: 0x06042C23 RID: 273443 RVA: 0x01121E96 File Offset: 0x01120096
		public void EndGameplay()
		{
			DropCatchGameplayProxy gameplayProxy = this.GameplayProxy;
			if (gameplayProxy != null)
			{
				gameplayProxy.EndGameplay();
			}
			this.GameplayProxy = null;
		}

		// Token: 0x06042C24 RID: 273444 RVA: 0x01121EB0 File Offset: 0x011200B0
		public override bool Clear()
		{
			this.EndGameplay();
			return base.Clear();
		}

		// Token: 0x06042C25 RID: 273445 RVA: 0x01121EC0 File Offset: 0x011200C0
		public void ExecuteCommand(string command)
		{
			CommandData commandData = Json.Parse<CommandData>(command, null);
			if (commandData == null)
			{
				return;
			}
			DropCatchGameplayProxy gameplayProxy = this.GameplayProxy;
			if (gameplayProxy == null)
			{
				return;
			}
			DropCatchGameplayLogic gameplayLogic = gameplayProxy.GetGameplayLogic();
			if (gameplayLogic == null)
			{
				return;
			}
			gameplayLogic.GetGameplayCommandMgr().ExecuteCommand(commandData.CommandName, commandData.Params);
		}

		// Token: 0x06042C26 RID: 273446 RVA: 0x01121F04 File Offset: 0x01120104
		public UniTask RequestHistoryScore()
		{
			DropCatchGameplayController.<RequestHistoryScore>d__11 <RequestHistoryScore>d__;
			<RequestHistoryScore>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestHistoryScore>d__.<>1__state = -1;
			<RequestHistoryScore>d__.<>t__builder.Start<DropCatchGameplayController.<RequestHistoryScore>d__11>(ref <RequestHistoryScore>d__);
			return <RequestHistoryScore>d__.<>t__builder.Task;
		}

		// Token: 0x04025320 RID: 152352
		private bool EnableDebugInternal;

		// Token: 0x04025321 RID: 152353
		[Nullable(2)]
		private DropCatchGameplayProxy GameplayProxy;
	}
}
