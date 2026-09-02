using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.World.Controller
{
	// Token: 0x020046E1 RID: 18145
	public class BattleNetController : IStaticVariableResetter
	{
		// Token: 0x0602F317 RID: 193303 RVA: 0x00B2EC27 File Offset: 0x00B2CE27
		static BattleNetController()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(BattleNetController.CreateStaticDefaultValue), new Action(BattleNetController.ResetStaticDefaultValue));
		}

		// Token: 0x0602F318 RID: 193304 RVA: 0x00B2EC46 File Offset: 0x00B2CE46
		public static void CreateStaticDefaultValue()
		{
			BattleNetController.LastRequestTime = 0.0;
			BattleNetController.LastBatchRequestTime = 0.0;
			BattleNetController.LastCollectRequestTime = 0.0;
		}

		// Token: 0x0602F319 RID: 193305 RVA: 0x00B2EC72 File Offset: 0x00B2CE72
		public static void ResetStaticDefaultValue()
		{
			BattleNetController.LastRequestTime = 0.0;
			BattleNetController.LastBatchRequestTime = 0.0;
			BattleNetController.LastCollectRequestTime = 0.0;
		}

		// Token: 0x0602F31A RID: 193306 RVA: 0x00B2ECA0 File Offset: 0x00B2CEA0
		public static UniTask<bool> RequestCaptureEntity(int entityId)
		{
			BattleNetController.<RequestCaptureEntity>d__6 <RequestCaptureEntity>d__;
			<RequestCaptureEntity>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestCaptureEntity>d__.entityId = entityId;
			<RequestCaptureEntity>d__.<>1__state = -1;
			<RequestCaptureEntity>d__.<>t__builder.Start<BattleNetController.<RequestCaptureEntity>d__6>(ref <RequestCaptureEntity>d__);
			return <RequestCaptureEntity>d__.<>t__builder.Task;
		}

		// Token: 0x0602F31B RID: 193307 RVA: 0x00B2ECE4 File Offset: 0x00B2CEE4
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static UniTask<List<int>> RequestBatchCaptureEntity(List<int> entityIds)
		{
			BattleNetController.<RequestBatchCaptureEntity>d__7 <RequestBatchCaptureEntity>d__;
			<RequestBatchCaptureEntity>d__.<>t__builder = AsyncUniTaskMethodBuilder<List<int>>.Create();
			<RequestBatchCaptureEntity>d__.entityIds = entityIds;
			<RequestBatchCaptureEntity>d__.<>1__state = -1;
			<RequestBatchCaptureEntity>d__.<>t__builder.Start<BattleNetController.<RequestBatchCaptureEntity>d__7>(ref <RequestBatchCaptureEntity>d__);
			return <RequestBatchCaptureEntity>d__.<>t__builder.Task;
		}

		// Token: 0x0602F31C RID: 193308 RVA: 0x00B2ED28 File Offset: 0x00B2CF28
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public static UniTask<List<long>> RequestBatchCollect(List<long> entityCreatureIds)
		{
			BattleNetController.<RequestBatchCollect>d__9 <RequestBatchCollect>d__;
			<RequestBatchCollect>d__.<>t__builder = AsyncUniTaskMethodBuilder<List<long>>.Create();
			<RequestBatchCollect>d__.entityCreatureIds = entityCreatureIds;
			<RequestBatchCollect>d__.<>1__state = -1;
			<RequestBatchCollect>d__.<>t__builder.Start<BattleNetController.<RequestBatchCollect>d__9>(ref <RequestBatchCollect>d__);
			return <RequestBatchCollect>d__.<>t__builder.Task;
		}

		// Token: 0x0401AE3C RID: 110140
		private const int REQUEST_TIME_GAP = 2000;

		// Token: 0x0401AE3D RID: 110141
		private static double LastRequestTime;

		// Token: 0x0401AE3E RID: 110142
		private static double LastBatchRequestTime;

		// Token: 0x0401AE3F RID: 110143
		private static double LastCollectRequestTime;
	}
}
