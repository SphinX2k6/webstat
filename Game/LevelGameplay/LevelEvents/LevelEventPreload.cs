using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.Guarantee;
using CSharpScript.Game.Module.Battle;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BCE RID: 27598
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventPreload : LevelEventBase
	{
		// Token: 0x06044079 RID: 278649 RVA: 0x011A4A1D File Offset: 0x011A2C1D
		public LevelEventPreload(int id) : base(id)
		{
		}

		// Token: 0x0604407A RID: 278650 RVA: 0x011A4A26 File Offset: 0x011A2C26
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x0604407B RID: 278651 RVA: 0x011A4A34 File Offset: 0x011A2C34
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			PreloadAction preloadAction = inParams as PreloadAction;
			if (preloadAction.PreloadObjectType.Type == EPreloadObjectType.PreloadFlows)
			{
				PlayFlow flowData = (preloadAction.PreloadObjectType as IPreloadFlows).FlowData;
				ControllerBase<PreloadControllerNew>.Instance.PreloadPlot(flowData.FlowListName, flowData.FlowId, flowData.StateId, 0);
				base.FinishExecute(true, false, true);
				return;
			}
			if (preloadAction.PreloadObjectType.Type != EPreloadObjectType.PreloadMp4s)
			{
				if (preloadAction.PreloadObjectType.Type == EPreloadObjectType.PreloadPhantomCharacterForSkill || preloadAction.PreloadObjectType.Type == EPreloadObjectType.PreloadTrialCharacterForSkill)
				{
					this.PreloadRole(preloadAction);
				}
				if (preloadAction.PreloadObjectType.Type == EPreloadObjectType.PreloadLinkResource)
				{
					this.PreloadLinkRes(preloadAction);
				}
				return;
			}
			List<string> mp4s = (preloadAction.PreloadObjectType as IPreloadMp4s).Mp4s;
			if (mp4s == null || mp4s.Count < 1)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.Event, ELogAuthor.JYS, "[VideoBp] Mp4数组异常", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(true, false, true);
				return;
			}
			ControllerBase<VideoBpController>.Instance.PreloadMp4s(mp4s);
			Singleton<EventSystem>.Instance.Emit<string, GeneralContext, GuaranteeActionInfo, bool?>(EEventName.AddGuaranteeAction, "LevelEventPreload", context, new GuaranteeActionInfo
			{
				Name = EGuaranteeAction.Preload,
				Params = new GuaranteePreloadParams
				{
					Mp4Names = mp4s
				}
			}, new bool?(true));
			base.FinishExecute(true, false, true);
		}

		// Token: 0x0604407C RID: 278652 RVA: 0x011A4B6C File Offset: 0x011A2D6C
		private unsafe void PreloadRole(PreloadAction @params)
		{
			IPreloadCharacterType preloadObjectType = @params.PreloadObjectType;
			EPreloadObjectType type = preloadObjectType.Type;
			List<int> list = new List<int>();
			if (type == EPreloadObjectType.PreloadTrialCharacterForSkill)
			{
				using (List<ICharacterGroupNew>.Enumerator enumerator = (preloadObjectType as IPreloadTrialCharacterForSkill).CharacterGroupNew.GetEnumerator())
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
				PhantomFormation? config = ConfigPhantomFormationById.GetConfig((preloadObjectType as IPreloadPhantomCharacterForSkill).Id, true);
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
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.LYY;
				string message = "[PreloadRole] 无预加载实体";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RoleIdList", list);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishExecute(true, false, true);
				return;
			}
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.Event;
			ELogAuthor author2 = ELogAuthor.LYY;
			string message2 = "[PreloadRole] 开始等待实体加载";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("CreatureDataIdList", list2);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			WaitEntityTask.Create("LevelEventPreloadRole.ExecuteNew", list2, delegate(bool? result)
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.Event;
				ELogAuthor author3 = ELogAuthor.LYY;
				string message3 = "[PreloadRole] 实体加载结束";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Result", result);
				instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				base.FinishExecute(true, false, true);
			}, 60000, true, false);
		}

		// Token: 0x0604407D RID: 278653 RVA: 0x011A4D28 File Offset: 0x011A2F28
		private void PreloadLinkRes(PreloadAction @params)
		{
			IPreloadLinkResource config = @params.PreloadObjectType as IPreloadLinkResource;
			ControllerBase<BattleLinkController>.Instance.PreloadRes(config.LinkResourceId).ContinueWith(delegate(bool r)
			{
				if (!r)
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Event;
					ELogAuthor author = ELogAuthor.WWJ;
					string message = "[PreloadLinkRes]资源预加载失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LinkResourceId", config.LinkResourceId);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					global::Log instance2 = Singleton<global::Log>.Instance;
					ELogModule module2 = ELogModule.Event;
					ELogAuthor author2 = ELogAuthor.WWJ;
					string message2 = "[PreloadLinkRes]资源预加载完成";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("LinkResourceId", config.LinkResourceId);
					instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
				this.FinishExecute(true, false, true);
			});
		}

		// Token: 0x0402605E RID: 155742
		public const int WAITE_ENTITY_PRELOAD_TIME = 60000;
	}
}
