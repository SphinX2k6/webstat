using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.Guarantee;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FA1 RID: 28577
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowPreload : LevelFlowActionBase
	{
		// Token: 0x060451FC RID: 283132 RVA: 0x01208DD4 File Offset: 0x01206FD4
		public LevelFlowPreload Init(PreloadAction param)
		{
			this.PreloadActionParam = param;
			return this;
		}

		// Token: 0x060451FD RID: 283133 RVA: 0x01208DE0 File Offset: 0x01206FE0
		protected override void OnExecute()
		{
			PreloadAction preloadActionParam = this.PreloadActionParam;
			if (preloadActionParam != null && preloadActionParam.PreloadObjectType.Type == EPreloadObjectType.PreloadFlows)
			{
				IPreloadFlows preloadFlows = preloadActionParam.PreloadObjectType as IPreloadFlows;
				if (preloadFlows != null)
				{
					PlayFlow flowData = preloadFlows.FlowData;
					ControllerBase<PreloadControllerNew>.Instance.PreloadPlot(flowData.FlowListName, flowData.FlowId, flowData.StateId, 0);
					base.FinishExecute(true);
					return;
				}
			}
			if (preloadActionParam != null && preloadActionParam.PreloadObjectType.Type == EPreloadObjectType.PreloadMp4s)
			{
				IPreloadMp4s preloadMp4s = preloadActionParam.PreloadObjectType as IPreloadMp4s;
				if (preloadMp4s != null)
				{
					List<string> mp4s = preloadMp4s.Mp4s;
					if (mp4s == null || mp4s.Count < 1)
					{
						Singleton<global::Log>.Instance.Info(ELogModule.LevelFlow, ELogAuthor.JYS, "[VideoBp] Mp4数组异常", default(ReadOnlySpan<ValueTuple<string, object>>));
						base.FinishExecute(true);
						return;
					}
					ControllerBase<VideoBpController>.Instance.PreloadMp4s(mp4s);
					Singleton<EventSystem>.Instance.Emit<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.AddGuaranteeAction, "LevelEventPreload", null, new GuaranteeActionInfo
					{
						Name = EGuaranteeAction.Preload,
						Params = new GuaranteePreloadParams
						{
							Mp4Names = mp4s
						}
					}, new bool?(true));
					base.FinishExecute(true);
					return;
				}
			}
			if ((preloadActionParam != null && preloadActionParam.PreloadObjectType.Type == EPreloadObjectType.PreloadPhantomCharacterForSkill) || (preloadActionParam != null && preloadActionParam.PreloadObjectType.Type == EPreloadObjectType.PreloadTrialCharacterForSkill))
			{
				this.PreloadRole(preloadActionParam);
			}
			if (preloadActionParam != null && preloadActionParam.PreloadObjectType.Type == EPreloadObjectType.PreloadLinkResource)
			{
				this.PreloadLinkRes(preloadActionParam);
			}
		}

		// Token: 0x060451FE RID: 283134 RVA: 0x01208F3C File Offset: 0x0120713C
		private unsafe void PreloadRole(PreloadAction params_)
		{
			IPreloadCharacterType preloadObjectType = params_.PreloadObjectType;
			EPreloadObjectType type = preloadObjectType.Type;
			List<int> list = new List<int>();
			if (type == EPreloadObjectType.PreloadTrialCharacterForSkill)
			{
				using (List<ICharacterGroupNew>.Enumerator enumerator = ((IPreloadTrialCharacterForSkill)preloadObjectType).CharacterGroupNew.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ICharacterGroupNew characterGroupNew = enumerator.Current;
						list.Add(characterGroupNew.CharacterId);
					}
					goto IL_B6;
				}
			}
			if (type == EPreloadObjectType.PreloadPhantomCharacterForSkill)
			{
				PhantomFormation? config = ConfigPhantomFormationById.GetConfig(((IPreloadPhantomCharacterForSkill)preloadObjectType).Id, true);
				if (config != null)
				{
					Span<int> rolesBytes = config.Value.GetRolesBytes();
					for (int i = 0; i < rolesBytes.Length; i++)
					{
						int item = *rolesBytes[i];
						list.Add(item);
					}
				}
			}
			IL_B6:
			List<long> list2 = new List<long>();
			foreach (int roleId in list)
			{
				ValueTuple<long, EntityHandle>? preloadEntityData = ModelBase<SceneTeamModel>.Instance.GetPreloadEntityData(roleId);
				if (preloadEntityData != null)
				{
					list2.Add(preloadEntityData.Value.Item1);
				}
			}
			if (list2.Count <= 0)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelFlow;
				ELogAuthor author = ELogAuthor.LYY;
				string message = "[PreloadRole] 无预加载实体";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RoleIdList", string.Join<int>(",", list));
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishExecute(true);
				return;
			}
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.LevelFlow;
			ELogAuthor author2 = ELogAuthor.LYY;
			string message2 = "[PreloadRole] 开始等待实体加载";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("CreatureDataIdList", string.Join<long>(",", list2));
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			WaitEntityTask.Create("LevelEventPreloadRole.ExecuteNew", list2, delegate(bool? result)
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.LevelFlow;
				ELogAuthor author3 = ELogAuthor.LYY;
				string message3 = "[PreloadRole] 实体加载结束";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Result", result);
				instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				base.FinishExecute(true);
			}, 60000, true, false);
		}

		// Token: 0x060451FF RID: 283135 RVA: 0x01209110 File Offset: 0x01207310
		private UniTask PreloadLinkRes(PreloadAction params_)
		{
			LevelFlowPreload.<PreloadLinkRes>d__5 <PreloadLinkRes>d__;
			<PreloadLinkRes>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreloadLinkRes>d__.<>4__this = this;
			<PreloadLinkRes>d__.params_ = params_;
			<PreloadLinkRes>d__.<>1__state = -1;
			<PreloadLinkRes>d__.<>t__builder.Start<LevelFlowPreload.<PreloadLinkRes>d__5>(ref <PreloadLinkRes>d__);
			return <PreloadLinkRes>d__.<>t__builder.Task;
		}

		// Token: 0x04026916 RID: 157974
		[Nullable(2)]
		private PreloadAction PreloadActionParam;

		// Token: 0x04026917 RID: 157975
		private const int WAITE_ENTITY_PRELOAD_TIME = 60000;
	}
}
