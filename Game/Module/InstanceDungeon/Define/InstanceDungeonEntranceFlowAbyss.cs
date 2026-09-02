using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C1F RID: 23583
	public class InstanceDungeonEntranceFlowAbyss : InstanceDungeonEntranceFlowBase
	{
		// Token: 0x0603B9FF RID: 244223 RVA: 0x00F1BAB9 File Offset: 0x00F19CB9
		protected override void OnCreate()
		{
			base.AddStep(delegate
			{
				ModelBase<DangoAbyssModel>.Instance.InitCacheDangoOwnerMap();
				ModelBase<DangoAbyssModel>.Instance.SetInAbyssFlow(true);
				ControllerBase<EditBattleTeamController>.Instance.PlayerOpenEditBattleTeamView(ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId, false, true, false, null);
			});
			base.AddStep(delegate
			{
				ModelBase<DangoAbyssModel>.Instance.SetInAbyssFlow(false);
				List<int> item = ModelBase<EditBattleTeamModel>.Instance.GetOwnRoleConfigIdList.Item1;
				int value = ModelBase<PlayerInfoModel>.Instance.GetId().Value;
				MapField<int, int> mapField = new MapField<int, int>();
				foreach (int num in item)
				{
					AbyssDangoOwnerData playerRoleCfgOwnerData = ModelBase<DangoAbyssModel>.Instance.GetPlayerRoleCfgOwnerData(value, num);
					mapField[num] = ((playerRoleCfgOwnerData != null) ? playerRoleCfgOwnerData.DangoId : 0);
				}
				AbyssInstCtx abyssInstCtx = new AbyssInstCtx();
				abyssInstCtx.LittleRoleMap.MergeFrom(mapField);
				ModelBase<DangoAbyssModel>.Instance.SaveCacheDangoOwnerMap();
				ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.AbyssInstCtx = abyssInstCtx;
				int currentSelectEntranceId = ModelBase<DangoAbyssModel>.Instance.CurrentSelectEntranceId;
				int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
				this.TryEnterAbyss(instanceId, item, currentSelectEntranceId);
			});
		}

		// Token: 0x0603BA00 RID: 244224 RVA: 0x00F1BAF4 File Offset: 0x00F19CF4
		[NullableContext(1)]
		private UniTask TryEnterAbyss(int insId, List<int> roleIds, int entranceId)
		{
			InstanceDungeonEntranceFlowAbyss.<TryEnterAbyss>d__1 <TryEnterAbyss>d__;
			<TryEnterAbyss>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TryEnterAbyss>d__.<>4__this = this;
			<TryEnterAbyss>d__.insId = insId;
			<TryEnterAbyss>d__.roleIds = roleIds;
			<TryEnterAbyss>d__.entranceId = entranceId;
			<TryEnterAbyss>d__.<>1__state = -1;
			<TryEnterAbyss>d__.<>t__builder.Start<InstanceDungeonEntranceFlowAbyss.<TryEnterAbyss>d__1>(ref <TryEnterAbyss>d__);
			return <TryEnterAbyss>d__.<>t__builder.Task;
		}

		// Token: 0x0603BA01 RID: 244225 RVA: 0x00F1BB4F File Offset: 0x00F19D4F
		protected override void OnEditBattleViewCloseCall()
		{
			ModelBase<DangoAbyssModel>.Instance.SetInAbyssFlow(false);
		}
	}
}
