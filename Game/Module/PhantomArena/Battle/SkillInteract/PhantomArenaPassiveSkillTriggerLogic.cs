using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.View;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract
{
	// Token: 0x020055E5 RID: 21989
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaPassiveSkillTriggerLogic : ISkillInteractMainInterface
	{
		// Token: 0x0603807D RID: 229501 RVA: 0x00E31CF8 File Offset: 0x00E2FEF8
		public PhantomArenaPassiveSkillTriggerLogic(PhantomBattleSelectTargetEffectNotify notify, PhantomArenaBattleProxy viewProxy)
		{
			this.ViewProxy = viewProxy;
			this.Data = new SkillTriggerInfo
			{
				InteractType = (EPhantomArenaBuffEffectType)notify.EffectType,
				SelectFightIdList = new List<int>(notify.FighterUId),
				SelectNum = notify.Num,
				IsRole = false,
				IsPassive = true,
				IsFight = false,
				IsClickInteract = false,
				DataId = new int?(notify.OwnerUid)
			};
		}

		// Token: 0x0603807E RID: 229502 RVA: 0x00E31D74 File Offset: 0x00E2FF74
		public UniTask Execute()
		{
			PhantomArenaPassiveSkillTriggerLogic.<Execute>d__3 <Execute>d__;
			<Execute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Execute>d__.<>4__this = this;
			<Execute>d__.<>1__state = -1;
			<Execute>d__.<>t__builder.Start<PhantomArenaPassiveSkillTriggerLogic.<Execute>d__3>(ref <Execute>d__);
			return <Execute>d__.<>t__builder.Task;
		}

		// Token: 0x0603807F RID: 229503 RVA: 0x00E31DB7 File Offset: 0x00E2FFB7
		public ISkillTriggerInfo GetData()
		{
			return this.Data;
		}

		// Token: 0x06038080 RID: 229504 RVA: 0x00E31DC0 File Offset: 0x00E2FFC0
		public UniTask StartSkillInteract()
		{
			return default(UniTask);
		}

		// Token: 0x06038081 RID: 229505 RVA: 0x00E31DD6 File Offset: 0x00E2FFD6
		public void CancelSkillInteract()
		{
		}

		// Token: 0x06038082 RID: 229506 RVA: 0x00E31DD8 File Offset: 0x00E2FFD8
		public void FinishSkillInteract()
		{
		}

		// Token: 0x0402008D RID: 131213
		protected SkillTriggerInfo Data;

		// Token: 0x0402008E RID: 131214
		protected PhantomArenaBattleProxy ViewProxy;
	}
}
