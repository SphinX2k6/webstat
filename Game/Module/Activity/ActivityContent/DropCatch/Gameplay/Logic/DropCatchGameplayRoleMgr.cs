using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x0200693F RID: 26943
	[NullableContext(2)]
	[Nullable(0)]
	public class DropCatchGameplayRoleMgr : DropCatchGameplayBaseMgr
	{
		// Token: 0x06042DFA RID: 273914 RVA: 0x0112A7CB File Offset: 0x011289CB
		[NullableContext(1)]
		public DropCatchGameplayRoleMgr(IGameplayLogicContext context) : base(context)
		{
		}

		// Token: 0x06042DFB RID: 273915 RVA: 0x0112A7D4 File Offset: 0x011289D4
		public override void Init()
		{
			DropCatchGameplay? gameplayConfig = this.Context.GetProxy().GetGameplayConfig();
			if (gameplayConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DropCatch, ELogAuthor.CB, "GameplayConfig is null", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.Role == null)
			{
				this.Role = new DropCatchGameplayRole();
			}
			this.Role.Init(new IDropCatchRoleParams
			{
				RoleId = gameplayConfig.Value.RoleId,
				Context = this.Context
			});
		}

		// Token: 0x06042DFC RID: 273916 RVA: 0x0112A85F File Offset: 0x01128A5F
		public override void OnReadyTick(float deltaTime)
		{
			IRoleInstance role = this.Role;
			if (role == null)
			{
				return;
			}
			role.OnReadyTick(deltaTime);
		}

		// Token: 0x06042DFD RID: 273917 RVA: 0x0112A872 File Offset: 0x01128A72
		public override void OnTick(float deltaTime)
		{
			IRoleInstance role = this.Role;
			if (role == null)
			{
				return;
			}
			role.OnTick(deltaTime);
		}

		// Token: 0x06042DFE RID: 273918 RVA: 0x0112A885 File Offset: 0x01128A85
		public IRoleInstance GetRole()
		{
			return this.Role;
		}

		// Token: 0x06042DFF RID: 273919 RVA: 0x0112A88D File Offset: 0x01128A8D
		public override void Destroy()
		{
			this.Role = null;
		}

		// Token: 0x0402543A RID: 152634
		private IRoleInstance Role;
	}
}
