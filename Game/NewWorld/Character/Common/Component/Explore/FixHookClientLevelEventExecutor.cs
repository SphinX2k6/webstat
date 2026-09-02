using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.NewWorld.Character.Custom.Components;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Explore
{
	// Token: 0x02004952 RID: 18770
	public class FixHookClientLevelEventExecutor
	{
		// Token: 0x06031150 RID: 201040 RVA: 0x00C35A4C File Offset: 0x00C33C4C
		[NullableContext(2)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private static List<ActionInfo> GetActions(FixHookClientLevelEventExecutor.EHookPointStage stage, IHookInteractType hookInteractConfig = null)
		{
			switch (stage)
			{
			case FixHookClientLevelEventExecutor.EHookPointStage.ClientHook:
			{
				if (hookInteractConfig == null)
				{
					return null;
				}
				IClientHookActionConfig clientHookActionConfig = hookInteractConfig.ClientHookActionConfig;
				if (clientHookActionConfig == null)
				{
					return null;
				}
				return clientHookActionConfig.HookActions;
			}
			case FixHookClientLevelEventExecutor.EHookPointStage.ClientMidway:
			{
				if (hookInteractConfig == null)
				{
					return null;
				}
				IClientHookActionConfig clientHookActionConfig2 = hookInteractConfig.ClientHookActionConfig;
				if (clientHookActionConfig2 == null)
				{
					return null;
				}
				return clientHookActionConfig2.ExitHookActions;
			}
			case FixHookClientLevelEventExecutor.EHookPointStage.ClientEndpoint:
			{
				if (hookInteractConfig == null)
				{
					return null;
				}
				IClientHookActionConfig clientHookActionConfig3 = hookInteractConfig.ClientHookActionConfig;
				if (clientHookActionConfig3 == null)
				{
					return null;
				}
				return clientHookActionConfig3.FinishActions;
			}
			default:
				return null;
			}
		}

		// Token: 0x06031151 RID: 201041 RVA: 0x00C35AB4 File Offset: 0x00C33CB4
		[NullableContext(1)]
		public static void ExecuteHookActions(FixHookClientLevelEventExecutor.EHookPointStage stage, GrapplingHookPointComponent grapplingHookPointComponent)
		{
			IHookInteractType hookInteractConfig = grapplingHookPointComponent.GetHookInteractConfig();
			List<ActionInfo> actions = FixHookClientLevelEventExecutor.GetActions(stage, hookInteractConfig);
			if (actions == null || actions.Count == 0)
			{
				return;
			}
			int id = grapplingHookPointComponent.Entity.Id;
			ControllerBase<LevelGeneralController>.Instance.ExecuteActionsNew(actions, EntityContext.Create(id, null), null);
		}

		// Token: 0x0200A9D6 RID: 43478
		public enum EHookPointStage
		{
			// Token: 0x040348F9 RID: 215289
			ClientHook,
			// Token: 0x040348FA RID: 215290
			ClientMidway,
			// Token: 0x040348FB RID: 215291
			ClientEndpoint
		}
	}
}
