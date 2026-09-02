using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062AC RID: 25260
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class TetrisController : ControllerBase<TetrisController>
	{
		// Token: 0x0603F8E6 RID: 260326 RVA: 0x010494EB File Offset: 0x010476EB
		public void OpenActivityTetris(int challengeId)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TetrisPlayView, challengeId, null);
		}

		// Token: 0x0603F8E7 RID: 260327 RVA: 0x01049504 File Offset: 0x01047704
		public UniTask OpenEndlessTetris(int challengeId)
		{
			TetrisController.<OpenEndlessTetris>d__3 <OpenEndlessTetris>d__;
			<OpenEndlessTetris>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenEndlessTetris>d__.challengeId = challengeId;
			<OpenEndlessTetris>d__.<>1__state = -1;
			<OpenEndlessTetris>d__.<>t__builder.Start<TetrisController.<OpenEndlessTetris>d__3>(ref <OpenEndlessTetris>d__);
			return <OpenEndlessTetris>d__.<>t__builder.Task;
		}

		// Token: 0x0603F8E8 RID: 260328 RVA: 0x01049547 File Offset: 0x01047747
		public long GetEntityId()
		{
			return this.EntityId;
		}

		// Token: 0x0603F8E9 RID: 260329 RVA: 0x0104954F File Offset: 0x0104774F
		public void SetEntityId(long entityId)
		{
			this.EntityId = entityId;
		}

		// Token: 0x0603F8EA RID: 260330 RVA: 0x01049558 File Offset: 0x01047758
		public long GetHighestScore()
		{
			return this.HighestScore;
		}

		// Token: 0x0603F8EB RID: 260331 RVA: 0x01049560 File Offset: 0x01047760
		public void SetHighestScore(long score)
		{
			this.HighestScore = score;
		}

		// Token: 0x0603F8EC RID: 260332 RVA: 0x0104956C File Offset: 0x0104776C
		public void SendCompleteRequest(TetrisFinishRequest request, [Nullable(2)] Action callback = null)
		{
			Singleton<Net>.Instance.Call<TetrisFinishResponse>(ERequestMessageId.TetrisFinishRequest, request, delegate(TetrisFinishResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15438, null, true, true);
				}
				if (callback != null)
				{
					callback();
				}
			}, 0);
		}

		// Token: 0x04023ADB RID: 146139
		private long EntityId;

		// Token: 0x04023ADC RID: 146140
		private long HighestScore;
	}
}
