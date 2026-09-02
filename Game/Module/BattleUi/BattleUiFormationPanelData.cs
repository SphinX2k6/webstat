using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F76 RID: 24438
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiFormationPanelData
	{
		// Token: 0x0603D575 RID: 251253 RVA: 0x00F999A4 File Offset: 0x00F97BA4
		public void Init()
		{
		}

		// Token: 0x0603D576 RID: 251254 RVA: 0x00F999A6 File Offset: 0x00F97BA6
		public void Clear()
		{
			this.PositionItemMap.Clear();
		}

		// Token: 0x0603D577 RID: 251255 RVA: 0x00F999B4 File Offset: 0x00F97BB4
		public void UpdateFormationPanelData()
		{
			this.PositionItemMap.Clear();
			int valueOrDefault = ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault();
			bool flag = !ControllerBase<GameModeController>.Instance.IsInInstance();
			int[] array;
			if (!ModelBase<GameModeModel>.Instance.IsMulti)
			{
				(array = new int[1])[0] = valueOrDefault;
			}
			else
			{
				array = ModelBase<OnlineModel>.Instance.GetAllWorldTeamPlayer();
			}
			int[] array2 = array;
			int i = 0;
			while (i < array2.Length)
			{
				int num = array2[i];
				bool flag2 = num == valueOrDefault;
				SceneTeamPlayer teamPlayerData = ModelBase<SceneTeamModel>.Instance.GetTeamPlayerData(num);
				if (teamPlayerData != null)
				{
					goto IL_F3;
				}
				if (!flag2 && flag)
				{
					WorldTeamPlayerFightInfo worldTeamPlayerFightInfo = ModelBase<OnlineModel>.Instance.GetWorldTeamPlayerFightInfo(num);
					List<WorldTeamRoleInfo> list = (worldTeamPlayerFightInfo != null) ? worldTeamPlayerFightInfo.RoleInfos : null;
					if (list != null)
					{
						using (List<WorldTeamRoleInfo>.Enumerator enumerator = list.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								WorldTeamRoleInfo worldTeamRoleInfo = enumerator.Current;
								this.AddPositionItem(num, worldTeamRoleInfo.RoleId, worldTeamRoleInfo.RoleSkinId, null);
							}
							goto IL_25F;
						}
						goto IL_F3;
					}
				}
				IL_25F:
				i++;
				continue;
				IL_F3:
				SceneTeamGroup group = teamPlayerData.GetGroup(ETeamGroupType.Battle);
				List<SceneTeamRole> list2 = (group != null) ? group.GetRoleList() : null;
				if (list2 != null)
				{
					if (flag2)
					{
						using (List<SceneTeamRole>.Enumerator enumerator2 = list2.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								SceneTeamRole sceneTeamRole = enumerator2.Current;
								int roleId = sceneTeamRole.RoleId;
								int roleSkinIdByRoleId = ModelBase<RoleSkinModel>.Instance.GetRoleSkinIdByRoleId(roleId);
								this.AddPositionItem(num, roleId, roleSkinIdByRoleId, new long?(sceneTeamRole.CreatureDataId));
							}
							goto IL_25F;
						}
					}
					WorldTeamPlayerFightInfo worldTeamPlayerFightInfo2 = ModelBase<OnlineModel>.Instance.GetWorldTeamPlayerFightInfo(num);
					foreach (SceneTeamRole sceneTeamRole2 in list2)
					{
						int roleId2 = sceneTeamRole2.RoleId;
						WorldTeamRoleInfo worldTeamRoleInfo2 = (worldTeamPlayerFightInfo2 != null) ? worldTeamPlayerFightInfo2.GetRoleInfoByConfigId(roleId2) : null;
						int roleSkinId;
						if (worldTeamRoleInfo2 != null)
						{
							roleSkinId = worldTeamRoleInfo2.RoleSkinId;
						}
						else
						{
							long creatureDataId = sceneTeamRole2.CreatureDataId;
							if (creatureDataId == 0L)
							{
								return;
							}
							EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
							int? num2;
							if (entity == null)
							{
								num2 = null;
							}
							else
							{
								WorldEntity entity2 = entity.Entity;
								if (entity2 == null)
								{
									num2 = null;
								}
								else
								{
									CreatureDataComponent component = entity2.GetComponent<CreatureDataComponent>();
									num2 = ((component != null) ? new int?(component.GetSkinId()) : null);
								}
							}
							int? num3 = num2;
							roleSkinId = num3.GetValueOrDefault();
						}
						this.AddPositionItem(num, roleId2, roleSkinId, new long?(sceneTeamRole2.CreatureDataId));
					}
					goto IL_25F;
				}
				goto IL_25F;
			}
		}

		// Token: 0x0603D578 RID: 251256 RVA: 0x00F99C58 File Offset: 0x00F97E58
		private void AddPositionItem(int playerId, int roleId, int roleSkinId, long? creatureDataId = null)
		{
			int key = this.PositionItemMap.Count + 1;
			FormationItemData formationItemData = new FormationItemData();
			formationItemData.PlayerId = playerId;
			formationItemData.RoleId = roleId;
			formationItemData.RoleSkinId = roleSkinId;
			if (creatureDataId != null)
			{
				formationItemData.CreatureDataId = creatureDataId.Value;
			}
			this.PositionItemMap[key] = formationItemData;
		}

		// Token: 0x0603D579 RID: 251257 RVA: 0x00F99CB1 File Offset: 0x00F97EB1
		[NullableContext(2)]
		public FormationItemData GetItemData(int position)
		{
			return this.PositionItemMap.GetValueOrDefault(position);
		}

		// Token: 0x0603D57A RID: 251258 RVA: 0x00F99CC0 File Offset: 0x00F97EC0
		public int GetRolePosition(int playerId, int roleId)
		{
			foreach (KeyValuePair<int, FormationItemData> keyValuePair in this.PositionItemMap)
			{
				if (keyValuePair.Value.PlayerId == playerId && keyValuePair.Value.RoleId == roleId)
				{
					return keyValuePair.Key;
				}
			}
			return 0;
		}

		// Token: 0x0603D57B RID: 251259 RVA: 0x00F99D38 File Offset: 0x00F97F38
		public IReadOnlyList<string> GetActionNames()
		{
			return BattleUiFormationPanelData.ActionNames;
		}

		// Token: 0x0603D57C RID: 251260 RVA: 0x00F99D40 File Offset: 0x00F97F40
		public void SetInputType(EFormationInputType type)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.LYY;
			string message = "切换编队ActionInputHandler";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", type);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.InputHandler = this.InputHandlerMap.GetValueOrDefault(type);
		}

		// Token: 0x0603D57D RID: 251261 RVA: 0x00F99D8B File Offset: 0x00F97F8B
		public void RegisterInputHandler(EFormationInputType type, Action<string> handler)
		{
			this.InputHandlerMap[type] = handler;
		}

		// Token: 0x0603D57E RID: 251262 RVA: 0x00F99D9A File Offset: 0x00F97F9A
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<string> GetInputHandler()
		{
			return this.InputHandler;
		}

		// Token: 0x04022724 RID: 141092
		[StaticVariableRuleIgnore]
		private static readonly string[] ActionNames = new string[]
		{
			"切换角色1",
			"切换角色2",
			"切换角色3",
			"切换角色4"
		};

		// Token: 0x04022725 RID: 141093
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<string> InputHandler;

		// Token: 0x04022726 RID: 141094
		private readonly Dictionary<EFormationInputType, Action<string>> InputHandlerMap = new Dictionary<EFormationInputType, Action<string>>();

		// Token: 0x04022727 RID: 141095
		public Dictionary<int, FormationItemData> PositionItemMap = new Dictionary<int, FormationItemData>();
	}
}
